using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qms.Models
{
    [MetadataType(typeof(ServiceSubTypeMeta))]
    public partial class tblServiceSubType
    {
    }

    public class ServiceSubTypeMeta
    {
        [Display(Name ="Service Type")]
        [Required]
        public int service_type_id { get; set; }

        [Display(Name = "Service Name")]
        [Required]
        [StringLength(100)]
        public string service_sub_type_name { get; set; }

        [Display(Name = "Duration (Minuites)")]
        [Required]
        public int max_duration { get; set; }
        
    }
}