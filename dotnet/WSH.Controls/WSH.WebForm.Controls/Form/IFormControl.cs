using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace WSH.WebForm.Controls
{
    public interface IFormControl
    {
        bool IsFormControl { get; set; }
        bool FullColumn { get; set; }
        int ColumnSpan { get; set; }
        bool Required { get; set; }
    }
}
