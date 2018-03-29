using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using System.Data;
using WSH.CodeBuilder.DispatchServers;
using System.Linq;

namespace WSH.CodeBuilder.Common
{
    public class DbModelReader : ModelReader
    {
        DbModelData dbModel;
        public DbModelReader(ProjectEntity project, ConnectionEntity connection)
            : base(project)
        {
            DbType = connection.ConnectionType.ToString();
            dbModel = DbModelDataFactory.GetDbModelData(DbType, connection.ConnectionString);
        }
        public TableEntity FillTable(string tableName)
        {
            List<TableEntity> entitys = FillTables(new List<string>() { tableName });
            if (entitys.Count > 0)
            {
                return entitys[0];
            }
            return null;
        }
        public override List<TableEntity> FillTables(List<string> tableNames)
        {
            List<TableInfo> tables = new List<TableInfo>();
            foreach (string dbName in tableNames)
            {
                TableInfo table = new TableInfo();
                table.TableName = dbName;
                table.Attr = dbName;
                table.Columns=dbModel.GetColumns(table.TableName);
                tables.Add(table);
            }
            return ReaderTables(tables);
        }
    }
}
