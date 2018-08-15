using qms.BLL;
using qms.Models;
using qms.SignalRHub;
using qms.Utility;
using qms.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qms.Controllers
{
    public class ApiServiceController : Controller
    {
        //private qmsEntities db = new qmsEntities();
        private BLLDashboard db = new BLLDashboard();
        
        

        

        [HttpPost]
        public JsonResult GetServiceList(string securityToken)
        {
            try
            {
                ApiManager.ValidUserBySecurityToken(securityToken);
                BLLServiceType dbServiceType = new BLLServiceType();
                
                var serviceList = dbServiceType.GetAll().ToList();

                return Json(new { success = true, serviceList = serviceList }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }



        [HttpPost]
        public JsonResult GetAllBranches()
        {
            try
            {
                BLLBranch dbBranch = new BLLBranch();

                var List = dbBranch.GetAllBranch().ToList();

                return Json(new { success = true, branchList = List }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult GetTokenList(string securityToken)
        {
            try
            {
                AspNetUser user = ApiManager.ValidUserBySecurityToken(securityToken);

                VMBranchLogin branchUser = new BLLBranchUsers().GetAll().Where(w => w.UserName == user.UserName).FirstOrDefault();

                if (branchUser == null) throw new Exception("User is not assigned in any branch");

                BLLToken dbToken = new BLLToken();

                var tokenList = dbToken.GetByBranchId(branchUser.branch_id);

                return Json(new { success = true, tokenList = tokenList }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult GenerateNewToken(string mobile, int service_type_id, string securityToken)
        {
            try
            {
                AspNetUser user = ApiManager.ValidUserBySecurityToken(securityToken);

                VMBranchLogin branchUser = new BLLBranchUsers().GetAll().Where(w => w.UserName == user.UserName).FirstOrDefault();

                if (branchUser == null) throw new Exception("User is not assigned in any branch");

                tblTokenQueue tokenObj = new tblTokenQueue();
                tokenObj.branch_id = branchUser.branch_id;
                tokenObj.contact_no = mobile;
                tokenObj.service_type_id = service_type_id;
                new BLLToken().Create(tokenObj);

                //if (!String.IsNullOrEmpty(branch.static_ip))
                //    dm.CreateTextFile(branch.branch_id, branch.static_ip);

                NotifyDisplay.SendMessages(branchUser.branch_id, "", "");

                string token_id = tokenObj.token_id.ToString();
                string token_no = tokenObj.token_no_formated;
                string date = Convert.ToString(DateTime.Now);

                return Json(new { success = true, tokenNo = token_no }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult SendSMS(string mobile, string tokenNo, string securityToken)
        {
            string msgText = System.Configuration.ConfigurationManager.AppSettings.Get("msgText");
            try
            {
                ApiManager.ValidUserBySecurityToken(securityToken);
                BLLToken tokenManager = new BLLToken();

                tokenManager.SendSMS(mobile, string.Format(msgText, tokenNo));
                return Json(new { success = true, message = "SMS Saved Succesfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Admin")]
        public JsonResult GetAdminDashboard()
        {
            var dashboardData = db.GetAdminDashboard();

            return Json(new { success = true, data = dashboardData }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Branch Admin")]
        public JsonResult GetBranchAdminDashboard()
        {
            SessionManager sm = new SessionManager(Session);
            List<VMDashboardBranchAdminStatuses> statusData = new List<VMDashboardBranchAdminStatuses>();
            var dashboardData = db.GetBranchAdminDashboard(sm.branch_id, statusData);

           return Json(new { success = true, data = dashboardData, statusData= statusData }, JsonRequestBehavior.AllowGet);
        }
    }
}