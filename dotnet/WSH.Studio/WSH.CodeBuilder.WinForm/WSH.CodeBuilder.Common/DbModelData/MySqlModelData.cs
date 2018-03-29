using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.CodeBuilder.Common
{
    public class MySqlModelData : DbModelData
    {
        public MySqlModelData(string connectionString)
            : base(DataBaseType.MySql, connectionString)
        {
        }
        /// <summary>
        /// 查询指定表的字段信息
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public override List<ColumnInfo> GetColumns(string tableName)
        {
            string sql = @"select 
[Field],
[Type] as DataType,
[Null] as IsNullable
(case Key WHEN 'PRI' THEN 1 ELSE 0 END) IsDataKey 
[Default] as DefaultValue
[Extra] as Display 
from (desc " + tableName + @")";
            DataTable dt = db.GetDataTable(sql);
            return ConvertHelper.ToList<ColumnInfo>(dt);
        }
        /// <summary>
        /// 获取数据库所有数据类型
        /// </summary>
        /// <returns></returns>
        public override List<string> GetDbTypes()
        {
            return new List<string>();
        }
        /// <summary>
        /// 查询指定表的主键名
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public override List<DataKeyInfo> GetDataKeys(string tableName)
        {
            string sql = @"";
            DataTable dt = db.GetDataTable(sql);
            return ToDataKeyList(dt);
        }
        /// <summary>
        /// 获取数据库所有表名，存储过程名，视图名
        /// </summary>
        /// <returns></returns>
        public override List<string> GetNames(params DbListType[] type)
        {
            string filter = string.Empty;
            for (int i = 0; i < type.Length; i++)
            {
                string typeName = string.Empty;
                switch (type[i])
                {
                    case DbListType.View:
                        filter+= "";
                        break;
                    case DbListType.SystemTable:
                        filter+= "select table_name from information_schema.TABLES where table_schema in('information_schema','mysql','performance_schema');union all ";
                        break;
                    case DbListType.Procedure:
                        filter += "";
                        break;
                    default:
                        filter += "select table_name from information_schema.tables where table_type='base table' and table_schema=database();union all ";
                        break;
                }
            }
            filter = StringHelper.DeleteEnd(filter,"union all ");
            DataTable dt = db.GetDataTable(filter);
            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row[0].ToString());
            }
            return list;
        }
        /// <summary>
        /// 生成插入数据的脚本
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isInsertDataKey"></param>
        /// <returns></returns>
        public override string CreateInsertScript(DataTable data, bool isInsertDataKey)
        {
            StringBuilder sb = new StringBuilder();
            if (isInsertDataKey)
            {
            }
            string sql = this.GetInsertScript(data);
            sb.AppendLine(sql);
            if (isInsertDataKey)
            {
            }
            return sb.ToString();
        }
        
    }
}
