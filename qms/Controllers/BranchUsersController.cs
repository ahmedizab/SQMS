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
    [Authorize(Roles = "Admin, Branch Admin")]
    public class BranchUsersController : Controller
    {
       
        private BLL.BLLBranchUsers dbManager = new BLL.BLLBranchUsers();
        private BLL.BLLBranch dbBranch = new BLL.BLLBranch();

        // GET: BranchUsers
        public ActionResult Index()
        {
            
            ViewBag.branchList = dbBranch.GetAllBranch();

            SessionManager sm = new SessionManager(Session);
            ViewBag.userBranchId = sm.branch_id;
            return View(dbManager.GetAll());
            //return View(await db.tblBranchUsers.ToListAsync());
        }

        // GET: BranchUsers/Details/5
       

        // GET: BranchUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BranchUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_branch_id,user_id,branch_id")] tblBranchUser tblBranchUser)
        {
            if (ModelState.IsValid)
            {
                dbManager.Create(tblBranchUser);
                return RedirectToAction("Index");
            }

            return View(tblBranchUser);
        }

        // GET: BranchUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBranchUser tblBranchUser = dbManager.GetById(id.Value);
            if (tblBranchUser == null)
            {
                return HttpNotFound();
            }
            return View(tblBranchUser);
        }

        // POST: BranchUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_branch_id,user_id,branch_id")] tblBranchUser tblBranchUser)
        {
            if (ModelState.IsValid)
            {
                dbManager.Edit(tblBranchUser);
                return RedirectToAction("Index");
            }
            return View(tblBranchUser);
        }

        // GET: BranchUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBranchUser tblBranchUser = dbManager.GetById(id.Value);
            if (tblBranchUser == null)
            {
                return HttpNotFound();
            }
            return View(tblBranchUser);
        }

        // POST: BranchUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBranchUser tblBranchUser = dbManager.GetById(id);
            dbManager.Remove(id);
            return RedirectToAction("Index");
        }

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
