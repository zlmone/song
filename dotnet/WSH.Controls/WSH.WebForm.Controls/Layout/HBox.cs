using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSH.Web.Common;
using WSH.WebForm.Common;
using WSH.Common;

namespace WSH.WebForm.Controls
{
    [ParseChildren(false)]
    [ToolboxData("<{0}:HBox runat=server></{0}:HBox>")]
    public class HBox : WebControl
    {
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        private AlignType align = AlignType.Center;
        /// <summary>
        /// 内容的对齐方式
        /// </summary>
        [Description("内容的对齐方式")]
        public AlignType Align
        {
            get { return align; }
            set { align = value; }
        }
        //private string boxWidth;
        ///// <summary>
        ///// 表单的宽度,可写js脚本
        ///// </summary>
        //[Description("表单的宽度,可写js表示宽度")]
        //public string BoxWidth
        //{
        //    get { return boxWidth; }
        //    set { boxWidth = value; }
        //}
        private int margin=15;
        /// <summary>
        /// 内容的边距，不包括上下边距
        /// </summary>
        [Description("内容的边距，不包括上下边距")]
        public int Margin
        {
            get { return margin; }
            set { margin = value; }
        }
         protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            Css.AddClass(this,"stack-panel");
            base.AddAttributesToRender(writer);
            writer.AddAttribute("align", WSH.Web.Common.Helper.ClientHelper.GetEnum(Align));
            writer.AddAttribute("margin",Margin.ToString());
        }
         protected override void OnPreRender(EventArgs e)
         {
             base.OnPreRender(e);
             //添加表单布局脚本
             //StringBuilder sb = new StringBuilder();
             //sb.AppendLine("");
             //sb.AppendLine("$(\"#" + this.ClientID + "\").hbox({");
             //sb.AppendFormat("align:\"{0}\"",Client.GetEnum(Align));
             //if (!string.IsNullOrEmpty(BoxWidth))
             //{
             //    sb.Append(",boxWidth:" + BoxWidth);
             //}
             //if (Margin>0)
             //{
             //    sb.Append(",margin:" + Margin);
             //}
             //sb.AppendLine("");
             //sb.AppendLine("});");
             Script.AddScript(this.Page, "LayoutJs", ClientResourceUrl.LayoutJs);
           //  Script.RegisterStartupScript(this.Page, "HBox-" + this.ID, sb.ToString());
         }
    }
}
