using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.Design;
using System.Drawing.Design;
using WSH.Web.Common;
using WSH.WebForm.Common;

namespace WSH.WebForm.Controls
{
    [ParseChildren(true, "Items")]
    [ToolboxData("<{0}:Menu runat=server></{0}:Menu>")]
    public class Menu : Control
    {
        public Menu() { }
        private List<MenuItem> items;
        /// <summary>
        /// 菜单项集合
        /// </summary>
        [Description("菜单项集合")]
        [TypeConverter(typeof(CollectionConverter))]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content)]
        [PersistenceMode( PersistenceMode.InnerDefaultProperty)]
        public List<MenuItem> Items {
            get { 
                if(items==null){
                    items = new List<MenuItem>();
                }
                return items;
            }

        }
        private int width;
        [Description("菜单的宽度")]
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine("new song.menu({id:'" + this.ID + "'");
            if(width>0){
                sb.AppendLine(",width:" + Width);
            }
            if (Items.Count > 0)
            {
                sb.AppendLine(",items:" + MenuMgr.GetMenuData(Items));
            }
            sb.AppendLine("});");
            //Script.AddCss(this.Page, "MenuCss", ClientResourceUrl.MenuCss);
            //Script.AddScript(this.Page, "MenuJs", ClientResourceUrl.MenuJs);
            Script.RegisterStartupScript(this.Page, "Menu-" + this.ID, sb.ToString());
        }
    }
}
