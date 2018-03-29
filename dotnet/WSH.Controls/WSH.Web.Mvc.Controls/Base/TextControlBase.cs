using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Web.Mvc.Controls
{
    public class TextControlBase<T> : ControlBase<T>, ITextControl<T>
    {
        public TextControlBase() { }
        public TextControlBase(string id):base(id) { }
        public T Text(string text) {
            this.InnerHtml = text;
            return This();
        }
    }
}
