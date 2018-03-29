using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.CodeBuilder.Manager
{
    public class BaseManager
    {
        protected DbHelper db = new DbHelper(DataBaseType.SqlServer);

        protected string GetBoolValue(bool fieldValue) {
            return (fieldValue ? "1" : "0");
        }
    }
}
