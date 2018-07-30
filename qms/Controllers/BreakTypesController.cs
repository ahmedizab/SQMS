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

namespace qms.Controllers
{
    [Authorize(Roles = "Admin,Branch Admin")]
    public class BreakTypesController : Controller
    {
        //private qmsEntities db = new qmsEntities();
        private BLL.BLLBreakType dbManager = new BLL.BLLBreakType();
        // GET: BreakTypes
        public ActionResult Index()
        {
            return View(dbManager.GetAll());
        }

        // GET: BreakTypes/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblBreakType tblBreakType = await db.tblBreakTypes.FindAsync(id);
        //    if (tblBreakType == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblBreakType);
        //}

        // GET: BreakTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BreakTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "break_type_id,break_type_short_name,break_type_name,start_time,end_time,duration")] tblBreakType tblBreakType)
        {
            if (ModelState.IsValid)
            {
                dbManager.Create(tblBreakType);
                return RedirectToAction("Index");
            }

            return View(tblBreakType);
        }

        // GET: BreakTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBreakType tblBreakType = dbManager.GetById(id.Value);
            if (tblBreakType == null)
            {
                return HttpNotFound();
            }
            return View(tblBreakType);
        }

        // POST: BreakTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "break_type_id,break_type_short_name,break_type_name,start_time,end_time,duration")] tblBreakType tblBreakType)
        {
            if (ModelState.IsValid)
            {
                dbManager.Edit(tblBreakType);
                return RedirectToAction("Index");
            }
            return View(tblBreakType);
        }

        // GET: BreakTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBreakType tblBreakType = dbManager.GetById(id.Value);
            if (tblBreakType == null)
            {
                return HttpNotFound();
            }
            return View(tblBreakType);
        }

        // POST: BreakTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBreakType tblBreakType = dbManager.GetById(id);
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
