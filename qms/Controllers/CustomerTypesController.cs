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
using qms.BLL;

namespace qms.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerTypesController : Controller
    {
        private BLLCustomerType db = new BLLCustomerType();

        // GET: CustomerTypes
        public ActionResult Index()
        {
            return View(db.GetAll());
        }

        // GET: CustomerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustomerType tblCustomerType = db.GetById(id.Value);
            if (tblCustomerType == null)
            {
                return HttpNotFound();
            }
            return View(tblCustomerType);
        }

        // GET: CustomerTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customer_type_id,customer_type_name,priority")] tblCustomerType tblCustomerType)
        {
            if (ModelState.IsValid)
            {
                db.Create(tblCustomerType);
                return RedirectToAction("Index");
            }

            return View(tblCustomerType);
        }

        // GET: CustomerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustomerType tblCustomerType =  db.GetById(id.Value);
            if (tblCustomerType == null)
            {
                return HttpNotFound();
            }
            return View(tblCustomerType);
        }

        // POST: CustomerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customer_type_id,customer_type_name,priority")] tblCustomerType tblCustomerType)
        {
            if (ModelState.IsValid)
            {
                db.Edit(tblCustomerType);
                return RedirectToAction("Index");
            }
            return View(tblCustomerType);
        }

        // GET: CustomerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustomerType tblCustomerType = db.GetById(id.Value);
            if (tblCustomerType == null)
            {
                return HttpNotFound();
            }
            return View(tblCustomerType);
        }

        // POST: CustomerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db = null;
            }
            base.Dispose(disposing);
        }
    }
}
