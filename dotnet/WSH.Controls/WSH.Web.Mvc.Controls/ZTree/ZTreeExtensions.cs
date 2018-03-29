using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WSH.Common;

namespace WSH.Web.Mvc.Controls
{
    public static class ZTreeExtensions
    {
       public static MvcHtmlString ZTree(this HtmlHelper helper,string id) {
           return MvcHtmlString.Create("<ul class=\"ztree\" id=\""+id+"\"></ul>");
       }
       public static MvcHtmlString ZTree(this HtmlHelper helper)
       {
           string id = "tree";
           return ZTree(helper, id);
       }
 
       

    }
}
