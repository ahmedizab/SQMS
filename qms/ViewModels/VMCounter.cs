using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qms.ViewModels
{
    public class VMCounter
    {
        public int counter_id { get; set; }
        public int branch_id { get; set; }

        public string branch_name { get; set; }
        public string counter_no { get; set; }

        public string location { get; set; }

    }
}