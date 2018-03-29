using System.Collections.Generic;
using System.Web.Mvc;

namespace WSH.Manager.View
{
    public class WSHViewEngine : RazorViewEngine
    {
        // Fields
        internal static readonly string ViewStartFileName = "_ViewStart";

        // Methods
        public WSHViewEngine()
            : this(null)
        {
             
        }

        public WSHViewEngine(IViewPageActivator viewPageActivator)
            : base(viewPageActivator)
        {
            //Action找到View的规则
            var formmats = new List<string>
                             {
                                 "~/Views/{1}/{0}.cshtml",
                                 "~/Views/Shared/{0}.cshtml",
                                 "~/Views/Common/{1}/{0}.cshtml",
                                 "~/Views/Admin/{1}/{0}.cshtml",
                                 "~/Views/Modules/{1}/{0}.cshtml"
                             };

            ViewLocationFormats = formmats.ToArray();//View页面规则
            MasterLocationFormats = new[] { "~/Views/{1}/{0}.cshtml", "~/Views/Shared/{0}.cshtml" };//母版页的规则
            PartialViewLocationFormats = formmats.ToArray();//部分页面（用户控件）的规则

            FileExtensions = new[] { "cshtml", "vbhtml" };
 

        }
    }
}