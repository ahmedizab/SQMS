using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using System.IO;
using qms.ViewModels;
using qms.Models;


namespace qms.Controllers
{
    [Authorize(Roles = "Admin, Branch Admin, Service Holder")]
    public class ReportController : Controller
    {
        //
        // GET: /Report/
        ReportDataSource rd;
        private qmsEntities db = new qmsEntities();
        public ActionResult Index()
        {
           // ViewBag.branch_id = new SelectList(db.tblBranches, "branch_id", "branch_name");
            List<tblBranch> branchList = new List<tblBranch>();
            branchList = db.tblBranches.ToList();
            ViewBag.branchList = branchList;
            return View();
        }

        public JsonResult GetTokenByBranchId(int CounterId)
        {
            // List<tblCounter> counterList = new List<tblCounter>();
            var tokenList = db.tblTokenQueues.Where(a => a.counter_id == CounterId).Select(x => new
            {
                token_id = x.token_id
            }).ToList();
            return Json(new { success = true, data = tokenList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CustomerServiceReport(string id, string reportOptions, int? branchID, int? CounterID, int? tokenID, DateTime? fromDate, DateTime? toDate)
        {
            LocalReport lr = new LocalReport();

            //DateTime? fdate = fromDate.GetValueOrDefault();
            //DateTime? tdate = toDate.GetValueOrDefault();
            DateTime? fdate = null;
            DateTime? tdate = null;

            if (reportOptions == "Summary")
            {
                string path = Path.Combine(Server.MapPath("~/Reports"), "SummaryReport.rdlc");
                if (System.IO.File.Exists(path))
                {
                    lr.ReportPath = path;
                }



                List<VMServiceDetails> v = new List<VMServiceDetails>();

                if (fromDate == null)
                {
                    fdate = null;
                }
                else
                {
                    fdate = fromDate.GetValueOrDefault();
                    //fdate = fdate.AddSeconds(-1);
                }
                if (toDate == null)
                {
                    toDate = null;
                }
                else
                {
                    tdate = toDate.GetValueOrDefault();
                    //tdate = tdate.AddDays(1).AddSeconds(-1);
                }
                CustomModel csmodel = new CustomModel();

                v = csmodel.GetCustomerServiceSummary(branchID,fdate,tdate).ToList();

                ReportParameterCollection reportParameters = new ReportParameterCollection();

                reportParameters.Add(new ReportParameter("rpFromDate", fromDate + ""));
                reportParameters.Add(new ReportParameter("rpToDate", toDate + ""));

                lr.SetParameters(reportParameters);

                rd = new ReportDataSource("DataSet1", v);
            }
            else if (reportOptions == "ServiceDetails")
            {


                List<VMServiceDetails> v = new List<VMServiceDetails>();
                //if (CounterID != null && tokenID != null)
                //{
                //    string path = Path.Combine(Server.MapPath("~/Reports"), "DetailsReport.rdlc");
                //    if (System.IO.File.Exists(path))
                //    {
                //        lr.ReportPath = path;
                //    }

                //    if (fromDate == null)
                //    {
                //        fromDate = DateTime.MinValue;
                //    }
                //    else
                //    {
                //        fdate = fromDate.GetValueOrDefault();
                //        fdate = fdate.AddSeconds(-1);
                //    }
                //    if (toDate == null)
                //    {
                //        toDate = DateTime.MaxValue;
                //    }
                //    else
                //    {
                //        tdate = toDate.GetValueOrDefault();
                //        tdate = tdate.AddDays(1).AddSeconds(-1);
                //    }
                //    CustomModel csmodel = new CustomModel();

                //    v = csmodel.GetCustomerServiceDetails(CounterID, tokenID).ToList();

                //    ReportParameterCollection reportParameters = new ReportParameterCollection();

                //    reportParameters.Add(new ReportParameter("rpFromDate", fromDate + ""));
                //    reportParameters.Add(new ReportParameter("rpToDate", toDate + ""));

                //    lr.SetParameters(reportParameters);

                //    rd = new ReportDataSource("DataSet1", v);
                //}
                //else
                //{
                    string path = Path.Combine(Server.MapPath("~/Reports"), "CounterTokenDetailsALLReport.rdlc");
                    if (System.IO.File.Exists(path))
                    {
                        lr.ReportPath = path;
                    }

                    if (fromDate == null)
                    {
                        fromDate = DateTime.MinValue;
                    }
                    else
                    {
                        fdate = fromDate.GetValueOrDefault();
                        //fdate = fdate.AddSeconds(-1);
                    }
                    if (toDate == null)
                    {
                        toDate = DateTime.MaxValue;
                    }
                    else
                    {
                        tdate = toDate.GetValueOrDefault();
                        //tdate = tdate.AddDays(1).AddSeconds(-1);
                    }
                    CustomModel csmodel = new CustomModel();

                    v = csmodel.GetCustomerServiceDetails(CounterID, tokenID).ToList();

                    ReportParameterCollection reportParameters = new ReportParameterCollection();

                    reportParameters.Add(new ReportParameter("rpFromDate", fromDate + ""));
                    reportParameters.Add(new ReportParameter("rpToDate", toDate + ""));

                    lr.SetParameters(reportParameters);

                    rd = new ReportDataSource("DataSet1", v);
                //}


            }






            lr.DataSources.Add(rd);

            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, mimeType);
        }


        //public ActionResult CustomerServiceReport(string id , string reportOptions,int? branchID,int? CounterID,int? tokenID,  DateTime? fromDate, DateTime? toDate)
        //{
        //    LocalReport lr = new LocalReport();

        //    DateTime fdate = fromDate.GetValueOrDefault();
        //    DateTime tdate = toDate.GetValueOrDefault();

        //    if (reportOptions == "Summary")
        //    {
        //        string path = Path.Combine(Server.MapPath("~/Reports"), "SummaryReport.rdlc");
        //        if (System.IO.File.Exists(path))
        //        {
        //            lr.ReportPath = path;
        //        }

        //        List<VMServiceDetails> v = new List<VMServiceDetails>();

        //            if (fromDate == null)
        //            {
        //                fromDate = DateTime.MinValue;
        //            }
        //            else
        //            {
        //                fdate = fromDate.GetValueOrDefault();
        //                fdate = fdate.AddSeconds(-1);
        //            }
        //            if (toDate == null)
        //            {
        //                toDate = DateTime.MaxValue;
        //            }
        //            else
        //            {
        //                tdate = toDate.GetValueOrDefault();
        //                tdate = tdate.AddDays(1).AddSeconds(-1);
        //            }
        //            CustomModel csmodel = new CustomModel();

        //            v = csmodel.GetCustomerServiceSummary(branchID).ToList();

        //            ReportParameterCollection reportParameters = new ReportParameterCollection();

        //            reportParameters.Add(new ReportParameter("rpFromDate", fromDate + ""));
        //            reportParameters.Add(new ReportParameter("rpToDate", toDate + ""));

        //            lr.SetParameters(reportParameters);

        //            rd = new ReportDataSource("DataSet1", v);
        //        }
        //        else if (reportOptions == "ServiceDetails")
        //        {

        //            string path = Path.Combine(Server.MapPath("~/Reports"), "DetailsReport.rdlc");
        //        if (System.IO.File.Exists(path))
        //        {
        //            lr.ReportPath = path;
        //        }

        //        List<VMServiceDetails> v = new List<VMServiceDetails>();

        //        if (fromDate == null)
        //        {
        //            fromDate = DateTime.MinValue;
        //        }
        //        else
        //        {
        //            fdate = fromDate.GetValueOrDefault();
        //            fdate = fdate.AddSeconds(-1);
        //        }
        //        if (toDate == null)
        //        {
        //            toDate = DateTime.MaxValue;
        //        }
        //        else
        //        {
        //            tdate = toDate.GetValueOrDefault();
        //            tdate = tdate.AddDays(1).AddSeconds(-1);
        //        }
        //        CustomModel csmodel = new CustomModel();

        //        v = csmodel.GetCustomerServiceDetails(CounterID,tokenID).ToList();

        //        ReportParameterCollection reportParameters = new ReportParameterCollection();

        //        reportParameters.Add(new ReportParameter("rpFromDate", fromDate + ""));
        //        reportParameters.Add(new ReportParameter("rpToDate", toDate + ""));

        //        lr.SetParameters(reportParameters);

        //        rd = new ReportDataSource("DataSet1", v);
        //    }






        //    lr.DataSources.Add(rd);

        //    string reportType = id;
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;



        //    string deviceInfo =

        //    "<DeviceInfo>" +
        //    "  <OutputFormat>" + id + "</OutputFormat>" +
        //    "</DeviceInfo>";

        //    Warning[] warnings;
        //    string[] streams;
        //    byte[] renderedBytes;

        //    renderedBytes = lr.Render(
        //        reportType,
        //        deviceInfo,
        //        out mimeType,
        //        out encoding,
        //        out fileNameExtension,
        //        out streams,
        //        out warnings);

        //    return File(renderedBytes, mimeType);
        //}
    }
}