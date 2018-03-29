using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.WebForm.Common
{
   public class Css
    {
       public static void AddClass(System.Web.UI.WebControls.WebControl control,string className) {
           if (string.IsNullOrEmpty(control.CssClass) || control.CssClass.IndexOf(className) == -1)
           {
               control.CssClass += " " + className;
           }
       }
    }
}
