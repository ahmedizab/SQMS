using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qms.ViewModels
{
    public class VMNextToken
    {
        public string static_ip { get; set; }

        public int display_next { get; set; }
        public long token_no { get; set; }
    }
}