using qms.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qms.Models
{
    [MetadataType(typeof(TokenQueueMeta))]
    public partial class tblTokenQueue
    {
        //public int duration
        //{
        //    get
        //    {
        //        return (end_time.Value - start_time);
        //        return 0;
        //    }
        //}

        public string tokenNoFormated
        {
            get
            {
                return token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0');
            }
        }
    }

    public class TokenQueueMeta
    {

        [Display(Name = "Service Type")]
        [Required]
        public int service_type_id { get; set; }

        [Display(Name = "Contact No")]
        public string contact_no { get; set; }

        [Display(Name = "Token No")]
        [Required]
        public int token_no { get; set; }

        [Display(Name = "Service Date")]
        [Required]
        public System.DateTime service_date { get; set; }

        [Display(Name = "Service Status")]
        [Required]
        public short service_status_id { get; set; }

        [Display(Name = "Counter No")]
        public Nullable<int> counter_id { get; set; }

        [Display(Name = "User")]
        public string user_id { get; set; }

        [Display(Name = "Cancel Time")]
        public Nullable<System.DateTime> cancel_time { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual tblBranch tblBranch { get; set; }
        public virtual tblCounter tblCounter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblServiceDetail> tblServiceDetails { get; set; }
        public virtual tblServiceStatu tblServiceStatu { get; set; }
        public virtual tblServiceType tblServiceType { get; set; }


    }
}