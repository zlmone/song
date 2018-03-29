using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI;

namespace WSH.WebForm.Controls
{
    [ToolboxItem(false)]
    [ParseChildren(true, "Text")]
    [PersistChildren(false)]
    public class ToolbarText : ToolbarItem, ITextControl
    {
        private string text=string.Empty;
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }
    }
}
