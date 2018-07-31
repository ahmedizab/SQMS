using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qms.ViewModels
{
    public class VMSessionInfo
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string role_name { get; set; }
        public int branch_id { get; set; }
        public string branch_name { get; set; }
        public string branch_static_ip { get; set; }
    }
}