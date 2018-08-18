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
        private BLL.BLLDailyBreak dbBreak = new BLL.BLLDailyBreak();





        private BLL.BLLServiceSubType dbServiceSubType = new BLL.BLLServiceSubType();

        // GET: ServiceDetails
        public ActionResult Index()
        {
            ViewBag.branchList = dbBranch.GetAllBranch();

            SessionManager sm = new SessionManager(Session);
            ViewBag.userBranchId = sm.branch_id;

            int? branch_id;
            string user_id;
            if (User.IsInRole("Admin"))
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

            return View(dbManager.GetAllCurrentDate(branch_id, user_id));

        }

   


        public ActionResult Create()
        {
            var servicetype = dbServiceType.GetAll();
            ViewBag.service_type_id = new SelectList(servicetype, "service_type_id", "service_type_name");
            ViewBag.service_sub_type_id = new SelectList(dbServiceSubType.GetAll(), "service_sub_type_id", "service_sub_type_name");
            //ViewBag.ServiceTypeList = new SelectList(dbServiceSubType.GetAll(), "service_sub_type_id", "service_sub_type_name");

            return View();
        }

        
        [HttpPost]
        [Authorize(Roles = "Branch Admin, Service Holder")]
        public JsonResult Create(VMServiceDetails model)
        {
            try
            {
                SessionManager sm = new SessionManager(Session);
                DisplayManager dm = new DisplayManager();
                model.service_datetime = DateTime.Now;
                model.customer_name = model.contact_no;
                model.end_time = DateTime.Now;
                model.user_id = sm.user_id;
                model.counter_id = sm.counter_id;
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

                return Json(new { Success = false, Message = "Problem with Information updated, Please Try Again! Error: " + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [Authorize(Roles = "Branch Admin, Service Holder")]
        public JsonResult Done(VMServiceDetails model)
        {
            try
            {
                SessionManager sm = new SessionManager(Session);
                DisplayManager dm = new DisplayManager();
                int branchId = sm.branch_id;
                
                string counter_no = sm.counter_no;
                model.service_datetime = DateTime.Now;
                model.end_time = DateTime.Now;
                model.user_id = sm.user_id;
                model.counter_id = sm.counter_id;
                if (ModelState.IsValid)
                {
                    dbManager.Create(model);
                }
                // if (!String.IsNullOrEmpty(sm.branch_static_ip))
                //dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);
                NotifyDisplay.SendMessages(branchId, counter_no, "");
                return Json(new { Success = true, Message = "Customer Service Information updated on Server" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Success = false, Message = "Problem with Information updated, Please Try Again! Error: " + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [Authorize(Roles = "Branch Admin, Service Holder")]
        public JsonResult AddService(VMServiceDetails model)
        {
            try
            {
                SessionManager sm = new SessionManager(Session);
                DisplayManager dm = new DisplayManager();
                model.service_datetime = DateTime.Now;
                model.end_time = DateTime.Now;
                model.user_id = sm.user_id;
                model.counter_id = sm.counter_id;
                if (ModelState.IsValid)
                {
                    dbManager.AddService(model);
                }
                // if (!String.IsNullOrEmpty(sm.branch_static_ip))
                //dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

                return Json(new { Success = true, Message = "Customer Service Information updated on Server" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Success = false, Message = "Problem with Information updated, Please Try Again! Error: " + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }



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
                int token_no, is_break;
                string contact_no, service_type, customer_name, address;
                DateTime start_time, generate_time;

                var serviceList = dbManager.GetNewToken(branchId, counterid, user_id, out token_id, out token_no, out contact_no, out service_type, out start_time, out customer_name, out address,out generate_time,out is_break);

                if (serviceList.Count>0)
                {
                    var services = new SelectList(serviceList, "service_sub_type_id", "service_sub_type_name");


                    var customer = new
                    {
                        token = token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0'),
                        start_time = start_time.ToString("hh:mm:ss tt"),
                        tokenid = token_id,
                        serviceType = service_type,
                        mobile_no = contact_no,
                        user_id=user_id,
                        generate_time = generate_time.ToString("hh:mm:ss tt"),
                        call_time= start_time.ToString("hh:mm:ss tt"),
                        IsBreak= is_break,
                        waitingtime = start_time.Subtract(generate_time).ToString(),
                        service_type_id = (serviceList.Count>0? serviceList.FirstOrDefault().service_type_id : 0),
                    customer_name = customer_name,
                        address = address
                    };
                    NotifyDisplay.SendMessages(branchId, counter_no, token_no.ToString());
                    return Json(new { Success = true, Message = customer, Services = services }, JsonRequestBehavior.AllowGet);



                }
                else
                {
                    NotifyDisplay.SendMessages(branchId, counter_no, "");
                    return Json(new { Success = false, Message = "No token for new service!" }, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public JsonResult CallManualTokenNo(string token_no_string)
        {
            try
            {
                SessionManager sm = new SessionManager(Session);
                int branchId = sm.branch_id;
                int counterid = sm.counter_id;
                string counter_no = sm.counter_no;
                string user_id = sm.user_id;
                long token_id;
                int token_no=Convert.ToInt32(token_no_string);
                string contact_no, service_type, customer_name, address;
                DateTime start_time;

                var serviceList = dbManager.CallManualToken(branchId, counterid, user_id, token_no, out token_id, out contact_no, out service_type, out start_time, out customer_name, out address);

                if (serviceList.Count > 0)
                {
                    var services = new SelectList(serviceList, "service_sub_type_id", "service_sub_type_name");


                    var customer = new
                    {
                        token = token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0'),
                        start_time = start_time.ToString("dd-MMM-yyyy hh:mm:ss tt"),
                        tokenid = token_id,
                        serviceType = service_type,
                        mobile_no = contact_no,
                        customer_name = customer_name,
                        address = address
                    };
                    //NotifyDisplay.SendMessages(branchId, counter_no, token_no.ToString());
                    return Json(new { Success = true, Message = customer, Services = services }, JsonRequestBehavior.AllowGet);



                }
                else
                {
                    NotifyDisplay.SendMessages(branchId, counter_no, "");
                    return Json(new { Success = false, Message = "No token for new service!" }, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult CancelTokenNo(long tokenID)
        {
            try
            {


                int token_no = dbManager.CancelToken(tokenID);

                //SessionManager sm = new SessionManager(Session);
                //DisplayManager dm = new DisplayManager();
                //if (!String.IsNullOrEmpty(sm.branch_static_ip))
                //    dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

                return Json(new { Success = true, Message = "Service Canceled for Token No #" + token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0') }, JsonRequestBehavior.AllowGet);



            }
            catch(Exception ex)
            {
                return Json(new { Success = false, Message = "Problem with getting new service!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Cancel(long tokenID)
        {
            try
            {
                SessionManager sm = new SessionManager(Session);
                DisplayManager dm = new DisplayManager();
                int branchId = sm.branch_id;

                string counter_no = sm.counter_no;

                int token_no = dbManager.CancelToken(tokenID);

                //SessionManager sm = new SessionManager(Session);
                //DisplayManager dm = new DisplayManager();
                //if (!String.IsNullOrEmpty(sm.branch_static_ip))
                //    dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);
                NotifyDisplay.SendMessages(branchId, counter_no, "");

                return Json(new { Success = true, Message = "Service Canceled for Token No #" + token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0') }, JsonRequestBehavior.AllowGet);



            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = "Problem with getting new service!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Transfer(long token_id, string counter_no)
        {
            try
            {

                SessionManager sm = new SessionManager(Session);

                dbManager.Transfer(sm.branch_id, counter_no, token_id);

                //SessionManager sm = new SessionManager(Session);
                //DisplayManager dm = new DisplayManager();
                //if (!String.IsNullOrEmpty(sm.branch_static_ip))
                //    dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

                return Json(new { Success = true, Message = "Service transfered to counter #" + counter_no + ", customer must wait for calling" }, JsonRequestBehavior.AllowGet);



            }
            catch(Oracle.DataAccess.Client.OracleException ex)
            {
                if (ex.Number == 20001)
                    return Json(new { Success = false, Message = "Counter not found" }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
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
        //        return Json(new { Success = false, Message = "Problem with getting new service!" }, JsonRequestBehavior.AllowGet);
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
        //        return Json(new { Success = false, Message = "Problem with getting new service!" }, JsonRequestBehavior.AllowGet);
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
        //            return Json(new { Success = false, Message = "No token for new service!" }, JsonRequestBehavior.AllowGet);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
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

                tblCustomer customerDetails = dbCustomer.GetAll().Where(a => a.contact_no == contact_no).FirstOrDefault();

                if (customerDetails != null)
                {
                    //List<tblTokenQueue> previousHistoryList = new List<tblTokenQueue>();
                    //var previousHistoryList = db.tblTokenQueues.Where(a => a.contact_no == contact_no).Include(x=>x.tblServiceDetails).ToList();

                    List<tblServiceDetail> previousHistoryList = dbManager.GetByCustomerID(customerDetails.customer_id);
                    List<VMServiceDetails> customerlist = new List<VMServiceDetails>();

                    foreach (tblServiceDetail item in previousHistoryList)
                    {
                        VMServiceDetails VMServiceDetails = new VMServiceDetails()
                        {
                            issues = item.issues,
                            solutions = item.solutions,
                            service_datetime = item.service_datetime
                        };
                        customerlist.Add(VMServiceDetails);
                    }


                    return Json(new { Success = true, Message = customerlist, customerDetails = customerDetails }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Success = false, Message = "", customerDetails = "" }, JsonRequestBehavior.AllowGet);
                }


            }
            catch(Exception ex)
            {
                return Json(new { Success = false, Message = "Problem with getting Customer Information!" }, JsonRequestBehavior.AllowGet);
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
