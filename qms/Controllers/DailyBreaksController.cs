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
    [Authorize(Roles = "Admin,Branch Admin,Service Holder")]
    public class DailyBreaksController : Controller
    {
      
        private BLL.BLLDailyBreak dbManager = new BLL.BLLDailyBreak();
        private BLL.BLLBranch dbBranch = new BLL.BLLBranch();
        private BLL.BLLBreakType dbBreak = new BLL.BLLBreakType();
        private BLL.BLLAspNetUser dbUser = new BLL.BLLAspNetUser();



        // GET: DailyBreaks
        public ActionResult Index()
        {
            ViewBag.branchList = dbBranch.GetAllBranch();

            SessionManager sm = new SessionManager(Session);
            ViewBag.userBranchId = sm.branch_id;
            //ViewBag.Interval = dbManager.GetAll();


            int? branch_id;
            string user_id;
            if(User.IsInRole("Admin"))
            {
                branch_id = null;
                user_id = null;
            }
            else if (User.IsInRole("Branch Admin"))
            {
                branch_id = sm.branch_id;
                user_id = null;
            }
            else
            {
                branch_id = null;
                user_id = sm.user_id;
            }
            return View(dbManager.GetAll(branch_id, user_id));

        }

        // GET: DailyBreaks/Details/5
        //public async Task<ActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblDailyBreak tblDailyBreak = await db.tblDailyBreaks.FindAsync(id);
        //    if (tblDailyBreak == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblDailyBreak);
        //}

        // GET: DailyBreaks/Create
        public ActionResult Create()
        {
            SessionManager sm = new SessionManager(Session);
            ViewBag.user_id = new SelectList(dbUser.GetAllUser(), "Id", "Hometown", sm.user_id);
            
            ViewBag.break_type_id = new SelectList(dbBreak.GetAll(), "break_type_id", "break_name_with_duration");
            return View();
        }

        // POST: DailyBreaks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "daily_break_id,break_type_id,user_id,start_time,end_time,remarks")] tblDailyBreak tblDailyBreak)
        {
            try
            {
                SessionManager sm = new SessionManager(Session);
                tblDailyBreak.counter_id = sm.counter_id;
                tblDailyBreak.user_id = sm.user_id;
                tblDailyBreak.start_time = DateTime.Now;
                dbManager.Create(tblDailyBreak);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.error_message = ex.Message;
                SessionManager sm = new SessionManager(Session);
                ViewBag.user_id = new SelectList(dbUser.GetAllUser(), "Id", "Hometown", sm.user_id);

                ViewBag.break_type_id = new SelectList(dbBreak.GetAll(), "break_type_id", "break_name_with_duration");
                return View(tblDailyBreak);
            }
               
            

            
        }

        // GET: DailyBreaks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDailyBreak tblDailyBreak = dbManager.GetById(id.Value);
            if (tblDailyBreak == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(dbUser.GetAllUser(), "Id", "Hometown", tblDailyBreak.user_id);
            ViewBag.break_type_id = new SelectList(dbBreak.GetAll(), "break_type_id", "break_type_short_name", tblDailyBreak.break_type_id);
            return View(tblDailyBreak);
        }

        // POST: DailyBreaks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "daily_break_id,break_type_id,user_id,start_time,end_time,remarks")] tblDailyBreak tblDailyBreak)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        dbManager.Edit(tblDailyBreak);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.user_id = new SelectList(dbUser.GetAllUser(), "Id", "Hometown", tblDailyBreak.user_id);
        //    ViewBag.break_type_id = new SelectList(dbBreak.GetAll(), "break_type_id", "break_type_short_name", tblDailyBreak.break_type_id);
        //    return View(tblDailyBreak);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(string user_id)
        {
            
            SessionManager sm = new SessionManager(Session);
             
            int counter_id = sm.counter_id;
            string counter_no = sm.counter_no;
            if (ModelState.IsValid)
            {
                dbManager.Update(user_id);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        // GET: DailyBreaks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDailyBreak tblDailyBreak = dbManager.GetById(id.Value);
            if (tblDailyBreak == null)
            {
                return HttpNotFound();
            }
            return View(tblDailyBreak);
        }

        // POST: DailyBreaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDailyBreak tblDailyBreak = dbManager.GetById(id);
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
