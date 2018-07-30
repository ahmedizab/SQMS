using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qms.Models
{
    [MetadataType(typeof(ServiceTypeMeta))]
    public partial class tblServiceType
    {
    }

    public class ServiceTypeMeta
    {
        [Display(Name ="ID")]
        [Required]
        public int service_type_id { get; set; }

        [Display(Name = "Type Name")]
        [Required]
        [StringLength(150)]
        public string service_type_name { get; set; }

    }
}