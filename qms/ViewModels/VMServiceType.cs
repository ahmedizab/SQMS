using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qms.ViewModels
{
    public class VMServiceType
    {
        public int service_sub_type_id { get; set; }
        public string service_type_name { get; set; }
        public string service_sub_type_name { get; set; }
        public int max_duration { get; set; }

    }
}