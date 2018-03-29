using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using WSH.Web.Common;
using System.Web.UI.Design;
using System.Drawing.Design;
using WSH.WebForm.Common;

namespace WSH.WebForm.Controls
{
    [ToolboxItem(false)]
    [ToolboxData("<{0}:ArtDialog runat=server></{0}:ArtDialog>")]
    [ParseChildren(true,"Content")]
    public class Dialog : Control
    {
        #region 属性集合
        private string content;
        /// <summary>
        /// 消息内容,文字或html文本
        /// </summary>
        [Description("消息内容,文字或html文本")]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content)]
        [PersistenceMode( PersistenceMode.InnerDefaultProperty)]
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private string url;
        /// <summary>
        /// 打开的页面地址
        /// </summary>
        [Description("打开的页面地址")]
        [Editor(typeof(UrlEditor), typeof(UITypeEditor))]
        [UrlProperty(WebConsts.PageFilter)]
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private string title;
        /// <summary>
        /// 标题内容
        /// </summary>
        [Description("标题内容")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        #endregion
        protected override void OnPreRender(EventArgs e)
        {
            CreateDialogScript();
            base.OnPreRender(e);
        }
        private void CreateDialogScript()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("var "+this.ID+"=$.dialog({");
            sb.AppendFormat("id:'{0}'",this.ID);
            sb.AppendFormat(",content:'{0}'",(string.IsNullOrEmpty(url) ? Content : "url:"+Url));
            sb.Append("});");
            Script.AddCss(this.Page,"LHGDialogCss",ClientResourceUrl.LHGDialogCss);
            Script.AddScript(this.Page,"LHGDialogJs",ClientResourceUrl.LHGDialogJs);
            Script.RegisterStartupScript(this.Page,"LHGDialog-"+this.ID,sb.ToString());
        }
    }
}
