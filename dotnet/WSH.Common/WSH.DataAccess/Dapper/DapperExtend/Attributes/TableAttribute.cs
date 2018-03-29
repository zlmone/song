using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.DataAccess.Dapper
{
    /// <summary>
    /// 数据库表
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TableAttribute : BaseAttribute
    {
        public TableAttribute(string name) {
            this.Name = name;
        }
        /// <summary>
        /// 别名，对应数据里面的名字
        /// </summary>
        public string Name { get; set; }
    }
}
