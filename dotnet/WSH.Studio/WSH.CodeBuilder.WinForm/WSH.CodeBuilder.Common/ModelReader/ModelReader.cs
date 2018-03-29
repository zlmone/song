using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using System.Linq;
using WSH.CodeBuilder.DispatchServers;


namespace WSH.CodeBuilder.Common
{
    public abstract class ModelReader
    {
        protected ProjectEntity Project;
        protected string DbType;
        public ModelReader() { }
        public ModelReader(ProjectEntity project)
        {
            Project = project;
        }
        /// <summary>
        /// 填充模型的错误信息
        /// </summary>
        public StringBuilder Error = new StringBuilder();

        public void ClearError()
        {
            this.Error = new StringBuilder();
        }
        /// <summary>
        /// 读取器插入数据连接
        /// </summary>
        protected CodeBuilderService service = ServiceHelper.GetCodeBuilderService();

        public abstract List<TableEntity> FillTables(List<string> tableNames);

        #region 读取器适配
        protected List<TableEntity> ReaderTables(List<TableInfo> tables)
        {
            List<TableEntity> entitys = new List<TableEntity>();
            foreach (TableInfo table in tables)
            {
                //检测表是否存在
                try
                {
                    TableEntity tableEntity = service.GetTableByName(Project.ID.ToString(), table.TableName);
                    if (tableEntity == null)
                    {
                        tableEntity = new TableEntity();
                    }
                    tableEntity.TableName = table.TableName;
                    tableEntity.Attr = table.Attr;
                    tableEntity.Remark = table.Remark;
                    tableEntity.ProjectID = Project.ID;
                    tableEntity.Enabled = true;
                    if (tableEntity.ID > 0)
                    {
                        service.UpdateTable(tableEntity);
                    }
                    else
                    {
                        tableEntity.ID = service.AddTable(tableEntity);
                    }
                    if (tableEntity.ID > 0)
                    {
                        entitys.Add(tableEntity);
                        ReaderColumns(tableEntity, table.Columns);
                    }
                }
                catch (Exception ex)
                {
                    Error.AppendLine("读取数据表—" + table.TableName + "出错！" + ex.Message);
                    continue;
                }
            }
            return entitys;
        }
        protected void ReaderColumns(TableEntity tableEntity, List<ColumnInfo> columns)
        {
            if (columns != null && columns.Count > 0)
            {
                ColumnEntity[] listColumns = service.GetColumnList(tableEntity.ID.ToString());
                int i = 0;
                foreach (ColumnInfo column in columns)
                {
                    i++;
                    try
                    {
                        //获取服务器字段信息
                        ColumnEntity columnEntity = listColumns.Where(o => o.Field == column.Field).FirstOrDefault();
                        if (columnEntity == null)
                        {
                            columnEntity = new ColumnEntity();
                        }
                        DataType dataType = DataTypeManager.ParseDbDataType(DbType, column.DataType.ToLower());
                        columnEntity.Field = column.Field;
                        columnEntity.DataType = dataType.ToString();
                        columnEntity.Required = !column.IsNullable;
                        columnEntity.DefaultValue = column.DefaultValue;
                        ModelReaderHelper.SetLength(columnEntity, dataType, column.Length, column.Precision);
                        ModelReaderHelper.SetColumnEditor(columnEntity, dataType);
                        if (columnEntity.ID <= 0)
                        {
                            //新增字段
                            columnEntity.SortID = i;
                            columnEntity.Display = string.IsNullOrEmpty(column.Display) ? column.Field : column.Display;
                            ModelReaderHelper.SetDefault(columnEntity);
                            columnEntity.TableID = tableEntity.ID;
                            ModelReaderHelper.SetFormatString(columnEntity, dataType);
                            
                            ModelReaderHelper.SetAlign(columnEntity, dataType);
                            //设置主键信息
                            if (column.IsDataKey)
                            {
                                ModelReaderHelper.SetColumnDataKey(columnEntity);
                                //更新表的主键信息
                                tableEntity.DataKey = column.Field;
                                tableEntity.DataKeyType = column.IsIdentity ?
                                    WSH.CodeBuilder.DispatchServers.DataKeyType.IdEntity :
                                    WSH.CodeBuilder.DispatchServers.DataKeyType.Guid;
                                tableEntity.DefaultSortName = column.Field;
                                tableEntity.DefaultSortMode = DispatchServers.SortMode.Asc;
                                service.UpdateTable(tableEntity);
                            }
                            columnEntity.CreateTime = DateTime.Now;
                            service.AddColumn(columnEntity);
                        }
                        else
                        {
                            columnEntity.EditTime = DateTime.Now;
                            service.UpdateColumn(columnEntity);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.AppendLine(string.Format("读取数据表：{0}的{1}字段出错：", tableEntity.TableName, column.Field) + ex.Message);
                    }
                }
            }
        }
        #endregion
    }
}
