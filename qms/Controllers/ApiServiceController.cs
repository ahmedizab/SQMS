using qms.BLL;
using qms.Models;
using qms.Utility;
using qms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qms.Controllers
{
    public class ApiServiceController : Controller
    {
        //private qmsEntities db = new qmsEntities();
        private BLLDashboard db = new BLLDashboard();

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