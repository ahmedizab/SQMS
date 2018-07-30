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
using qms.Utility;

namespace qms.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BranchesController : Controller
    {
        private BLL.BLLBranch dbManager = new BLL.BLLBranch();
        private BLL.BLLServiceDetail dbService = new BLL.BLLServiceDetail();

        // GET: Branches
        //public async Task<ActionResult> Index()
        public ActionResult Index()

        {
            return View(dbManager.GetAllBranch());
            //return View(await db.tblBranches.ToListAsync());
        }

        // GET: Branches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBranch tblBranch =  dbManager.GetById(id.Value);
            if (tblBranch == null)
            {
                return HttpNotFound();
            }
            return View(tblBranch);
        }

        // GET: Branches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "branch_id,branch_name,address,contact_person,contact_no,display_next,static_ip")] tblBranch tblBranch)
        {
            if (ModelState.IsValid)
            {
                //db.tblBranches.Add(tblBranch);

                //await db.SaveChangesAsync();
                dbManager.Create(tblBranch);

                //DisplayManager dm = new Utility.DisplayManager();
                //if (!String.IsNullOrEmpty(tblBranch.static_ip))
                //    dm.CreateTextFile(tblBranch.branch_id, tblBranch.static_ip);

                return RedirectToAction("Index");
            }

            return View(tblBranch);
        }

        // GET: Branches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBranch tblBranch = dbManager.GetById(id.Value);
            if (tblBranch == null)
            {
                return HttpNotFound();
            }
            return View(tblBranch);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "branch_id,branch_name,address,contact_person,contact_no,display_next,static_ip")] tblBranch tblBranch)
        {
            if (ModelState.IsValid)
            {
                dbManager.Edit(tblBranch);

                return RedirectToAction("Index");
            }
            return View(tblBranch);
        }

        // GET: Branches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBranch tblBranch = dbManager.GetById(id.Value);
            if (tblBranch == null)
            {
                return HttpNotFound();
            }
            return View(tblBranch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tblBranch tblBranch = dbManager.GetById(id);
        //    db.tblBranches.Remove(tblBranch);
            
        //    return RedirectToAction("Index");
        //}
        //--------------- Edit ----------------
        public JsonResult AutocompleteBranchSuggestions(string term)
        {
            //   var suggestions = unitOfWork.EmployeesRepository.Get().Where(w => w.IdentificationNumber.ToLower().Trim().Contains(term.ToLower().Trim()) && w.OCode == OCode && w.PFStatus != 2).OrderBy(s => s.IdentificationNumber).Select(s => new { value = s.EmpName, label = s.IdentificationNumber }).ToList();
            //List<tblBranch> branchList = new List<tblBranch>();
            var branchList = dbManager.GetAllBranch().Where(x => x.branch_name.ToLower().Trim().Contains(term.ToLower().Trim())).Select(s => new { value = s.branch_id, label = s.branch_name }).ToList();
            return Json(branchList, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetServicesByBranchId(string id)
        //{
        //    int ID= Convert.ToInt32(id);
        //    var tableResul= dbService.GetAll().Include(x => x.tblTokenQueue.branch_id == ID).ToList();
        //    return Json(tableResul);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
