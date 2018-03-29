using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using WSH.Common;

namespace WSH.Web.Mvc.Controls.EasyUI
{
    public class EasyCheckColumn : EasyColumn
    {
        public EasyCheckColumn()
        {
            this.CheckBox = true;
            this.Align = AlignType.Center;
            this.Width = 35;
            this.Resizable = false;
           // this.Sortable = false;
        }
    }
}
