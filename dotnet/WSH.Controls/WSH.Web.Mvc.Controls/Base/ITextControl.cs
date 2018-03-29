using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Web.Mvc.Controls
{
    public interface ITextControl<T>
    {
        T Text(string text);
    }
}
