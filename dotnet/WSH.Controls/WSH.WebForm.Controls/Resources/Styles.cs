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
    [ParseChildren(true, "Items")]
    [ToolboxData("<{0}:Styles runat=server></{0}:Styles>")]
    public class Styles : Control
    {
        private List<StyleBase> items;
        [PersistenceMode( PersistenceMode.InnerDefaultProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<StyleBase> Items
        {
            get { 
                if(items==null){
                    items = new List<StyleBase>();
                }
                return items;
            }
            set { items = value; }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            foreach (StyleBase item in Items)
            {
                item.Url+= item.Cache ? "?_cache=wsh" : "";
                writer.WriteLine(string.Format("<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\"/>", item.Url));
            }
        }
    }
}
