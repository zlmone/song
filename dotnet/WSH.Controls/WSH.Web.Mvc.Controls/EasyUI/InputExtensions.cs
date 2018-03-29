using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WSH.Web.Mvc.Common;
using WSH.Web.Common;
using WSH.Web.Common.Helper;

namespace WSH.Web.Mvc.Controls.EasyUI
{
    public static class InputExtensions
    {
        public static MvcHtmlString InputBox(this HtmlHelper helper, string name, string value)
        {
            return InputBox(helper, name, value, null, null);
        }
        public static MvcHtmlString InputBox(this HtmlHelper helper, string name, string value, ValidOptions valid)
        {
            return InputBox(helper,name,value,valid,null);
        }
        public static MvcHtmlString InputBox(this HtmlHelper helper, string name, string value, ValidOptions valid, object htmlAttributes)
        {
            IDictionary<string, object> dic = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            ClientHelper.AddAttr(dic, "class", "textbox easyui-validatebox");
            if (valid != null)
            {
                if (valid.Required)
                {
                    ClientHelper.AddAttr(dic, "required", "true");
                }
                if (valid.ValidType.HasValue)
                {
                    string vt = valid.ValidType.ToString().ToLower();
                    switch (valid.ValidType)
                    {
                        case ValidType.Length: vt = vt + "[" + valid.Length + "]"; break;
                        case ValidType.Remote: vt = vt + "[" + valid.Remote + "]"; break;
                    }
                    ClientHelper.AddAttr(dic, "validType", vt);
                }
            }
            return helper.TextBox(name, value,dic);
        }
    }
    public enum ValidType
    {
        Email,
        Url,
        Length,
        Remote
    }
    public class ValidOptions
    {
        /// <summary>
        /// 验证类型
        /// </summary>
        public ValidType? ValidType { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public string Length { get; set; }
        /// <summary>
        /// 远程地址
        /// </summary>
        public string Remote { get; set; }
        /// <summary>
        /// 是否必填
        /// </summary>
        public bool Required { get; set; }
    }
}
