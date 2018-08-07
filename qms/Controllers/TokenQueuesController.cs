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
using qms.DAL;

using System.Data.Entity.Core.Objects;
using qms.ViewModels;
using qms.SignalRHub;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Web.Configuration;
using qms.BLL;

namespace qms.Controllers
{

    //ReportingSerivceLib.PrintManager objPrintManager = new PrintManager();

    //IList<ParameterValue> parameters = new List<ParameterValue>();

    public class TokenQueuesController : Controller
    {
        //private qmsEntities db = new qmsEntities();
        private int tokenid;
        private DateTime smstime;
        private int status;
        private BLL.BLLToken dbManager = new BLL.BLLToken();
        private BLL.BLLBranch dbBranch = new BLL.BLLBranch();
        private BLL.BLLStatus dbStatus = new BLL.BLLStatus();
        private BLL.BLLServiceType dbServiceType = new BLL.BLLServiceType();




        // GET: TokenQueues
        [Authorize(Roles = "Admin, Branch Admin,Token Generator")]
        public ActionResult Index(String branch_name, string counter_no)
        {
            ViewBag.branchList = dbBranch.GetAllBranch();
            ViewBag.service_status = dbStatus.GetAll();


            SessionManager sm = new SessionManager(Session);
            //tblTokenQueue tokenObj = new tblTokenQueue();
            ViewBag.userBranchId = sm.branch_id;
            //var tblTokenQueues = db.tblTokenQueues.Include(i => i.tblCounter).Include(i => i.tblServiceDetails);
            //string token_id = tokenObj.token_id.ToString();
            return View(dbManager.GetByBranchId(sm.branch_id));
            //return View(await tblTokenQueues.OrderByDescending(o=>o.token_id).ToListAsync());
        }

        // GET: TokenQueues/Details/5
        //[Authorize(Roles = "Admin, Branch Admin")]
        //public async Task<ActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblTokenQueue tblTokenQueue = await db.tblTokenQueues.FindAsync(id);
        //    if (tblTokenQueue == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblTokenQueue);
        //}

        [Authorize(Roles = "Branch Admin, Token Generator")]
        public ActionResult Create()
        {
            var serviceList = dbServiceType.GetAll();
            ViewBag.ServiceTypeList = serviceList;
            return View();
        }

        //[Authorize(Roles = "Branch Admin, Token Generator")]
        //[HttpPost]
        //public JsonResult Create(string mobile, string service)
        //{
        //    try
        //    {
        //        SessionManager sm = new SessionManager(Session);
        //        int branchId = sm.branch_id;

        //        DisplayManager dm = new DisplayManager();



        //        string subString = "Generated Token No is  #";
        //        var maxToken = dbManager.GetAll()
        //            .Where(w =>
        //                w.branch_id == branchId
        //                && /*w.service_date == DateTime.Now*/
        //                DbFunctions.TruncateTime(w.service_date) == DbFunctions.TruncateTime(DateTime.Now)
        //            );

        //        int tokenNo = 0;

        //        if (maxToken.Any())
        //        {
        //            tokenNo = maxToken.Max(m => m.token_no);
        //        }


        //        tblTokenQueue tokenObj = new tblTokenQueue();
        //        tokenObj.contact_no = mobile;
        //        tokenObj.service_date = DateTime.Now;

        //        tokenObj.token_no = tokenNo + 1;



        //        //dm.SendSms(tokenNo);
        //        //db.SaveChanges();



        //        tokenObj.service_status_id = 1;

        //        tokenObj.branch_id = branchId;
        //        tokenObj.service_type_id = Convert.ToInt32(service);
        //        dbManager.Create(mobile,service);


        //        //if (!String.IsNullOrEmpty(sm.branch_static_ip))
        //        //    dm.CreateTextFile(sm.branch_id, sm.branch_static_ip);

        //        string message = subString + tokenObj.token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0');
        //        NotifyDisplay.SendMessages(branchId, "null", "null");

        //        string token_id = tokenObj.token_id.ToString();
        //        string token_no = tokenObj.token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0');
        //        string date =Convert.ToString(DateTime.Now);
        //        //DisplayManager dm = new DisplayManager();


        //        return Json(new { Success = true, Message = message, tokenId = token_id, tokenNo = token_no, Date = date,msisdn=mobile }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = false, ErrorMessage = "Problem with Token Create, Please Try Again!" }, JsonRequestBehavior.AllowGet);
        //    }

        //}
        [Authorize(Roles = "Branch Admin, Token Generator")]
        
