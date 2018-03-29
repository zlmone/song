using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Tools.Internet
{
    class Utils
    {
        public static NSoup.Nodes.Element GetElementFirst(NSoup.Select.Elements els)
        {
            if (els == null || els.Count <= 0)
            {
                return null;
            }
            return els[0];
        }
        public static string GetAttr(NSoup.Nodes.Element el,string name) {
            if (el!=null) {
                return el.Attributes[name] ?? null;
            }
            return null;
        }
        public static string GetText(NSoup.Nodes.Element el) {
            return el==null ? null : el.Text();
        }
    }
}
