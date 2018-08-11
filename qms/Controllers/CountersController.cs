using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using qms.Models;
using qms.ViewModels;
using qms.Utility;
using System.Speech.Synthesis;
using Google.Apis.Auth.OAuth2;
using System.IO;
using Google.Cloud.TextToSpeech.V1;

namespace qms.Controllers
{
    
    public class CountersController : Controller
    {
       
        
        private BLL.BLLCounters dbManager = new BLL.BLLCounters();
        private BLL.BLLBranch dbBranch = new BLL.BLLBranch();

        DisplayManager dm = new DisplayManager();

        // GET: Counters
        [Authorize(Roles = "Admin, Branch Admin")]
        public ActionResult Index()
        {
            ViewBag.branchList = dbBranch.GetAllBranch();

            SessionManager sm = new SessionManager(Session);
            ViewBag.userBranchId = sm.branch_id;
            return View(dbManager.GetAll());
            //var tblCounters = db.tblCounters.Include(t => t.tblBranch);
            //return View(await tblCounters.ToListAsync());
        }

       
        // GET: Counters/Create
        [Authorize(Roles = "Admin, Branch Admin")]
        public ActionResult Create()
        {
            ViewBag.branch_id = new SelectList(dbBranch.GetAllBranch(), "branch_id", "branch_name");
            return View();
        }

        //[Authorize(Roles = "Admin, Branch Admin, Display User")]
        [AllowAnonymous]
        public ActionResult CounterList()
        {
            SessionManager sm = new SessionManager(Session);
            //int branch_id = sm.branch_id;
            ViewBag.branch_id = sm.branch_id;
            ViewBag.dispalyFooterAdd = ApplicationSetting.dispalyFooterAdd;
            ViewBag.dispalyWelcome = ApplicationSetting.dispalyWelcome;
            ViewBag.dispalyVideo = ApplicationSetting.dispalyVideo;
            return View();
        }

        //[Authorize(Roles = "Admin, Branch Admin, Display User")]
        [AllowAnonymous]
        public JsonResult GetDisplayInfo(int branch_id)
        {
            try
            {
                DisplayManager dm = new DisplayManager();

                var tokenInProgress = dm.GetInProgressTokenList(branch_id);

                string nextToken = dm.GetNextTokens(branch_id);

                return Json(new { success = "true", tokenInProgress = tokenInProgress, nextTokens = nextToken }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = "false", errorMsg=ex.Message }, JsonRequestBehavior.AllowGet);
            }
           
        }

        // POST: Counters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Branch Admin")]
        public ActionResult Create([Bind(Include = "counter_id,branch_id,counter_no,location")] tblCounter tblCounter)
        {
            if (ModelState.IsValid)
            {
                dbManager.Create(tblCounter);

                //SessionManager sm = new SessionManager(Session);
                //if (!String.IsNullOrEmpty(sm.branch_static_ip))
                //    dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

                return RedirectToAction("Index");
            }

            ViewBag.branch_id = new SelectList(dbBranch.GetAllBranch(), "branch_id", "branch_name", tblCounter.branch_id);
            return View(tblCounter);
        }

        // GET: Counters/Edit/5
        [Authorize(Roles = "Admin, Branch Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCounter tblCounter = dbManager.GetById(id.Value);
            if (tblCounter == null)
            {
                return HttpNotFound();
            }
            ViewBag.branch_id = new SelectList(dbBranch.GetAllBranch(), "branch_id", "branch_name", tblCounter.branch_id);
            return View(tblCounter);
        }

        // POST: Counters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Branch Admin")]
        public ActionResult Edit([Bind(Include = "counter_id,branch_id,counter_no,location")] tblCounter tblCounter)
        {
            if (ModelState.IsValid)
            {
                dbManager.Edit(tblCounter);

                //SessionManager sm = new SessionManager(Session);
                //if (!String.IsNullOrEmpty(sm.branch_static_ip))
                //    dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

                return RedirectToAction("Index");
            }
            ViewBag.branch_id = new SelectList(dbBranch.GetAllBranch(), "branch_id", "branch_name", tblCounter.branch_id);
            return View(tblCounter);
        }

        // GET: Counters/Delete/5
        [Authorize(Roles = "Admin, Branch Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCounter tblCounter = dbManager.GetById(id.Value);
            if (tblCounter == null)
            {
                return HttpNotFound();
            }
            return View(tblCounter);
        }

        // POST: Counters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Branch Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCounter tblCounter = dbManager.GetById(id);
            dbManager.Remove(id);
            return RedirectToAction("Index");
        }

        
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Display(int id)
        {
            ViewBag.branch_id = id;
            ViewBag.dispalyFooterAdd = ApplicationSetting.dispalyFooterAdd;
            ViewBag.dispalyWelcome = ApplicationSetting.dispalyWelcome;
            ViewBag.dispalyVideo = ApplicationSetting.dispalyVideo;
            return View();
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbManager=null;
                dbBranch = null;
            }
            base.Dispose(disposing);
        }
    }
}
