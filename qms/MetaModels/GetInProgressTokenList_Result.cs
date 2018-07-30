using qms.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qms.Models
{
    [MetadataType(typeof(GetInProgressTokenList_ResultrMeta))]
    public partial class GetInProgressTokenList_Result
    {
       public string token_no_with_pad
        {
            get
            {
                //SessionManager sm = new SessionManager(get)
                return token_no.PadLeft(3);
            }
        }
    }

    public class GetInProgressTokenList_ResultrMeta
    {
        [Display(Name = "Counter No")]
        [Required]
        [StringLength(5)]
        public string counter_no { get; set; }

        

    }
}