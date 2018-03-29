using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.ComponentModel.Design;
using System.Drawing.Design;
using WSH.Web.Common;
using WSH.WebForm.Common;
 

namespace WSH.WebForm.Controls
{
    [ParseChildren(true,"Items")]
    [ToolboxData("<{0}:ContextMenu runat=server></{0}:ContextMenu>")]
    public class ContextMenu : Control
    {
        private List<MenuItem> items;
        /// <summary>
        /// 菜单项集合
        /// </summary>
        [Description("菜单项集合")]
        [TypeConverter(typeof(CollectionConverter))]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public List<MenuItem> Items
        {
            get
            {
                if (items == null)
                {
                    items = new List<MenuItem>();
                }
                return items;
            }
        }
        private int width=120;
        [Description("菜单的宽度")]
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private string targetClientID;
        [Description("要绑定右键菜单项的元素客户端ID")]
        public string TargetClientID
        {
            get { return targetClientID; }
            set { targetClientID = value; }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine("new song.contextmenu({id:'"+this.ID+"',el:'#"+this.TargetClientID+"'");
            sb.AppendLine(",width:"+Width);
            if(Items.Count>0){
                sb.AppendLine(",items:"+MenuMgr.GetMenuData(Items));
            }
            sb.AppendLine("});");
            //Script.AddCss(this.Page,"MenuCss",ClientResourceUrl.MenuCss);
            //Script.AddScript(this.Page, "MenuJs", ClientResourceUrl.MenuJs);
            Script.RegisterStartupScript(this.Page, "ContextMenu-" + this.ID, sb.ToString());
        }
    }
}
