using qms.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qms.ViewModels
{
    public class VMTokenSkipped
    {
        public long token_id { get; set; }
        public string branch_name { get; set; }
        public int token_no { get; set; }
        public string token_no_formated
        {
            get
            {
                return token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0');
            }
        }
        public System.DateTime service_date { get; set; }
        public int service_status_id { get; set; }
        public string service_status { get; set; }
        public string contact_no { get; set; }
        public string counter_no { get; set; }
        public string customer_name { get; set; }
        public string user_full_name { get; set; }
        public System.DateTime cancel_time { get; set; }
        
    }
}