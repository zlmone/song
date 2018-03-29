using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using WSH.Web.Common;
using WSH.WebForm.Common;

namespace WSH.WebForm.Controls
{
    [ParseChildren(false)]
    [ToolboxData("<{0}:FormPanel runat=server></{0}:FormPanel>")]
    public class FormPanel : WebControl
    {
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        private int columns=1;
        /// <summary>
        /// 每行显示的表单数
        /// </summary>
        [Description("每行显示的表单数")]
        [DefaultValue(1)]
        public int Columns
        {
            get {return columns; }
            set { columns = value;}
        }
        private int labelWidth = 80;
        /// <summary>
        /// 表单内文本的宽度
        /// </summary>
        [Description("表单内文本的宽度")]
        [DefaultValue(80)]
        public int LabelWidth
        {
            get { return labelWidth; }
            set { labelWidth = value; }
        }
        //private string formWidth;
        ///// <summary>
        ///// 表单的宽度,可写js脚本
        ///// </summary>
        //[Description("表单的宽度,可写js表示宽度")]
        //public string FormWidth
        //{
        //    get { return formWidth; }
        //    set { formWidth = value; }
        //}
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            Css.AddClass(this,"form-panel");
            writer.AddAttribute("columns",Columns.ToString());
            writer.AddAttribute("labelWidth",LabelWidth.ToString());
            base.AddAttributesToRender(writer);
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            //添加表单布局脚本
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("");
            //sb.AppendLine("$(window).bind('load',function(){$(\"#" + this.ClientID + "\").formLayout({");
            //sb.Append("labelWidth: "+LabelWidth+", columns:"+Columns);
            //if(!string.IsNullOrEmpty(FormWidth)){
            //    sb.Append(",formWidth:"+FormWidth);
            //}
            //sb.AppendLine("");
            //sb.AppendLine("});");
            Script.AddScript(this.Page,"LayoutJs",ClientResourceUrl.LayoutJs);
            //Script.RegisterStartupScript(this.Page,"FormPanel-"+this.ID,sb.ToString());
        }
    }
}
