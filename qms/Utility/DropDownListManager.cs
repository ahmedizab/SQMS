using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qms.Utility
{
    public class DropDownListManager
    {
        public static SelectList GetNameTitle(string SelectedValue = "")
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "Mr.", Text = "Mr." });
            list.Add(new SelectListItem { Value = "Mrs.", Text = "Mrs." });

            return new SelectList(list, "Value", "Text", SelectedValue);
        }
    }
}