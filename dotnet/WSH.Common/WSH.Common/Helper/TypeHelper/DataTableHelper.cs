using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WSH.Common.Helper
{
    public class DataTableHelper
    {
        /// <summary>
        /// 创建DataTable
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static DataTable Create(params string[] columns)
        {
            DataTable dt = new DataTable();
            foreach (string item in columns)
            {
                DataColumn col = new DataColumn();
                if (item.Contains("|"))
                {
                    string[] colType = item.Split('|');
                    col.ColumnName = colType[0];
                    col.DataType = Type.GetType(colType[1]);
                }
                else
                {
                    col.ColumnName = item;
                }
                dt.Columns.Add(col);
            }
            return dt;
        }
        /// <summary>
        /// 添加新行
        /// </summary>
        public static void AddRow(DataTable dt, params object[] rows)
        {
            DataRow row = dt.NewRow();
            for (int i = 0; i < rows.Length; i++)
            {
                row[i] = rows[i];
            }
            dt.Rows.Add(row);
        }
        public static void AddRow(DataTable dt, string[] rows) {
            DataRow row = dt.NewRow();
            for (int i = 0; i < rows.Length; i++)
            {
                row[i] = rows[i];
            }
            dt.Rows.Add(row);
        }
        /// <summary>
        /// 添加列
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="columnNames"></param>
        public static void AddColumns(DataTable dt, string[] columnNames) {
            foreach (string columnName in columnNames)
            {
                DataColumn column = new DataColumn(columnName);
                dt.Columns.Add(column);
            }
        }
    }
}
