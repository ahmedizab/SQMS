using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qms.Models
{
    public class AspNetUserLogin
    {
        [Key]
        [StringLength(128)]
        public string LoginProvider { get; set; }

        [StringLength(128)]
        public string ProviderKey { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }


        public virtual AspNetUser AspNetUser { get; set; }
    }
}