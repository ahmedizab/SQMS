using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qms.ViewModels
{
    public class VM_Customer
    {
        public string customer_name { get; set; }
        public int customer_id { get; set; }

        public string contact_no { get; set; }
        public string address { get; set; }
        public string customer_type_name { get; set; }
    }
}