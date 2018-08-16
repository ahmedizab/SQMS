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
    public class ServiceSubTypesController : Controller
    {
       
        private BLL.BLLServiceSubType dbManager = new BLL.BLLServiceSubType();
        private BLL.BLLServiceType dbService = new BLL.BLLServiceType();
        // GET: ServiceSubTypes
        public  ActionResult Index()
        {
            return View(dbManager.GetAll());
            //var tblServiceSubTypes = db.tblServiceSubTypes.Include(t => t.tblServiceType);
            //return View(await tblServiceSubTypes.ToListAsync());
        }

        [AllowAnonymous]
        public JsonResult GetByTypeId(int service_type_id)
        {
            var subTypes = dbManager.GetByTypeId(service_type_id);
            return Json(new { Success = true, serviceSubTypes = subTypes }, JsonRequestBehavior.AllowGet);

        }

        // GET: ServiceSubTypes/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblServiceSubType tblServiceSubType = await db.tblServiceSubTypes.FindAsync(id);
        //    if (tblServiceSubType == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblServiceSubType);
        //}

        // GET: ServiceSubTypes/Create
        public ActionResult Create()
        {
         
        ViewBag.service_type_id = new SelectList(dbService.GetAll(), "service_type_id", "service_type_name");
            return View();
        }

        // POST: ServiceSubTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "service_sub_type_id,service_type_id,service_sub_type_name,max_duration")] tblServiceSubType tblServiceSubType)
        {
            
            if (ModelState.IsValid)
            {
                //db.tblServiceSubTypes.Add(tblServiceSubType);
                //await db.SaveChangesAsync();
                dbManager.Create(tblServiceSubType);
                return RedirectToAction("Index");
            }

            ViewBag.service_type_id = new SelectList(dbService.GetAll(), "service_type_id", "service_type_name", tblServiceSubType.service_type_id);
            return View(tblServiceSubType);
        }

        // GET: ServiceSubTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblServiceSubType tblServiceSubType = dbManager.GetById(id.Value);
            if (tblServiceSubType == null)
            {
                return HttpNotFound();
            }
            ViewBag.service_type_id = new SelectList(dbService.GetAll(), "service_type_id", "service_type_name", tblServiceSubType.service_type_id);
            return View(tblServiceSubType);
        }

        // POST: ServiceSubTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "service_sub_type_id,service_type_id,service_sub_type_name,max_duration")] tblServiceSubType tblServiceSubType)
        {
            if (ModelState.IsValid)
            {
                dbManager.Edit(tblServiceSubType);
                return RedirectToAction("Index");
            }
            ViewBag.service_type_id = new SelectList(dbService.GetAll(), "service_type_id", "service_type_name", tblServiceSubType.service_type_id);
            return View(tblServiceSubType);
        }

        // GET: ServiceSubTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblServiceSubType tblServiceSubType = dbManager.GetById(id.Value);
            if (tblServiceSubType == null)
            {
                return HttpNotFound();
            }
            return View(tblServiceSubType);
        }

        // POST: ServiceSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblServiceSubType tblServiceSubType = dbManager.GetById(id);
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
