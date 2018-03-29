using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using WSH.CodeBuilder.WinForm.Common;
using WSH.CodeBuilder.DispatchServers;
using WSH.CodeBuilder.Common;

namespace WSH.CodeBuilder.WinForm
{
    public class DataScriptManager 
    {
        //指定数据库脚本
        public static string GetUseScript(string dbName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("use " + dbName + "");
            sb.AppendLine("go");
            return sb.ToString();
        }
        //建表脚本-Tables
        public static string CreateTablesScript(string projectID)
        {
            Information.Clear();
            StringBuilder sb = new StringBuilder();
            try
            {
                CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
                ProjectEntity project = service.GetProjectById(projectID);
                TableEntity[] tables = service.GetTableList(projectID);
                for (int i = 0; i < tables.Length; i++)
                {
                    if (i == 0)
                    {
                        sb.Append(CreateTableScript(project, tables[i], true));
                    }
                    else
                    {
                        sb.Append(CreateTableScript(project, tables[i], false));
                    }
                    sb.AppendLine("");
                }
            }
            catch (Exception ex) {
                Information.AddFmt("创建表脚本出错，错误信息：{0}",ex.Message);
            }
            return sb.ToString();
        }
        //建表脚本-Table
        public static string CreateTableScript(ProjectEntity project, TableEntity table, bool isUse)
        {
            CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
            StringBuilder sb = new StringBuilder();
            try
            {
                if(project==null){
                    project = Global.GetCurrentProject();
                }
                ColumnEntity[] columns = service.GetColumnList(table.ID.ToString());
                //DataBaseType dataBaseType = DataBaseHelper.GetDbType(project.DbType);
                if (isUse) { sb.Append(GetUseScript(project.ProjectName)); }
                sb.AppendLine("--创建表：" + table.Attr);
                sb.AppendLine("if exists (select name from sysobjects where name='" + table.TableName + "')");
                sb.AppendLine("\tbegin");
                sb.AppendLine("\t\tprint '--温馨提示：" + table.TableName + "表已经存在，如需重新建表，请手动删除'");
                sb.AppendLine("\t\tprint 'drop table " + table.TableName + "'");
                sb.AppendLine("\tend");
                sb.AppendLine("else");
                sb.AppendLine("create table " + table.TableName);
                sb.AppendLine("(");
                for (int i = 0; i < columns.Length; i++)
                {
                    string last = i == columns.Length - 1 ? "" : ",";
                    ColumnEntity col = columns[i];
                    bool isPK = !string.IsNullOrEmpty(table.DataKey) && table.DataKey.ToLower() == col.Field.ToLower();
                    if (isPK)
                    {
                        string pkInfo = table.DataKeyType == WSH.CodeBuilder.DispatchServers.DataKeyType.Guid ? " varchar(40) primary key" : col.DataType + " primary key identity";
                        sb.AppendLine(string.Format("\t{0} {1}{2}--{3}", col.Field, pkInfo, last, col.Display));
                    }
                    else
                    {
                        string notNull = col.Required == false ? " not null" : "";
                        string isDefault = string.IsNullOrEmpty(col.DefaultValue) ? "" : " default " + col.DefaultValue;
                        string[] numbers = new string[] { "decimal", "numeric" };
                        string[] strings = new string[] { "nvarchar", "varchar", "char" };
                        string len = string.Empty;
                        if (Array.IndexOf(numbers, col.DataType) > -1)
                        {
                            len = "(18," + col.Length + ")";
                        }
                        else if (Array.IndexOf(strings, col.DataType) > -1)
                        {
                            len = "(" + col.Length + ")";
                        }
                        string dataType = DataTypeManager.GetLangDataType("sqlserver", col.DataType);
                        sb.AppendLine(string.Format("\t{0} {1}{2}{3}{4}--{5}", col.Field, (dataType + len), notNull, isDefault, last, col.Display));
                    }
                }
                sb.AppendLine(")");
            }
            catch (Exception ex) {
                Information.AddFmt("创建表脚本出错，错误信息：{0}",ex.Message);
            }
            return sb.ToString();
        }
    }
}
