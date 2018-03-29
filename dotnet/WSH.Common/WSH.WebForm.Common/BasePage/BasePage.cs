using System;
using System.Collections.Generic;
using System.Text;
using System.Web;


namespace WSH.WebForm.Common
{
   public class BasePage : System.Web.UI.Page
    {
        public bool IsParam(string key)
        {
            return !string.IsNullOrEmpty(Request.Params[key]);
        }
    }
}
