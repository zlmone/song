using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSH.Web.Common;

namespace WSH.WebForm.Controls
{
    [ToolboxItem(false)]
    [ParseChildren(false)]
    [PersistChildren(true)]
    [ToolboxData("<{0}:DockItem runat=server Dock=Center></{0}:DockItem>")]
    public class DockItem : WebControl
    {
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        private DockType dock;
        /// <summary>
        /// 停靠的方向
        /// </summary>
        [Description("停靠的方向")]
        public DockType Dock
        {
            get { return dock; }
            set { dock = value; }
        }
        public override string ClientID
        {
            get
            {
                return this.ID;
            }
        }
        private string margin;
        /// <summary>
        /// 外边距
        /// </summary>
        [Description("外边距")]
        public string Margin
        {
            get { return margin; }
            set { margin = value; }
        }
        private string padding;
        /// <summary>
        /// 内边距
        /// </summary>
        [Description("内边距")]
        public string Padding
        {
            get { return padding; }
            set { padding = value; }
        }
        private string border;
        /// <summary>
        /// 边框
        /// </summary>
        [Description("边框")]
        public string Border
        {
            get { return border; }
            set { border = value; }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            if(!string.IsNullOrEmpty(Margin)){
                writer.AddStyleAttribute(HtmlTextWriterStyle.Margin, Margin);
            }
            if (!string.IsNullOrEmpty(Padding))
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Padding, Padding);
            }
            if (!string.IsNullOrEmpty(Border))
            {
                writer.AddStyleAttribute("border", Border);
            }
            writer.AddAttribute("dock",WSH.Web.Common.Helper.ClientHelper.GetEnum(Dock));
        }
    }
    public enum DockType {
        Top, Right, Bottom, Left,Center
    }
}
