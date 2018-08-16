using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qms.ViewModels
{
    public class VMDailyBreak
    {
        public int daily_break_id { get; set; }

        [Display(Name = "Branch Name")]
        public string branch_name { get; set; }

        [Display(Name = "Counter No")]
        public string counter_no { get; set; }

        [Display(Name = "User Name")]
        public string user_full_name { get; set; }

        [Display(Name = "Break Type")]
        public string break_type_name { get; set; }

        [Display(Name = "Start Time")]
        public DateTime? start_time { get; set; }

        [Display(Name = "End Time")]
        public DateTime? end_time { get; set; }

        [Display(Name = "Remarks")]
        public string remarks { get; set; }

        [Display(Name = "Duration")]
        public string duration
        {
            get
            {
                if (end_time.HasValue && start_time.HasValue)
                    return end_time.Value.Subtract(start_time.Value).ToString();
                else return "";

            }
        }
    }
}