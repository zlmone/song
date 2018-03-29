using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WSH.Web.Mvc.Controls
{
    public static class HtmlEditorExtensions
    {
        /// <summary>
        /// Html编辑器
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MvcHtmlString HtmlEditor(this HtmlHelper helper,string id,EditorOptions options) {
            if(options==null){
                options=new EditorOptions ();
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("<textarea id=\"{0}\" style=\"height:{1}; width:{2};\" name=\"{3}\"></textarea>",
                id,
                options.Height,
                options.Width,
                id));
            sb.AppendLine("<script type=\"text/javascript\">");
            sb.AppendLine(" $(function () {");
            sb.AppendLine("     song.htmlEditor.create(\""+id+"\", {");

            sb.AppendLine("     });");
            sb.AppendLine(" });");
            sb.AppendLine("</script>");
            return MvcHtmlString.Create(sb.ToString());
        }
    }
    public class EditorOptions {
        public EditorOptions() {
            Width = "100%";
            Height = "100px";
        }
        public string Width { get; set; }
        public string Height { get; set; }


    }
}
