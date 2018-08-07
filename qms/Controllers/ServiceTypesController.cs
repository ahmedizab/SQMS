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
    [Authorize(Roles = "Admin")]
    public class ServiceTypesController : Controller
    {
       
        private BLL.BLLServiceType dbManager = new BLL.BLLServiceType();
       


        // GET: ServiceTypes

        public ActionResult Index()
        {
            return View( dbManager.GetAll());
        }

        // GET: ServiceTypes/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblServiceType tblServiceType = await db.tblServiceTypes.FindAsync(id);
        //    if (tblServiceType == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblServiceType);
        //}

        // GET: ServiceTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "service_type_id,service_type_name")] tblServiceType tblServiceType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.tblServiceTypes.Add(tblServiceType);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(tblServiceType);
        //}

        public ActionResult Create([Bind(Include = "service_type_id,service_type_name")] tblServiceType tblServiceType) {

            if (ModelState.IsValid)
            {
                //db.tblServiceTypes.Add(tblServiceType);
                dbManager.Create(tblServiceType);
                return RedirectToAction("Index");
            }

            return View(tblServiceType);
        }
        // GET: ServiceTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblServiceType tblServiceType = dbManager.GetById(id.Value);
            if (tblServiceType == null)
            {
                return HttpNotFound();
            }
            return View(tblServiceType);
        }

        // POST: ServiceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Edit([Bind(Include = "service_type_id,service_type_name")] tblServiceType tblServiceType)
        {
            if (ModelState.IsValid)
            {
                dbManager.Edit(tblServiceType);
                return RedirectToAction("Index");
            }
            return View(tblServiceType);
        }

        // GET: ServiceTypes/Delete/5
        public  ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblServiceType tblServiceType = dbManager.GetById(id.Value);
            if (tblServiceType == null)
            {
                return HttpNotFound();
            }
            return View(tblServiceType);
        }

        // POST: ServiceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult DeleteConfirmed(int id)
        {
            tblServiceType tblServiceType = dbManager.GetById(id);
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
