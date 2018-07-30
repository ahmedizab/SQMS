using qms.Models;
using qms.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace qms.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private qmsEntities db = new qmsEntities();
        private BLL.BLLBranch dbBranch = new BLL.BLLBranch();
        private BLL.BLLCounters dbCounter = new BLL.BLLCounters();

        [Authorize(Roles = "Service Holder")]
        public ActionResult Index()
        {
            int branch_id = 0;
            if (!User.IsInRole("Admin"))
            {
                branch_id = new SessionManager(Session).branch_id;
            }
            
            List<tblBranch> branchList = new List<tblBranch>();
            branchList = dbBranch.GetAllBranch();
            ViewBag.branchList = branchList;
            ViewBag.userBranchId = branch_id;
            return View();
        }

        [Authorize(Roles = "Admin, Branch Admin, Token Generator")]
        public ActionResult Home()
        {
            return View();
        }


        [Authorize(Roles = "Service Holder")]
        public JsonResult GetCounterByBranchId(int branchId)
        {
            // List<tblCounter> counterList = new List<tblCounter>();
            var counterList = dbCounter.GetAllCounter().Where(a => a.branch_id == branchId).Select(x => new
            {
                counter_id = x.counter_id,
                counter_no = x.counter_no
            }).ToList();
            return Json(new { success = true, data = counterList },JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Service Holder")]
        public ActionResult BranchLogin()
        {
            return View();
        }
        
        [Authorize(Roles ="Admin")]
        public ActionResult AdminDashboard()
        {
            return View();
        }

        [Authorize(Roles = "Branch Admin")]
        public ActionResult BranchAdminDashboard()
        {
            return View();
        }

        [Authorize(Roles = "Service Holder")]
        public ActionResult CounterSelection()
        {
            int branch_id = 0;
            string branch_name = "";
            if (!User.IsInRole("Admin"))
            {
                SessionManager sm = new SessionManager(Session);
                branch_id = sm.branch_id;
                branch_name = sm.branch_name;
            }


            List<tblCounter> counterList = dbCounter.GetAllCounter().Where(w=>w.branch_id==branch_id).ToList();
            ViewBag.counterList = counterList;
            ViewBag.branch_id = branch_id;
            ViewBag.branch_name = branch_name;
            return View();
        }

        [Authorize(Roles = "Service Holder")]
        [HttpPost]
        public ActionResult CounterSelection(BranchLoginModel model)
        {
            if (ModelState.IsValid)
            {
                SessionManager sm = new SessionManager(Session);
                sm.counter_id = model.counter_id;
                sm.counter_no = dbCounter.GetAllCounter().Where(w=>w.counter_id == model.counter_id).FirstOrDefault().counter_no;
                return RedirectToAction("Create", "ServiceDetails");
            }
            else
            {
                return View();
            }
            
        }
    }
}
