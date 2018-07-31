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
using Microsoft.AspNet.Identity;
using qms.ViewModels;
using qms.Utility;
using System.Data.SqlClient;
using qms.SignalRHub;

namespace qms.Controllers
{
    [Authorize(Roles = "Admin, Branch Admin, Service Holder")]
    public class ServiceDetailsController : Controller
    {
        //private qmsEntities db = new qmsEntities();
        private BLL.BLLServiceDetail dbManager = new BLL.BLLServiceDetail();
        private BLL.BLLServiceType dbServiceType = new BLL.BLLServiceType();
        private BLL.BLLBranch dbBranch = new BLL.BLLBranch();
        private BLL.BLLCustomer dbCustomer = new BLL.BLLCustomer();
        private BLL.BLLToken dbtoken = new BLL.BLLToken();




        private BLL.BLLServiceSubType dbServiceSubType = new BLL.BLLServiceSubType();

        // GET: ServiceDetails
        public ActionResult Index()
        {
            ViewBag.branchList = dbBranch.GetAllBranch();

            SessionManager sm = new SessionManager(Session);
            ViewBag.userBranchId = sm.branch_id;
            return View(dbManager.GetAll());
            //var tblServiceDetails = db.tblServiceDetails.Include(t => t.tblCustomer).Include(t => t.tblTokenQueue).Include(x=>x.tblTokenQueue.AspNetUser).Include(x=>x.tblTokenQueue.tblBranch).Include(x=>x.tblTokenQueue.tblCounter);
            //return View(await tblServiceDetails.ToListAsync());
        }

        // GET: ServiceDetails/Details/5
        //public async Task<ActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblServiceDetail tblServiceDetail = await db.tblServiceDetails.FindAsync(id);
        //    if (tblServiceDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblServiceDetail);
        //}



        public ActionResult Create()
        {
            var servicetype = dbServiceType.GetAll();
            ViewBag.ServiceTypeList = servicetype;
            ViewBag.service_sub_type_id = new SelectList(dbServiceSubType.GetAll(), "service_sub_type_id", "service_sub_type_name");
            //ViewBag.ServiceTypeList = new SelectList(dbServiceSubType.GetAll(), "service_sub_type_id", "service_sub_type_name");

            return View();
        }

        //[HttpPost]
        //[Authorize(Roles = "Branch Admin, Service Holder")]
        //public JsonResult Create(VMServiceDetails model)
        //{
        //    try
        //    {
        //        model.service_datetime = DateTime.Now;
        //        model.end_time = DateTime.Now;
        //        tblCustomer cusObj = new tblCustomer();
        //        tblCustomer cusObjold = db.tblCustomers.Where(x => x.contact_no == model.contact_no).FirstOrDefault();
        //        if (cusObjold == null)
        //        {
        //            cusObj.customer_name = model.customer_name;
        //            cusObj.address = model.address;
        //            cusObj.contact_no = model.contact_no;
        //            cusObj.customer_type_id = 1;
        //            db.tblCustomers.Add(cusObj);
        //        }
        //        else
        //            cusObj = cusObjold;

        //        long tid = Convert.ToInt64(model.token_id);

        //        tblTokenQueue tokenobj = new tblTokenQueue();
        //        tokenobj = db.tblTokenQueues.Where(x => x.token_id == tid).FirstOrDefault();
        //        tokenobj.service_status_id = 3;

        //        if (tokenobj.contact_no == "")
        //        {
        //            tokenobj.contact_no = model.contact_no;
        //        }

        //        try
        //        {

        //            tblServiceDetail serObj = new tblServiceDetail();

        //            serObj.customer_id = cusObj.customer_id;
        //            serObj.service_datetime = serObj.end_time = DateTime.Now;
        //            serObj.start_time = model.start_time;

        //            serObj.service_sub_type_id = model.service_sub_type_id;
        //            serObj.issues = model.issues;
        //            serObj.solutions = model.solutions;
        //            serObj.token_id = Convert.ToInt64(model.token_id);
        //            db.tblServiceDetails.Add(serObj);
        //            db.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            return Json(new { Success = false, ErrorMessage = "Sorry! Error: " + ex.InnerException }, JsonRequestBehavior.AllowGet);
        //        }

