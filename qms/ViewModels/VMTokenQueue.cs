using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qms.ViewModels
{
    public class VMTokenQueue
    {
        public long token_id { get; set; }
        public int branch_id { get; set; }
        public string branch_name { get; set; }

        public int token_no { get; set; }
        public System.DateTime service_date { get; set; }
        public System.DateTime creation_time { get; set; }

        public short service_status_id { get; set; }
        public string service_status { get; set; }
        public string counter_no { get; set; }
        public string static_ip { get; set; }
        public string display_next { get; set; }


        [Required]
        [Display(Name = "Mobile No")]
        public string contact_no { get; set; }
    }
}