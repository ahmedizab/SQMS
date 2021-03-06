﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using qms.Utility;


namespace qms.ViewModels
{
    public class VMNextToken
    {
        public string static_ip { get; set; }

        public int display_next { get; set; }
        public long token_no { get; set; }
        public string token_no_formated
        {
            get
            {
                return token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0');
            }
        }
    }
}