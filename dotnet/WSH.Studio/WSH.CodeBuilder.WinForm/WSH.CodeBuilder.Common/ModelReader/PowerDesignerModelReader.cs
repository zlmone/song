using System;
using System.Collections.Generic;
using System.Text;
using WSH.Pdm.Common;
using WSH.Common.Helper;
using System.Text.RegularExpressions;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common.Configuration;
using System.Linq;

namespace WSH.CodeBuilder.Common
{
    public class PowerDesignerModelReader : ModelReader
    {
        protected string FileName;
        public PowerDesignerModelReader(ProjectEntity project, string fileName)
            : base(project)
        {
            FileName = fileName;
        }
        protected IList<PdmTable> GetPdmTables()
        {
            PdmReader reader = new PdmReader(FileName);
            reader.InitData();
            IList<PdmTable> pdmTables = reader.Tables;
            DbType = reader.GetDbType().ToString();
            return pdmTables;
        }
        protected TableInfo GetTableInfo(PdmTable pdmTable) {
            if (pdmTable != null)
            {
                TableInfo table = new TableInfo();
                table.TableName = pdmTable.Code;
                table.Attr = StringHelper.DeleteEnd(pdmTable.Name, "表");
                table.Remark = pdmTable.Comment;
                if (pdmTable.Columns != null)
                {
                    foreach (PdmColumn pdmColumn in pdmTable.Columns)
                    {
                        ColumnInfo column = new ColumnInfo();
                        column.Field = pdmColumn.Code;
                        column.Display = pdmColumn.Name;
                        column.Remark = pdmColumn.Comment;
                        column.DataType = Regex.Replace(pdmColumn.DataType, @"\(\d*,?\d*\)", "").ToLower();
                        column.IsNullable = !pdmColumn.Mandatory;
                        column.DefaultValue = string.Empty;
                        column.Length = string.IsNullOrEmpty(pdmColumn.Length) ? 0 : Convert.ToInt32(pdmColumn.Length);
                        if (pdmColumn.IdEntity)
                        {
                            column.IsIdentity = true;
                            column.IsDataKey = true;
                        }
                        //设置主键
                        if (pdmTable.Keys != null)
                        {
                            var key = pdmTable.Keys.Where(o => o.Code.ToLower() == pdmColumn.Code.ToLower()).FirstOrDefault();
                            if (key != null)
                            {
                                column.IsDataKey = true;
                            }
                        }
                        table.Columns.Add(column);
                    }
                }
                return table;
            }
            return null;
        }

        #region 公共方法
        public List<TableInfo> GetTableInfos()
        {
            IList<PdmTable> pdmTables = GetPdmTables();
            List<TableInfo> tables = new List<TableInfo>();
            if (pdmTables != null)
            {
                foreach (PdmTable pdmTable in pdmTables)
                {
                    TableInfo table = GetTableInfo(pdmTable);
                    if (table != null)
                    {
                        tables.Add(table);
                    }
                }
            }
            return tables;
        }
        public override List<TableEntity> FillTables(List<string> tableNames)
        {
            IList<PdmTable> pdmTables = GetPdmTables();
            List<TableInfo> tables = new List<TableInfo>();
            if (pdmTables != null)
            {
                foreach (string tableName in tableNames)
                {
                    PdmTable pdmTable = pdmTables.Where(o => o.Code.ToLower() == tableName.ToLower()).FirstOrDefault();
                    TableInfo table = GetTableInfo(pdmTable);
                    if (table!=null)
                    {
                        tables.Add(table); 
                    }
                }
            }
            return ReaderTables(tables);
        }
        #endregion
    }
}