        //        SessionManager sm = new SessionManager(Session);
        //        DisplayManager dm = new DisplayManager();
        //        if (!String.IsNullOrEmpty(sm.branch_static_ip))
        //            dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

        //        return Json(new { Success = true, Message = "Customer Service Information updated on Server" }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {

        //        return Json(new { Success = false, ErrorMessage = "Problem with Information updated, Please Try Again! Error: "+ex.Message }, JsonRequestBehavior.AllowGet);

        //    }

        //}
        [HttpPost]
        [Authorize(Roles = "Branch Admin, Service Holder")]
        public JsonResult Create(VMServiceDetails model)
        {
            try
            {
                SessionManager sm = new SessionManager(Session);
                DisplayManager dm = new DisplayManager();
                model.service_datetime = DateTime.Now;
                model.end_time = DateTime.Now;
                if (ModelState.IsValid)
                {

                    dbManager.Create(model);
                }
                // if (!String.IsNullOrEmpty(sm.branch_static_ip))
                //dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

                return Json(new { Success = true, Message = "Customer Service Information updated on Server" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Success = false, ErrorMessage = "Problem with Information updated, Please Try Again! Error: " + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        //public JsonResult Done(VMServiceDetails model)
        //{
        //    SessionManager sm = new SessionManager(Session);
        //    int branchId = sm.branch_id;
        //    int counterid = sm.counter_id;
        //    string counter_no = sm.counter_no;
        //    try
        //    {
        //        model.service_datetime = DateTime.Now;
        //        model.end_time = DateTime.Now;
        //        tblCustomer cusObj = new tblCustomer();
        //        tblCustomer cusObjold = db.tblCustomers.Where(x => x.contact_no == model.contact_no).FirstOrDefault();
        //        if (cusObjold == null)
        //        {
        //            cusObj.customer_name = model.customer_name;
        //            cusObj.address = model.address;
        //            cusObj.contact_no = model.contact_no;
        //            cusObj.customer_type_id = 1;
        //            db.tblCustomers.Add(cusObj);
        //        }
        //        else
        //            cusObj = cusObjold;

        //        long tid = Convert.ToInt64(model.token_id);

        //        tblTokenQueue tokenobj = new tblTokenQueue();
        //        tokenobj = db.tblTokenQueues.Where(x => x.token_id == tid).FirstOrDefault();
        //        tokenobj.service_status_id = 3;

        //        if (tokenobj.contact_no == "")
        //        {
        //            tokenobj.contact_no = model.contact_no;
        //        }

        //        try
        //        {

        //            tblServiceDetail serObj = new tblServiceDetail();

        //            serObj.customer_id = cusObj.customer_id;
        //            serObj.service_datetime = serObj.end_time = DateTime.Now;
        //            serObj.start_time = model.start_time;

        //            serObj.service_sub_type_id = model.service_sub_type_id;
        //            serObj.issues = model.issues;
        //            serObj.solutions = model.solutions;
        //            serObj.token_id = Convert.ToInt64(model.token_id);
        //            db.tblServiceDetails.Add(serObj);
        //            db.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            return Json(new { Success = false, ErrorMessage = "Sorry! Error: " + ex.InnerException }, JsonRequestBehavior.AllowGet);
        //        }


        //        DisplayManager dm = new DisplayManager();
        //        if (!String.IsNullOrEmpty(sm.branch_static_ip))
        //            dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);
        //        NotifyDisplay.SendMessages(branchId, counter_no, "ON");
        //        return Json(new { Success = true, Message = "Customer Service Information updated on Server" }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {

        //        return Json(new { Success = false, ErrorMessage = "Problem with Information updated, Please Try Again! Error: " + ex.Message }, JsonRequestBehavior.AllowGet);

        //    }

        //}


        //GET: ServiceDetails/Edit/5
        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblServiceDetail tblServiceDetail = db.tblServiceDetails.Include(a => a.tblCustomer).Where(a => a.service_id == id).FirstOrDefault();
        //    if (tblServiceDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    //ViewBag.counter_id = new SelectList(db.tblCounters, "counter_id", "counter_no", tblServiceDetail.counter_id);
        //    ViewBag.customer_id = new SelectList(db.tblCustomers, "customer_id", "customer_name", tblServiceDetail.customer_id);
        //    ViewBag.token_id = new SelectList(db.tblTokenQueues, "token_id", "contact_no", tblServiceDetail.token_id);
        //    return View(tblServiceDetail);
        //}

        //POST: ServiceDetails/Edit/5
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        private string ConvertDate(string DateTime)
        {
            string[] dattime = DateTime.Split(' ');
            return dattime[0];
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "service_id,token_id,customer_id,customer_name,issues,solutions,service_datetime")] tblServiceDetail tblServiceDetail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tblServiceDetail).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    //ViewBag.counter_id = new SelectList(db.tblCounters, "counter_id", "counter_no", tblServiceDetail.counter_id);
        //    ViewBag.customer_id = new SelectList(dbCustomer.GetAll(), "customer_id", "customer_name", tblServiceDetail.customer_id);
        //    ViewBag.token_id = new SelectList(dbtoken.GetAll(), "token_id", "contact_no", tblServiceDetail.token_id);

        //    return View(tblServiceDetail);
        //}

        //GET: ServiceDetails/Delete/5
        //public async Task<ActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblServiceDetail tblServiceDetail = await db.tblServiceDetails.FindAsync(id);
        //    if (tblServiceDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblServiceDetail);
        //}

        //// POST: ServiceDetails/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(long id)
        //{
        //    tblServiceDetail tblServiceDetail = await db.tblServiceDetails.FindAsync(id);
        //    db.tblServiceDetails.Remove(tblServiceDetail);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //[HttpPost]
        //public JsonResult NewTokenNo()
        //{
        //    try
        //    {
        //        tblTokenQueue tblTokenQueueObj = new tblTokenQueue();

        //        SessionManager sm = new SessionManager(Session);
        //        int branchId = sm.branch_id;
        //        int counterid = sm.counter_id;
        //        string counter_no = sm.counter_no;
        //        string user_id = sm.user_id;

        //        //checking is there any token at counter, which was in progress but not completed
        //        tblTokenQueueObj =   db.tblTokenQueues
        //                                .Where(x => 
        //                                    x.branch_id == branchId 
        //                                    && x.counter_id == counterid 
        //                                    && x.service_status_id == 2
        //                                    && x.service_date.Day == DateTime.Now.Day
        //                                    && x.service_date.Month == DateTime.Now.Month
        //                                    && x.service_date.Year == DateTime.Now.Year
        //                                 ).FirstOrDefault();
        //        if (tblTokenQueueObj == null)
        //        {

        //            tblTokenQueueObj = db.tblTokenQueues
        //                                    .Where(a =>
        //                                        a.branch_id == branchId 
        //                                        && a.service_status_id == 1
        //                                        && a.service_date.Day == DateTime.Now.Day
        //                                        && a.service_date.Month == DateTime.Now.Month
        //                                        && a.service_date.Year == DateTime.Now.Year
        //                                    ).FirstOrDefault();
        //            if (tblTokenQueueObj != null)
        //            {
        //                tblTokenQueueObj.service_status_id = 2;

        //                db.Entry(tblTokenQueueObj).State = EntityState.Modified;
        //                db.SaveChanges();
        //            }
        //            //DisplayManager dm = new Utility.DisplayManager();
        //            //if (!String.IsNullOrEmpty(sm.branch_static_ip))
        //            //    dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);
        //        }

        //        if (tblTokenQueueObj != null)
        //        {

        //            tblTokenQueueObj.counter_id = counterid;
        //            tblTokenQueueObj.user_id = User.Identity.GetUserId();
        //            db.SaveChanges();

        //            tblDailyBreak dailyBreak = db.tblDailyBreaks.Where(b => b.user_id == user_id && b.end_time.HasValue==false).FirstOrDefault();
        //            if (dailyBreak != null)
        //            {
        //                dailyBreak.end_time = DateTime.Now;
        //                db.Entry(dailyBreak).State = EntityState.Modified;
        //                db.SaveChanges();
        //            }

        //            //DisplayManager dm = new DisplayManager();
        //            //if (!String.IsNullOrEmpty(sm.branch_static_ip))
        //            //    dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

        //            tblCustomer customerDetails = db.tblCustomers.Where(a => a.contact_no == tblTokenQueueObj.contact_no).FirstOrDefault();

        //            var services = new SelectList(db.tblServiceSubTypes.Where(s => s.service_type_id == tblTokenQueueObj.service_type_id), "service_sub_type_id", "service_sub_type_name"); 

        //            if (customerDetails != null)
        //            {
        //                var customer = new
        //                {
        //                    token = tblTokenQueueObj.token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0'),
        //                    start_time = DateTime.Now.ToString("dd-MMM-yyyy HH:mm"),
        //                    tokenid = tblTokenQueueObj.token_id,
        //                    mobile_no = customerDetails.contact_no,
        //                    serviceType = tblTokenQueueObj.tblServiceType.service_type_name,
        //                    customer_name = customerDetails.customer_name,
        //                    address = customerDetails.address
        //                };
        //                db.SaveChanges();
        //                NotifyDisplay.SendMessages(branchId, counter_no, tblTokenQueueObj.token_no.ToString());
        //                return Json(new { Success = true, Message = customer, Services=services }, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                var customer = new
        //                {
        //                    token = tblTokenQueueObj.token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0'),
        //                    start_time = DateTime.Now.ToString("dd-MMM-yyyy HH:mm"),
        //                    tokenid = tblTokenQueueObj.token_id,
        //                    serviceType = tblTokenQueueObj.tblServiceType.service_type_name,
        //                    mobile_no = tblTokenQueueObj.contact_no,
        //                    customer_name = "",
        //                    address = ""
        //                };
        //                NotifyDisplay.SendMessages(branchId, counter_no, tblTokenQueueObj.token_no.ToString());
        //                return Json(new { Success = true, Message = customer, Services = services }, JsonRequestBehavior.AllowGet);
        //            }


        //        }
        //        else
        //        {
        //            NotifyDisplay.SendMessages(branchId, counter_no, "null");
        //            return Json(new { Success = false, EMessage = "No token for new service!" }, JsonRequestBehavior.AllowGet);
        //        }


        //    }
        //    catch(Exception ex)
        //    {
        //        return Json(new { Success = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}



        [HttpPost]
        public JsonResult NewTokenNo()
        {
            try
            {
                SessionManager sm = new SessionManager(Session);
                int branchId = sm.branch_id;
                int counterid = sm.counter_id;
                string counter_no = sm.counter_no;
                string user_id = sm.user_id;
                long token_id;
                int token_no;
                string contact_no, service_type, customer_name, address;
                DateTime start_time;

                var serviceList = dbManager.GetNewToken(branchId, counterid, user_id, out token_id, out token_no, out contact_no, out service_type, out start_time, out customer_name, out address);

                if (serviceList != null)
                {
                    var services = new SelectList(serviceList, "service_sub_type_id", "service_sub_type_name");


                    var customer = new
                    {
                        token = token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0'),
                        start_time = start_time.ToString("dd-MMM-yyyy HH:mm"),
                        tokenid = token_id,
                        serviceType = service_type,
                        mobile_no = contact_no,
                        customer_name = customer_name,
                        address = address
                    };
                    NotifyDisplay.SendMessages(branchId, counter_no, token_no.ToString());
                    return Json(new { Success = true, Message = customer, Services = services }, JsonRequestBehavior.AllowGet);



                }
                else
                {
                    NotifyDisplay.SendMessages(branchId, counter_no, "null");
                    return Json(new { Success = false, EMessage = "No token for new service!" }, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception ex)
            {
                return Json(new { Success = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult CancelTokenNo(long tokenID)
        {
            try
            {

                tblTokenQueue tokenObj = new tblTokenQueue();
                tokenObj = dbtoken.GetAllToken().Where(x => x.token_id == tokenID).FirstOrDefault();
                tokenObj.service_status_id = 4;
                tokenObj.cancel_time = DateTime.Now;
                dbManager.CancelToken(tokenID);
                string tNo = Convert.ToString(tokenObj.token_no);

                SessionManager sm = new SessionManager(Session);
                //DisplayManager dm = new DisplayManager();
                //if (!String.IsNullOrEmpty(sm.branch_static_ip))
                //    dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

                return Json(new { Success = true, Message = "Service Canceled for Token No #" + tNo }, JsonRequestBehavior.AllowGet);



            }
            catch
            {
                return Json(new { Success = false, ErrorMessage = "Problem with getting new service!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //[HttpPost]
        //public JsonResult Transfer(long tokenID)
        //{
        //    try
        //    {

        //        tblTokenQueue tokenObj = new tblTokenQueue();
        //        tokenObj = db.tblTokenQueues.Where(x => x.token_id == tokenID).FirstOrDefault();

        //        tokenObj.service_status_id = 1;
        //        db.SaveChanges();
        //        string tNo = Convert.ToString(tokenObj.token_no);

        //        SessionManager sm = new SessionManager(Session);
        //        DisplayManager dm = new DisplayManager();
        //        if (!String.IsNullOrEmpty(sm.branch_static_ip))
        //            dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

        //        return Json(new { Success = true, Message = "Service Transferred for Token No #" + tNo }, JsonRequestBehavior.AllowGet);



        //    }
        //    catch
        //    {
        //        return Json(new { Success = false, ErrorMessage = "Problem with getting new service!" }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //[HttpPost]
        //public JsonResult Skip(long tokenID)
        //{
        //    try
        //    {

        //        tblTokenQueue tokenObj = new tblTokenQueue();
        //        tokenObj = db.tblTokenQueues.Where(x => x.token_id == tokenID).FirstOrDefault();

        //        tokenObj.service_status_id = 5;
        //        db.SaveChanges();
        //        string tNo = Convert.ToString(tokenObj.token_no);

        //        SessionManager sm = new SessionManager(Session);
        //        DisplayManager dm = new DisplayManager();
        //        if (!String.IsNullOrEmpty(sm.branch_static_ip))
        //            dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

        //        return Json(new { Success = true, Message = "Service Canceled for Token No #" + tNo }, JsonRequestBehavior.AllowGet);



        //    }
        //    catch
        //    {
        //        return Json(new { Success = false, ErrorMessage = "Problem with getting new service!" }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //[HttpPost]
        //public JsonResult ReIssue(long tokenID)
        //{
        //    try
        //    {

        //        tblTokenQueue tblTokenQueueObj = new tblTokenQueue();

        //        SessionManager sm = new SessionManager(Session);
        //        int branchId = sm.branch_id;
        //        int counterid = sm.counter_id;
        //        string user_id = sm.user_id;

        //        //checking is there any token at count, which was in progress but not completed
        //        tblTokenQueueObj = db.tblTokenQueues.Where(x => x.branch_id == branchId && x.counter_id == counterid && x.service_status_id == 2).FirstOrDefault();
        //        if (tblTokenQueueObj == null)
        //        {

        //            tblTokenQueueObj = db.tblTokenQueues.Where(a => a.branch_id == branchId && a.service_status_id == 5).FirstOrDefault();
        //            if (tblTokenQueueObj != null)
        //            {
        //                tblTokenQueueObj.service_status_id = 2;

        //                db.Entry(tblTokenQueueObj).State = EntityState.Modified;
        //                db.SaveChanges();
        //            }
        //            DisplayManager dm = new Utility.DisplayManager();
        //            if (!String.IsNullOrEmpty(sm.branch_static_ip))
        //                dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);
        //        }

        //        if (tblTokenQueueObj != null)
        //        {

        //            tblTokenQueueObj.counter_id = counterid;
        //            tblTokenQueueObj.user_id = User.Identity.GetUserId();
        //            db.SaveChanges();

        //            tblDailyBreak dailyBreak = db.tblDailyBreaks.Where(b => b.user_id == user_id && b.end_time.HasValue == false).FirstOrDefault();
        //            if (dailyBreak != null)
        //            {
        //                dailyBreak.end_time = DateTime.Now;
        //                db.Entry(dailyBreak).State = EntityState.Modified;
        //                db.SaveChanges();
        //            }

        //            DisplayManager dm = new DisplayManager();
        //            if (!String.IsNullOrEmpty(sm.branch_static_ip))
        //                dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

        //            tblCustomer customerDetails = db.tblCustomers.Where(a => a.contact_no == tblTokenQueueObj.contact_no).FirstOrDefault();

        //            var services = new SelectList(db.tblServiceSubTypes.Where(s => s.service_type_id == tblTokenQueueObj.service_type_id), "service_sub_type_id", "service_sub_type_name");

        //            if (customerDetails != null)
        //            {
        //                var customer = new
        //                {
        //                    token = tblTokenQueueObj.token_no,
        //                    start_time = DateTime.Now.ToString("dd-MM-yyyy HH:mm"),
        //                    tokenid = tblTokenQueueObj.token_id,
        //                    mobile_no = customerDetails.contact_no,
        //                    serviceType = tblTokenQueueObj.tblServiceType.service_type_name,
        //                    customer_name = customerDetails.customer_name,
        //                    address = customerDetails.address
        //                };


        //                return Json(new { Success = true, Message = customer, Services = services }, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                var customer = new
        //                {
        //                    token = tblTokenQueueObj.token_no,
        //                    start_time = DateTime.Now.ToString("dd-MM-yyyy HH:mm"),
        //                    tokenid = tblTokenQueueObj.token_id,
        //                    serviceType = tblTokenQueueObj.tblServiceType.service_type_name,
        //                    mobile_no = tblTokenQueueObj.contact_no,
        //                    customer_name = "",
        //                    address = ""
        //                };
        //                return Json(new { Success = true, Message = customer, Services = services }, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            return Json(new { Success = false, EMessage = "No token for new service!" }, JsonRequestBehavior.AllowGet);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}




        public JsonResult GetCustomerInformation(long token_id, string contact_no)
        {
            try
            {

                //tblTokenQueue tokenDetail = db.tblTokenQueues.Where(a => a.token_id == token_id).FirstOrDefault();

                //tokenDetail.service_status_id = 2;

                //db.Entry(tokenDetail).State = EntityState.Modified;
                //db.SaveChanges();

                tblTokenQueue tblTokenQueue = dbtoken.GetAllToken().Where(a => a.token_id == token_id).FirstOrDefault();
                tblCustomer customerDetails = dbCustomer.GetAll().Where(a => a.contact_no == contact_no).FirstOrDefault();

                if (customerDetails != null)
                {
                    //List<tblTokenQueue> previousHistoryList = new List<tblTokenQueue>();
                    //var previousHistoryList = db.tblTokenQueues.Where(a => a.contact_no == contact_no).Include(x=>x.tblServiceDetails).ToList();

                    List<tblServiceDetail> previousHistoryList = dbManager.GetAllService().Where(x => x.customer_id == customerDetails.customer_id).ToList();
                    List<VMServiceDetails> customerlist = new List<VMServiceDetails>();

                    foreach (tblServiceDetail item in previousHistoryList)
                    {
                        VMServiceDetails VMServiceDetails = new VMServiceDetails()
                        {
                            issues = item.issues,
                            solutions = item.solutions,
                            service_datetime = item.service_datetime,
                            customer_name = item.tblCustomer.customer_name,
                            address = item.tblCustomer.address
                        };
                        customerlist.Add(VMServiceDetails);
                    }


                    return Json(new { Success = true, Message = customerlist }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var customer = new
                    {
                        mobile_no = tblTokenQueue.contact_no,
                        customer_name = "",
                        address = ""
                    };
                    return Json(new { Success = true, Message = customer }, JsonRequestBehavior.AllowGet);
                }


            }
            catch
            {
                return Json(new { Success = false, ErrorMessage = "Problem with getting Customer Information!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult GetList(DateTime date)
        //{
        //    DisplayManager dm = new DisplayManager();

        //    var v = dm.DateListService((DateTime)date).ToList();
        //    List<VMServiceDetails> dateList = v.Select(s => new VMServiceDetails
        //    {
        //        branch_name = s.branch_name,
        //        Counter_Name = s.Counter_Name,
        //        UserName = s.UserName,
        //        start_time = s.start_time,
        //        end_time = s.end_time,
        //        customer_name = s.customer_name,
        //        issues = s.issues,
        //        solutions = s.solutions
        //    }).ToList();

        //    return PartialView(dateList);
        //}
    }
}
