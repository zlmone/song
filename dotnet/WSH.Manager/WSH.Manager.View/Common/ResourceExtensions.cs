using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSH.Web.Mvc.Controls;
using System.Text;

namespace WSH.Web.Mvc.Controls
{
    public enum ResourceType
    {
        HtmlEditor,
        Uploadify,
        ZTree,
        Dialog,
        DatePicker,
        NumberBox,
        Pager
    }
    public static class ResourceExtensions
    {
        /// <summary>
        /// 引入js和css文件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="urls"></param>
        /// <returns></returns>
        public static MvcHtmlString Resource(this HtmlHelper helper, params string[] urls)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string url in urls)
            {
                string absUrl = UrlHelper.GenerateContentUrl(url, helper.ViewContext.HttpContext);
                if (System.IO.Path.GetExtension(absUrl).ToLower().EndsWith(".css"))
                {
                    sb.AppendLine(string.Format("<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\" />", absUrl));
                }
                else
                {
                    sb.AppendLine(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", absUrl));
                }
            }
            return MvcHtmlString.Create(sb.ToString());
        }

        /// <summary>
        /// 引入js组件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MvcHtmlString Resource(this HtmlHelper helper, ResourceType type)
        {
            switch (type)
            {
                case ResourceType.HtmlEditor:
                    return Resource(helper,
                        "~/Scripts/kindeditor/themes/default/default.css",
                        "~/Scripts/kindeditor/kindeditor-all-min.js",
                        "~/Scripts/kindeditor/zh_CN.js");
                case ResourceType.Uploadify:
                    return Resource(helper,
                        "~/Styles/fileType-16.16.css",
                        "~/Scripts/uploadify/uploadify.css",
                        "~/Scripts/uploadify/jquery.uploadify.min.js",
                        "~/Scripts/song/song.upload.js");
                case ResourceType.ZTree:
                    break;
                case ResourceType.Dialog:
                    return Resource(helper,
                        "~/Scripts/artdialog/skins/blue.css",
                        "~/Scripts/artdialog/jquery.artDialog.js",
                        "~/Scripts/artdialog/iframeTools.js");
                case ResourceType.DatePicker:
                    return Resource(helper,
                        "~/Scripts/datepicker/WdatePicker.js");
                case ResourceType.NumberBox:
                    return Resource(helper,"~/Scripts/song/song.numberbox.js");
                case ResourceType.Pager:
                    return Resource(helper,"~/Styles/song.pager.css","~/Scripts/song/song.pager.js");
            }
            return MvcHtmlString.Create(string.Empty);
        }
    }
}