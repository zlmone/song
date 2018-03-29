using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace WSH.WebForm.Common
{
    public class Script
    {
        public static string BeginTag {
            get { return "<script type=\"text/javascript\">"; }
        }
        public static string EndTag {
            get { return "</script>"; }
        }
        public static string HtmlLine {
            get { return "<br>"; }
        }
        public static string Line {
            get { return "\n\r"; }
        }
        //打印提示脚本
        public static void Alert(string ScriptString)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("alert('" + ScriptString + "');");
            sb.Append("</script>");
            HttpContext.Current.Response.Write(sb.ToString());
        }
        public static void Alert(Page page,string key, string ScriptString)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("alert('" + ScriptString + "');");
            sb.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(),key, sb.ToString());
        }
        //打印提示脚本后跳转页面
        public static void AlertLocation(string ScriptString, string url)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("alert('" + ScriptString + "');location=" + url);
            sb.Append("</script>");
            HttpContext.Current.Response.Write(sb.ToString());
        }
        public static void AlertLocation(Page page,string key, string ScriptString, string url)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("alert('" + ScriptString + "');location=" + url);
            sb.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), key, sb.ToString());
        }
        //打印自定义脚本
        public static void WriteScript(string ScriptString)
        {
            HttpContext.Current.Response.Write("<script>" + ScriptString + "</script>");
        }
        public static void WriteScript(Page page,string key, string ScriptString)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), key, "<script>" + ScriptString + "</script>");
        }
        /// <summary>
        /// 在页面注册引用的js脚本
        /// </summary>
        public static void RegisterScriptInclude(Page page, string key, string url)
        {
            if (!page.ClientScript.IsClientScriptIncludeRegistered(page.GetType(), key))
            {
                page.ClientScript.RegisterClientScriptInclude(key, page.ResolveUrl(url));
            }
        }
        /// <summary>
        /// 在页面注册一段js脚本
        /// </summary>
        public static void RegisterScriptBlock(Page page, string key, string script)
        { 
            if(!page.ClientScript.IsClientScriptBlockRegistered(key)){
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(Script.BeginTag + script + Script.EndTag);
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), key, sb.ToString());
            }
        }
        public static void RegisterScriptUrl(Page page,string key,string url) {
            if (!page.ClientScript.IsClientScriptBlockRegistered(key))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<script type=\"text/javascript\" src=\"" + page.ResolveUrl(url) + "\">" + Script.EndTag);
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), key, sb.ToString());
            }
        }
        public static void RegisterCssUrl(Page page, string key, string url)
        {
            if (!page.ClientScript.IsClientScriptBlockRegistered(key))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<link href=\"" + page.ResolveUrl(url) + "\" rel=\"stylesheet\" type=\"text/css\" />");
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), key,sb.ToString());
            }
        }
        /// <summary>
        /// 注册启动脚本t
        /// </summary>
        public static void RegisterStartupScript(Page page, string key, string script) {
            if (!page.IsStartupScriptRegistered(key))
            {
                StringBuilder sb=new StringBuilder ();
                sb.AppendLine(Script.BeginTag+ script+Script.EndTag);
                page.ClientScript.RegisterStartupScript(page.GetType(), key, sb.ToString());
            }
        }
        /// <summary>
        /// 在head区域添加js引用
        /// </summary>
        public static void AddScript(Page page, string key, string url) {
            if (page.Header.FindControl(key) == null)
            {
                HtmlGenericControl script = new HtmlGenericControl("script");
                script.ID = key;
                script.Attributes.Add("type", "text/javascript");
                script.Attributes.Add("src", page.ResolveUrl(url));
                page.Header.Controls.Add(script);
            }
        }
        /// <summary>
        /// 在head区域添加css引用
        /// </summary>
        public static void AddCss(Page page,string key,string url) {
            if (page.Header.FindControl(key) == null)
            {
                HtmlLink css = new HtmlLink();
                css.ID = key;
                css.Attributes.Add("type", "text/css");
                css.Attributes.Add("rel", "stylesheet");
                css.Attributes.Add("href", page.ResolveUrl(url));
                page.Header.Controls.Add(css);
            }
        }
        /// <summary>
        /// 在head区域添加一段js脚本块
        /// </summary>
        public static void AddScriptBlock(Page page, string key, string scriptContent) {
            if (page.Header.FindControl(key) == null)
            {
                HtmlGenericControl script = new HtmlGenericControl("script");
                script.ID = key;
                script.InnerHtml = scriptContent;
                script.Attributes.Add("type", "text/javascript");
                page.Header.Controls.Add(script);
            }
        }
    }
}
