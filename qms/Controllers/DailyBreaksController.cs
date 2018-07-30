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
            ViewBag.Interval = dbManager.GetAll();




            //var tblDailyBreaks = db.tblDailyBreaks.Include(t => t.AspNetUser).Include(t => t.tblBreakType);
           
            return View(dbManager.GetAll());

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
            ViewBag.user_id = new SelectList(dbUser.GetAllUser(), "Id", "Hometown");
            ViewBag.break_type_id = new SelectList(dbBreak.GetAll(), "break_type_id", "break_type_name");
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
                ViewBag.user_id = new SelectList(dbUser.GetAllUser(), "Id", "Hometown", tblDailyBreak.user_id);
                ViewBag.break_type_id = new SelectList(dbBreak.GetAll(), "break_type_id", "break_type_short_name", tblDailyBreak.break_type_id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "daily_break_id,break_type_id,user_id,start_time,end_time,remarks")] tblDailyBreak tblDailyBreak)
        {
            if (ModelState.IsValid)
            {
                dbManager.Edit(tblDailyBreak);
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(dbUser.GetAllUser(), "Id", "Hometown", tblDailyBreak.user_id);
            ViewBag.break_type_id = new SelectList(dbBreak.GetAll(), "break_type_id", "break_type_short_name", tblDailyBreak.break_type_id);
            return View(tblDailyBreak);
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
