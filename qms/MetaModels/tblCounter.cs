using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qms.Models
{
    [MetadataType(typeof(CounterMeta))]
    public partial class tblCounter
    {
    }

    public class CounterMeta
    {
        [Display(Name = "Counter No")]
        [Required]
        [StringLength(5)]
        public string counter_no { get; set; }

        [Display(Name = "Location")]
        [StringLength(250)]
        public string location { get; set; }

    }
}