using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace WSH.DataAccess.SongData
{
    public interface ISqlInfo
    {
        /// <summary>
        /// 表名/视图名/存储过程
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 当前生成的SQL语句
        /// </summary>
        StringBuilder Sql { get; }
        /// <summary>
        /// 当前生成的参数
        /// </summary>
        List<DbParameter> Parameters { get; }
    }
}
