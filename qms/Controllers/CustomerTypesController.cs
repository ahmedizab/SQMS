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
    public class CustomerTypesController : Controller
    {
        private qmsEntities db = new qmsEntities();

        // GET: CustomerTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.tblCustomerTypes.ToListAsync());
        }

        // GET: CustomerTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustomerType tblCustomerType = await db.tblCustomerTypes.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "customer_type_id,customer_type_name")] tblCustomerType tblCustomerType)
        {
            if (ModelState.IsValid)
            {
                db.tblCustomerTypes.Add(tblCustomerType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblCustomerType);
        }

        // GET: CustomerTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustomerType tblCustomerType = await db.tblCustomerTypes.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "customer_type_id,customer_type_name")] tblCustomerType tblCustomerType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCustomerType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblCustomerType);
        }

        // GET: CustomerTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustomerType tblCustomerType = await db.tblCustomerTypes.FindAsync(id);
            if (tblCustomerType == null)
            {
                return HttpNotFound();
            }
            return View(tblCustomerType);
        }

        // POST: CustomerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblCustomerType tblCustomerType = await db.tblCustomerTypes.FindAsync(id);
            db.tblCustomerTypes.Remove(tblCustomerType);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
