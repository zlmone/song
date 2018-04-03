using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Common.Extend
{
    public static class ObjectExtend
    {
        public static bool isNull(this object obj)
        {
            return (obj == null || obj == DBNull.Value);
        }
     
        public static string toString(this object obj, string defaultValue="") {
            return obj.isNull() ? defaultValue : obj.ToString();
        }
    }
}