        [HttpPost]
        public JsonResult Create(string mobile, int service)
        {
            SessionManager sm = new SessionManager(Session);
             int branchId = sm.branch_id;

            //DisplayManager dm = new DisplayManager();
            tblTokenQueue tokenObj = new tblTokenQueue();
            tokenObj.branch_id = branchId;
            tokenObj.contact_no = mobile;
            tokenObj.service_type_id = service;
            dbManager.Create(tokenObj);
            string subString = "Token No is  #";
            string token_id = tokenObj.token_id.ToString();
            string token_no = tokenObj.token_no_formated;
            string message = subString + tokenObj.token_no_formated;
            return Json(new { Success = true, Message = message, tokenId = token_id, tokenNo = token_no,  msisdn = mobile }, JsonRequestBehavior.AllowGet);
        }

           

        //[Authorize(Roles = "Admin, Branch Admin")]
        //public async Task<ActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblTokenQueue tblTokenQueue = await db.tblTokenQueues.FindAsync(id);
        //    if (tblTokenQueue == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.branch_id = new SelectList(db.tblBranches, "branch_id", "branch_name", tblTokenQueue.branch_id);
        //    ViewBag.service_status_id = new SelectList(db.tblServiceStatus, "service_status_id", "service_status", tblTokenQueue.service_status_id);
        //    return View(tblTokenQueue);
        //}

        // POST: TokenQueues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, Branch Admin")]
        //public async Task<ActionResult> Edit([Bind(Include = "token_id,branch_id,token_no,service_date,service_status_id,contact_no")] tblTokenQueue tblTokenQueue)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tblTokenQueue).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.branch_id = new SelectList(db.tblBranches, "branch_id", "branch_name", tblTokenQueue.branch_id);
        //    ViewBag.service_status_id = new SelectList(db.tblServiceStatus, "service_status_id", "service_status", tblTokenQueue.service_status_id);
        //    return View(tblTokenQueue);
        //}

        // GET: TokenQueues/Delete/5
        //[Authorize(Roles = "Admin, Branch Admin")]
        //public async Task<ActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblTokenQueue tblTokenQueue = await db.tblTokenQueues.FindAsync(id);
        //    if (tblTokenQueue == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblTokenQueue);
        //}

        //// POST: TokenQueues/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, Branch Admin")]
        //public async Task<ActionResult> DeleteConfirmed(long id)
        //{
        //    tblTokenQueue tblTokenQueue = await db.tblTokenQueues.FindAsync(id);
        //    db.tblTokenQueues.Remove(tblTokenQueue);
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
        //public ActionResult GetList(DateTime date)
        //{
        //    DisplayManager dm = new DisplayManager();

        //    var v = dm.DateListToken((DateTime)date).ToList();
        //    List<VMTokenQueue> dateList = v.Select(s => new VMTokenQueue
        //    {
        //        //Branch_Name = s.Branch_Name,
        //        //Counter_Name = s.Counter_Name,
        //        //UserName = s.UserName,
        //        //start_time = s.start_time,
        //        //end_time = s.end_time,
        //        //customer_name = s.customer_name,
        //        //issues = s.issues,
        //        //solutions = s.solutions
        //    }).ToList();

        //    return PartialView(dateList);
        //}


        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, Branch Admin, Token Generator")]
        public ActionResult SMSSend(string mobileNo, string tokenNo)
        {
            string msgText = System.Configuration.ConfigurationManager.AppSettings.Get("msgText");
            try
            {
                BLLToken tokenManager = new BLLToken();

                tokenManager.SendSMS(mobileNo, string.Format(msgText, tokenNo));
                return Json(new { Success = true, Message = "SMS Saved Succesfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            
        }

        //private void PrintInvoice(string invoice)
        //{
        //     //connectionString= 
        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand("spINSERT_dbo_SmsLog", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@token_id", invoice);
            

        //    con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    //  frmInvoiceReportPrint ff = new frmInvoiceReportPrint(dr);
        //    // ff.ShowDialog();


        //    LocalReport report = new LocalReport();
        //    string exeFolder = System.Windows.Forms.Application.StartupPath;
        //    //report.ReportPath = Path.Combine(exeFolder, @"Report\InvoicePrintRpt.rdlc");
        //    report.ReportPath = Path.Combine(exeFolder, @"Report\AMBBookingInvoice.rdlc");
        //    report.DataSources.Add(new ReportDataSource("spINSERT_dbo_SmsLog", dr));
        //    TokenPrint objprint = new TokenPrint();
        //    objprint.Export(report);
        //    objprint.Print();

        //    dr.Close();
        //    con.Close();
        //}

        public ActionResult Print(int tokenNo)
        {

            string TokenText = "Token #";
            string token_no = TokenText + tokenNo.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0');
            string date = Convert.ToString(DateTime.Now);
           
                return Json(new { Success = true, Message = token_no, Date = date }, JsonRequestBehavior.AllowGet);
           
        }


    }

}
