using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WSH.CodeBuilder.Entity;
using WSH.Common.Helper;

namespace WSH.CodeBuilder.Manager
{
    public class ColumnManager : BaseManager
    {
        private string GetSelectSql(string tableID) {
            string sql = string.Format("select * from [Column] where TableID=" + tableID+" order by SortID asc");
            return sql;
        }
        public DataTable GetDataTable(string tableID) {
            return db.GetDataTable(GetSelectSql(tableID));
        }
        public List<ColumnEntity> GetList(string tableID) {
            return ConvertHelper.ToList<ColumnEntity>(this.GetDataTable(tableID));
        }
        public bool UpdateList(DataTable dt,string tableID) {
            return db.UpdateDataTable(dt, GetSelectSql(tableID));
        }
        public int Add(ColumnEntity entity) {
            return db.ExecuteAdd(GetAddSql(entity), new List<Paramter>() { 
                new Paramter(){DbType= DbType.String, ParamterName="@DefaultValue", Value=entity.DefaultValue}
            });
        }
        public bool Update(ColumnEntity entity) {
            return db.ExecuteNonQuery(GetUpdateSql(entity), new List<Paramter>() { 
                new Paramter(){DbType= DbType.String, ParamterName="@DefaultValue", Value=entity.DefaultValue}
            });
        }
        public string GetAddSql(ColumnEntity entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("insert into [Column](");
            sb.AppendLine("[TableID],");
            sb.AppendLine("[Field],");
            sb.AppendLine("[Display],");
            sb.AppendLine("DataType,");
            sb.AppendLine("Length,");
            sb.AppendLine("Precision,");
            sb.AppendLine("IsDataKey,");
            sb.AppendLine("EditorType,");
            sb.AppendLine("Sortable,");
            sb.AppendLine("Queryable,");
            sb.AppendLine("Hidden,");
            sb.AppendLine("Required,");
            sb.AppendLine("[Width],");
            sb.AppendLine("FormatString,");
            sb.AppendLine("DefaultValue,");
            sb.AppendLine("Align,");
            sb.AppendLine("SortID,");
            sb.AppendLine("[Enabled]");
            sb.AppendLine(") values(");
            sb.AppendLine(""+entity.TableID+",");
            sb.AppendLine("'" + entity.Field + "',");
            sb.AppendLine("'" + entity.Display + "',");
            sb.AppendLine("'" + entity.DataType.ToString() + "',");
            sb.AppendLine("" + entity.Length + ",");
            sb.AppendLine("" + entity.Precision + ",");
            sb.AppendLine("" + GetBoolValue(entity.IsDataKey) + ",");
            sb.AppendLine("'" + entity.EditorType.ToString() + "',");
            sb.AppendLine("" + GetBoolValue(entity.Sortable) + ",");
            sb.AppendLine("" + GetBoolValue(entity.Queryable) + ",");
            sb.AppendLine("" + GetBoolValue(entity.Hidden) + ",");
            sb.AppendLine("" + GetBoolValue(entity.Required) + ",");
            sb.AppendLine("" + entity.Width + ",");
            sb.AppendLine("'" + entity.FormatString + "',");
            sb.AppendLine("@DefaultValue,");
            sb.AppendLine("'" + entity.Align + "',");
            sb.AppendLine("" + entity.SortID + ",");
            sb.AppendLine("" + GetBoolValue(entity.Enabled) + "");
            sb.AppendLine(");");
            string sql = sb.ToString();
            return sql;
        }
        public string GetUpdateSql(ColumnEntity entity) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("update [Column] set ");
            sb.AppendLine("[TableID]="+entity.TableID+",");
            sb.AppendLine("[Field]='" + entity.Field + "',");
            sb.AppendLine("[Display]='" + entity.Display + "',");
            sb.AppendLine("DataType='" + entity.DataType.ToString() + "',");
            sb.AppendLine("Length=" + entity.Length + ",");
            sb.AppendLine("Precision=" + entity.Precision + ",");
            sb.AppendLine("IsDataKey=" + GetBoolValue(entity.IsDataKey) + ",");
            sb.AppendLine("EditorType='" + entity.EditorType.ToString() + "',");
            sb.AppendLine("Sortable=" + GetBoolValue(entity.Sortable) + ",");
            sb.AppendLine("Queryable=" + GetBoolValue(entity.Queryable) + ",");
            sb.AppendLine("Hidden=" + GetBoolValue(entity.Hidden) + ",");
            sb.AppendLine("Required=" + GetBoolValue(entity.Required) + ",");
            sb.AppendLine("[Width]=" + entity.Width + ",");
            sb.AppendLine("FormatString='" + entity.FormatString + "',");
            sb.AppendLine("DefaultValue=@DefaultValue,");
            sb.AppendLine("Align='" + entity.Align + "',");
            sb.AppendLine("SortID=" + entity.SortID + ",");
            sb.AppendLine("[Enabled]=" + GetBoolValue(entity.Enabled) + "");
            sb.AppendLine(" where ID="+entity.ID);
            string sql = sb.ToString();
            return sql;
        }
    }
}
