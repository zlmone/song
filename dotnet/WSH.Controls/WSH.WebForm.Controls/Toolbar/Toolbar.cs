using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSH.Web.Common;
using System.ComponentModel.Design;
using System.Drawing.Design;
using WSH.Common;
using WSH.WebForm.Common;
using WSH.Web.Common.Helper;

namespace WSH.WebForm.Controls
{
    [ParseChildren(true, "Items")]
    [PersistChildren(false)]
    [ToolboxData("<{0}:Toolbar runat=server></{0}:Toolbar>")]
    public class Toolbar : WebControl
    {
        //private static string HtmlTemplate = "<table class=\"toolbar\"></table>";
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        private List<ToolbarItem> items;
        /// <summary>
        /// 菜单项集合
        /// </summary>
        [Description("菜单项集合")]
        [TypeConverter(typeof(CollectionConverter))]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public List<ToolbarItem> Items
        {
            get
            {
                if (items == null)
                {
                    items = new List<ToolbarItem>();
                }
                return items;
            }

        }
        protected string GetToolbarButtonData(ToolbarButton btn) {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("text:'"+btn.Text+"'");
            if (!string.IsNullOrEmpty(btn.IconUrl))
            {
                sb.AppendFormat(",icon:'{0}'", btn.IconUrl);
            }
            if (btn.Icon != Icons.None)
            {
                btn.IconClass = "icon-" + ClientHelper.GetEnum(btn.Icon);
            }
            if (!string.IsNullOrEmpty(btn.IconClass))
            {
                sb.AppendFormat(",iconClass:'{0}'", btn.IconClass);
            }
            if (!string.IsNullOrEmpty(btn.ID))
            {
                sb.AppendFormat(",id:'{0}'", btn.ID);
            }
            if (!string.IsNullOrEmpty(btn.OnClientClick))
            {
                sb.AppendFormat(",onClick:'{0}'", btn.OnClientClick);
            }
            if (!btn.Enabled)
            {
                sb.Append(",enabled:false");
            }
            if(btn.Menu!=null){
                this.Controls.AddAt(0,btn.Menu);                 
                sb.AppendFormat(",menu:song.getCmp('"+btn.Menu.ID+"')");
            }
            sb.Append("}");
            return sb.ToString();
        }

    
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine("$(function(){");
            sb.AppendLine("var "+this.ID+"=new song.toolbar({id:'" + this.ID + "',renderTo:'#"+this.ClientID+"'});");
            int count = Items.Count;
            if (count > 0)
            {
                sb.Append(this.ID + ".add(");
                for (int i = 0; i <count; i++)
                {
                    ToolbarItem item = Items[i];
                    if (item is Separator)
                    {
                        sb.Append("'-'");
                    }
                    else if (item is ToolbarText)
                    {
                        sb.Append("'" + ((ToolbarText)item).Text + "'");
                    }
                    else if (item is ToolbarButton)
                    {
                        ToolbarButton btn = item as ToolbarButton;
                        sb.Append(GetToolbarButtonData(btn));
                    }
                    else {
                  
                        if (item.Controls.Count > 0)
                        {
                            StringBuilder s = new StringBuilder();
                            for (int j = 0; j < item.Controls.Count; j++)
                            {
                                Control control = item.Controls[j];
                                string id = control.ClientID;
                                if (!string.IsNullOrEmpty(id))
                                {
                                    this.Controls.Add(control);
                                    j--;
                                    s.Append("song.dom('" + id + "'),");
                                }
                            }
                            string dom = s.ToString();
                            
                            if(dom.EndsWith(",")){
                                s.Remove(s.Length-1,1);
                            }
                            if (string.IsNullOrEmpty(dom))
                            {
                                sb.Append("''");
                            }
                            else
                            {
                                sb.Append(s.ToString());
                            }
                        }
                    }
                    if (i < count-1)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append(");");
            }
            sb.AppendLine("");
            sb.AppendLine("});");
           // Script.AddCss(this.Page, "ToolbarCss", ClientResourceUrl.ToolbarCss);
            //Script.AddScript(this.Page, "ToolbarJs", ClientResourceUrl.ToolbarJs);
            Script.RegisterStartupScript(this.Page, "Toolbar-" + this.ID, sb.ToString());
        }
    }
}
