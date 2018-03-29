using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.CodeBuilder.Common
{
    public class TableInfo
    {
        public TableInfo() {
            Columns = new List<ColumnInfo>();
        }
        public string TableName { get; set; }
        public string Attr { get; set; }
        public string Remark { get; set; }

        public List<ColumnInfo> Columns { get; set; }
       
    }
}
