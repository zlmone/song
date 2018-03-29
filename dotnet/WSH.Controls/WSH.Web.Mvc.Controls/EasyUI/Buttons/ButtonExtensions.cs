using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WSH.Common;
using WSH.Web.Common;
using WSH.Common.Helper;
using System.Web.Mvc.Html;
using WSH.Web.Common.Helper;

namespace WSH.Web.Mvc.Controls.EasyUI
{
    public static class ButtonExtensions
    {
        public static MvcHtmlString ToolbarButton(this HtmlHelper helper,string text,string click,string icon=null,string id=null)
        {
            return Button(helper, text, new ButtonOptions() { 
                Icon=icon, OnClick=click,ID=id,Plain=true
            });
        }
        public static MvcHtmlString EasyButton(this HtmlHelper helper, string id)
        {
            return MvcHtmlString.Create("<a class=\"easyui-linkbutton\">新增</a>");
            //return new EasyButton(id);
        } 
        public static MvcHtmlString Button(this HtmlHelper helper, string text, Action<ButtonOptions> action)
        {

            ButtonOptions options = new ButtonOptions();
            if (action != null)
            {
                action(options);
            }
            HtmlBuilder tag = GetButtonBuilder(text, options);
            return MvcHtmlString.Create(tag.ToString());
        }
        public static MvcHtmlString Button(this HtmlHelper helper, string text)
        {
            return Button(helper, text, new ButtonOptions());
        }
        public static MvcHtmlString Button(this HtmlHelper helper, string text, ButtonOptions options)
        {
            return MvcHtmlString.Create(GetButtonBuilder(text, options).ToString());
        }
        private static HtmlBuilder GetButtonBuilder(string text, ButtonOptions options)
        {
            HtmlBuilder tag = new HtmlBuilder("a")
            {
                InnerHtml = text
            };
            tag.AddClass("easyui-linkbutton");
            SetButtonOptions(options, tag);
            return tag;
        }
        private static void SetButtonOptions(ButtonOptions options, HtmlBuilder builder)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("plain", ClientHelper.GetBool(options.Plain));
            if (!string.IsNullOrWhiteSpace(options.Icon))
            {
                dict.Add("iconCls", "icon-" + options.Icon);
            }
            if (dict.Count > 0)
            {
                builder.AddAttribute("data-options", DictHelper.ToJsonItem(dict));
            }
            if (!string.IsNullOrEmpty(options.Target))
            {
                builder.AddAttribute("target", options.Target);
            }
            if (!string.IsNullOrEmpty(options.Href))
            {
                builder.AddAttribute("href", options.Href);
            }
            if (!string.IsNullOrEmpty(options.OnClick))
            {
                builder.AddAttribute("onclick", options.OnClick);
            }
            if (!string.IsNullOrEmpty(options.ID))
            {
                builder.AddAttribute("id", options.ID);
            }
        }
    }
    public class ButtonOptions
    {
        public string ID { get; set; }
        public string Icon { get; set; }
        public string Href { get; set; }
        public string OnClick { get; set; }
        public string Target { get; set; }
        public bool Plain { get; set; }
    }

}
