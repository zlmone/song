using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.CodeBuilder.Common
{
    public class OracleModelData : DbModelData
    {
        public OracleModelData(string connectionString)
            : base(DataBaseType.Oracle, connectionString)
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
t.column_name as Field,
t.data_type as DataType,
t.data_length  as Length,
t.nullable  as IsNullable,
t.column_id  AS Seqno,
c.comments AS Display,   
(SELECT CASE WHEN t.column_name=m.column_name THEN 1 ELSE 0 END FROM DUAL) IsDataKey  
FROM user_tab_cols t, user_col_comments c, (select m.column_name from user_constraints s, user_cons_columns m   
    where lower(m.table_name)='" + tableName + @"' and m.table_name=s.table_name  
    and m.constraint_name=s.constraint_name and s.constraint_type='P') m  
WHERE lower(t.table_name)='" +tableName+@"'   
    and c.table_name=t.table_name   
    and c.column_name=t.column_name   
    and t.hidden_column='NO'   
order by t.column_id";
            
            DataTable dt = db.GetDataTable(sql);
            return ConvertHelper.ToList<ColumnInfo>(dt);
        }
        /// <summary>
        /// 获取数据库所有数据类型
        /// </summary>
        /// <returns></returns>
        public override List<string> GetDbTypes()
        {
            string sql = @"select name from systypes";
            DataTable dt = db.GetDataTable(sql);
            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["name"].ToString());
            }
            return list;
        }
        /// <summary>
        /// 查询指定表的主键名
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public override List<DataKeyInfo> GetDataKeys(string tableName)
        {
            string sql = @" ";
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
             
            string sql = " ";
            DataTable dt = db.GetDataTable(sql);
            List<string> list = new List<string>();
            
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
                sb.AppendLine("set identity_insert " + data.TableName + " on;");
            }
            string sql = this.GetInsertScript(data);
            sb.AppendLine(sql);
            if (isInsertDataKey)
            {
                sb.AppendLine("set identity_insert " + data.TableName + " off;");
            }
            return sb.ToString();
        }

    }
}
