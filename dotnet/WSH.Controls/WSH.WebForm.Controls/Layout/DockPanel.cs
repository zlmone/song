using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSH.Web.Common;
using WSH.WebForm.Common;

namespace WSH.WebForm.Controls
{
    [ParseChildren(true,"Items")]
    [ToolboxData("<{0}:DockPanel runat=server></{0}:DockPanel>")]
    public class DockPanel : WebControl
    {
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        private List<DockItem> items;
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content)]
        [PersistenceMode( PersistenceMode.InnerDefaultProperty)]
        public List<DockItem> Items
        {
            get {
                if(items==null){
                    items = new List<DockItem>();
                }
                return items; }
            set { items = value; }
        }
        private bool isViewport = false;
        /// <summary>
        /// 是否充满整个视区
        /// </summary>
        [Description("是否充满整个视区")]
        public bool IsViewport
        {
            get { return isViewport; }
            set { isViewport = value; }
        }
        public override string ClientID
        {
            get
            {
                return this.ID;
            }
        }
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            Css.AddClass(this,"dock-panel");
            if(IsViewport){
                Css.AddClass(this,"viewport");
            }
            base.AddAttributesToRender(writer);
        }
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            foreach (DockItem  item in Items)
            {
                this.Controls.Add(item);
            }
            this.ChildControlsCreated = true;
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            //添加表单布局脚本
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("");
            //sb.AppendLine("$(\"#" + this.ClientID + "\").dockPanel();");
            //Script.AddScript(this.Page, "LayoutJs", ClientResourceUrl.LayoutJs);
           // Script.RegisterStartupScript(this.Page, "DockPanel-" + this.ID, sb.ToString());
        }
    }
}
