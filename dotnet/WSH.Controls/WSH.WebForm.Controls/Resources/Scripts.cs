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
    [ToolboxData("<{0}:Scripts runat=server></{0}:Scripts>")]
    public class Scripts : Control
    {
        private List<ScriptBase> items;
        [PersistenceMode( PersistenceMode.InnerDefaultProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<ScriptBase> Items
        {
            get { 
                if(items==null){
                    items = new List<ScriptBase>();
                }
                return items;
            }
            set { items = value; }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            foreach (ScriptBase item in Items)
            {
                item.Url+= item.Cache ? "?_cache=wsh" : "";
                writer.WriteLine(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>",item.Url));
            }
        }
    }
}
