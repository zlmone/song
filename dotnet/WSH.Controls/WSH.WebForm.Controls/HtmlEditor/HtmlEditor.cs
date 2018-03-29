using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSH.Web.Common;
using WSH.Common.Helper;

namespace WSH.WebForm.Controls
{
    [DefaultProperty("Text")]
    [ParseChildren(true, "Text")]
    [ToolboxData("<{0}:HtmlEditor runat=server></{0}:HtmlEditor>")]
    public class HtmlEditor : WebControl
    {
        public override string ClientID
        {
            get
            {
                return this.ID;
            }
        }
        private string text;
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public string Text
        {
            get { return string.IsNullOrEmpty(text) ? HttpContext.Current.Request.Form[this.ClientID] : text; }
            set { text = value; }
        }
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Textarea;
            }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            writer.AddAttribute("name", this.ClientID);
            writer.AddAttribute("value", text);
            base.Render(writer);
        }
        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);
            writer.WriteLine(WebConsts.ScriptBegin);
            writer.WriteLine("song.htmlEditor.create('"+ClientID+"');");
            writer.WriteLine(WebConsts.ScriptEnd);
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            base.RenderContents(writer);
            writer.Write(this.text);
        }
       
    }
}
