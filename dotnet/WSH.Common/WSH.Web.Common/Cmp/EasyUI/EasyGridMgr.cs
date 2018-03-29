using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Web.Common.EasyUI
{
    public class EasyGridMgr
    {
        public static string GetGridData(int total, string rows)
        {
            return "{\"total\":"+total+",\"rows\":" + rows + "}";
        }
    }
}
