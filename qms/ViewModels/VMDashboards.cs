using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qms.ViewModels
{
    public class VMDashboardAdmin
    {
        public string branch_name { get; set; }
        public int tokens { get; set; }
        public int services { get; set; }
    }

    public class VMDashboardBranchAdminCounters
    {
        public string counter_no { get; set; }
        public int tokens { get; set; }
        public int services { get; set; }
    }

    public class VMDashboardBranchAdminStatuses
    {
        public string service_status { get; set; }
        public int tokens { get; set; }
    }
}