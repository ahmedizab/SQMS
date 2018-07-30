using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qms.Models
{
    [MetadataType(typeof(AspNetUserMeta))]
    public partial class AspNetUser
    {
    }

    public class AspNetUserMeta
    {
        [Display(Name ="User")]
        [Required]
        public string Hometown { get; set; }

        
    }
}