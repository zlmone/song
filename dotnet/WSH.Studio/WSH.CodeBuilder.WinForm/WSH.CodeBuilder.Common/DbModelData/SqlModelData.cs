using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.CodeBuilder.Common
{
    public class SqlModelData : DbModelData
    {
        public SqlModelData(string connectionString)
            : base(DataBaseType.SqlServer, connectionString)
        {
        }
        /// <summary>
        /// 查询指定表的字段信息
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public override List<ColumnInfo> GetColumns(string tableName)
        {
            string sql = @"SELECT 
            c.colorder AS Seqno,
            c.name as Field,
            ISNULL(g.[value], '') AS Display,
            t.name as DataType,
            cast(COLUMNPROPERTY(c.id, c.name, 'IsIdentity') as bit) AS IsIdentity,
            CAST(CASE WHEN EXISTS	
		            (SELECT 1
			            FROM dbo.sysindexes si INNER JOIN
				            dbo.sysindexkeys sik ON si.id = sik.id AND si.indid = sik.indid INNER JOIN
				            dbo.syscolumns sc ON sc.id = sik.id AND sc.colid = sik.colid INNER JOIN
				            dbo.sysobjects so ON so.name = si.name AND so.xtype = 'PK'
			            WHERE sc.id =c.id AND sc.colid = c.colid) THEN 1 ELSE 0 END AS bit) AS IsDataKey,
            c.length as Length,
            COLUMNPROPERTY(c.id, c.name, 'PRECISION') AS Precision,
            ISNULL(COLUMNPROPERTY(c.id, c.name, 'Scale'), 0) AS Scale,
            Cast(c.isnullable AS bit) as IsNullable,
            ISNULL(d.text,'') as DefaultValue
            FROM syscolumns c 
            inner join systypes t on(c.xusertype = t.xusertype)  
            left join syscomments d on(c.cdefault=d.id)
            LEFT OUTER JOIN sys.extended_properties g ON c.id = g.major_id AND c.colid = g.minor_id
            where c.id = object_id('" + tableName+@"')";
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
            string sql = @"SELECT  c.name Field,t.name DataType FROM SysColumns c
                        left join systypes t on(c.xusertype = t.xusertype)
                        WHERE id=Object_Id('" + tableName + @"') 
                        and colid in(select  keyno from sysindexkeys where id=Object_Id('" + tableName + @"'))";
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
                        typeName = "V";
                        break;
                    case DbListType.SystemTable:
                        typeName = "S";
                        break;
                    case DbListType.Procedure:
                        typeName = "P";
                        break;
                    default:
                        typeName = "U";
                        break;
                }
                string last = i == type.Length - 1 ? "" : "and";
                filter += string.Format(" xtype='{0}' {1}", typeName, last);
            }
            string sql = "Select name FROM SysObjects Where " + filter + " order by Name ";
            DataTable dt = db.GetDataTable(sql);
            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["name"].ToString());
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
