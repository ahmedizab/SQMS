using qms.Models;
using qms.Utility;
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

        [Authorize(Roles = "Admin")]
        public JsonResult GetAdminDashboard()
        {
            var dashboardData = db.tblBranches.Select(b => new
            {
                branch_name = b.branch_name,
                tokens = b.tblTokenQueues.Count(),
                services = b.tblTokenQueues.SelectMany(s=>s.tblServiceDetails).Count()
            }).ToList();

            return Json(new { success = true, data = dashboardData }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Branch Admin")]
        public JsonResult GetBranchAdminDashboard()
        {
            SessionManager sm = new SessionManager(Session);

            var dashboardData = db.tblCounters.Where(c=>c.branch_id==sm.branch_id).Select(c => new
            {
                counter_no = c.counter_no,
                tokens = c.tblTokenQueues.Count(),
                services = c.tblTokenQueues.SelectMany(s => s.tblServiceDetails).Count()
            }).ToList();

            var statusData = db.tblServiceStatus.Select(ss => new
            {
                service_status = ss.service_status,
                tokens= ss.tblTokenQueues.Where(t=>t.branch_id==sm.branch_id).Count()
            }).ToList();

            return Json(new { success = true, data = dashboardData, statusData= statusData }, JsonRequestBehavior.AllowGet);
        }
    }
}