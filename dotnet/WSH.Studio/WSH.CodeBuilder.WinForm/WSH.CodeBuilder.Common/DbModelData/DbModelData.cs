using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.CodeBuilder.Common
{
    public enum DbListType
    {
        View, UserTable, SystemTable, Procedure
    }
    public abstract class DbModelData
    {
        public DbHelper db = null;
        public DbModelData(DataBaseType dbType, string connectionString)
        {
            db = new DbHelper(dbType, connectionString);
        }
        /// <summary>
        /// 查询指定表的字段信息【Field DataType Length Required DefaultValue...】
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public abstract List<ColumnInfo> GetColumns(string tableName);
        /// <summary>
        /// 获取数据库所有数据类型
        /// </summary>
        /// <returns></returns>
        public abstract List<string> GetDbTypes();
        /// <summary>
        /// 查询指定表的主键名
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public abstract List<DataKeyInfo> GetDataKeys(string tableName);

        /// <summary>
        /// 获取数据库所有表名，存储过程名，视图名
        /// </summary>
        /// <returns></returns>
        public abstract List<string> GetNames(params DbListType[] type);
        /// <summary>
        /// 生成插入数据的脚本
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isInsertDataKey"></param>
        /// <returns></returns>
        public abstract string CreateInsertScript(DataTable data, bool isInsertDataKey);
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool ImportData(DataTable dt, bool isInsertDataKey)
        {
            string sql = this.CreateInsertScript(dt, isInsertDataKey);
            return db.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 获取插入的数据脚本
        /// </summary>
        /// <returns></returns>
        protected virtual string GetInsertScript(DataTable data) {
            if(data==null || data.Rows.Count<=0){
                return null;
            }
            if (string.IsNullOrEmpty(data.TableName))
            {
                throw new Exception("生成Insert脚本时，DataTable表名不能为空");
            }
            StringBuilder sb = new StringBuilder();
            foreach (DataRow row in data.Rows)
            {
                string columns = "";
                string values = "";
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    DataColumn col = data.Columns[i];
                    columns += "[" + col.ColumnName + "]";
                    var typeName = col.DataType.Name.ToLower();
                    if (typeName.Contains("int") || typeName.Contains("bool"))
                    {
                        values += GetDbNullValue(row[col], false);
                    }
                    else
                    {
                        values += GetDbNullValue(row[col], true);
                    }
                    if (i < data.Columns.Count-1)
                    {
                        columns += ",";
                        values += ",";
                    }
                }
                string insert = "insert into [" + data.TableName + "](" + columns + ")values(" + values + ");";
                sb.AppendLine(insert);
            }
            return sb.ToString();
        }

        #region 私有方法
        protected List<DataKeyInfo> ToDataKeyList(DataTable dt)
        {
            List<DataKeyInfo> list = new List<DataKeyInfo>();
            foreach (DataRow row in dt.Rows)
            {
                DataKeyInfo entity = new DataKeyInfo(); 
                entity.DataType = row["DataType"].ToString();
                if (row["Field"] != null)
                {
                    entity.Field = row["Field"].ToString();
                }
                list.Add(entity);
            }
            return list;
        }
        protected string GetDbNullValue(object obj, bool isQuotes)
        {
            if (obj == DBNull.Value || obj == null)
            {
                return "NULL";
            }
            return isQuotes ? ("'" + obj.ToString() + "'") : obj.ToString();
        }
        #endregion
    }
}
