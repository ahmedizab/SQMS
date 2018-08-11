using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qms.Models
{
    [MetadataType(typeof(DailyBreakMeta))]
    public partial class tblDailyBreak
    {
        public int? duration
        {
            get
            {
                if (end_time.HasValue)
                    return (end_time.Value - start_time).Minutes;
                else return null;

            }
        }



    }

    public class DailyBreakMeta
    {


        [Display(Name = "Break Type")]
        [Required]
        public int break_type_id { get; set; }

        [Display(Name = "User")]
        [Required]
        public string user_id { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:HH:mm}", NullDisplayText = "00:00")]
        public Nullable<System.DateTime> start_time { get; set; }

        [Display(Name = "End Time")]
        [DisplayFormat(ApplyFormatInEditMode =true, ConvertEmptyStringToNull =true, DataFormatString = "{0:HH:mm}", NullDisplayText ="00:00")]
        public Nullable<System.DateTime> end_time { get; set; }
        //public Long diffTicks = (end_time - start_time).Ticks;
        [Display(Name ="Remarks")]
        [StringLength(250)]
        public string remarks { get; set; }
        

    }
}