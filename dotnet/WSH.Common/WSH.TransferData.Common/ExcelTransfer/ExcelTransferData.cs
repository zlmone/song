using System;
using System.Collections.Generic;
using System.Text;
using NPOI.SS.UserModel;
using System.Data;
using System.IO;
using WSH.Common.Helper;

namespace WSH.TransferData.Common
{
    public abstract class ExcelTransferData : ITransferData
    {
        protected IWorkbook _workBook;
        protected Action<ICellStyle> SetColumnCellStyle;
        protected Action<ICellStyle> SetRowCellStyle;

        #region
        private void AutoSizeColumns(ISheet sheet,int colTotal) {
            //英文和数字自适应
            for (int i = 0; i < colTotal; i++)
            {
                sheet.AutoSizeColumn(i);
            }
            //中文自适应
            //。。。
        }
        #endregion

        #region 读取excel的数据到byte数组
        public virtual byte[] GetBytes(DataTable table, bool isColumn = false)
        {
            //设置excel标签页的名称
            string tableName = table.TableName;
            var sheet =string.IsNullOrEmpty(table.TableName) ? _workBook.CreateSheet() : _workBook.CreateSheet(tableName);
            if (table != null)
            {
                if(isColumn){
                    //输出列头
                    var row = sheet.CreateRow(0);
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        var cell = row.CreateCell(i);
                        if (table.Columns[i] != null)
                        {
                            cell.SetCellValue(table.Columns[i].ColumnName);
                            if (SetColumnCellStyle != null)
                            {
                                SetColumnCellStyle(cell.CellStyle);
                            }
                        }
                    }
                }
                var rowCount = table.Rows.Count;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    //输出数据
                    var row = sheet.CreateRow(isColumn ? (i+1) : i);
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        var cell = row.CreateCell(j);
                        if (table.Rows[i][j] != null)
                        {
                            cell.SetCellValue(table.Rows[i][j].ToString());
                            if (SetRowCellStyle != null)
                            {
                                SetRowCellStyle(cell.CellStyle);
                            }
                        }
                    }
                }

            }
            //自适应列宽
            //AutoSizeColumns(sheet, table.Columns.Count);
            MemoryStream ms = new MemoryStream();
            _workBook.Write(ms);
            byte[] bytes = ms.ToArray();
            return bytes;
        }
        #endregion

        public virtual DataTable GetData(string fileName, string[] columnNames = null, bool isFirstColumn = false)
        {
            return null;
        }
        public virtual DataTable GetData(Stream stream, string[] columnNames=null, bool isFirstColumn = false)
        {
            using (stream)
            {
                var sheet = _workBook.GetSheetAt(0);
                if (sheet != null)
                {
                    DataTable dt = new DataTable();
                    if (columnNames == null || columnNames.Length <= 0)
                    {
                        IRow headerRow = sheet.GetRow(0);
                        int columnCount = headerRow.Cells.Count;
                        columnNames = new string[columnCount];
                        for (int i = 0; i < columnCount; i++)
                        {
                            //判断第一行是否是列名，如果不是，系统自动生成列名
                            string columnName = "列" + i.ToString();
                            if (isFirstColumn)
                            {
                                object column = GetValue(headerRow.GetCell(i));
                                if (column != null || !string.IsNullOrEmpty(column.ToString()))
                                {
                                    columnName = column.ToString();
                                }
                            }
                            columnNames[i] = columnName;
                        }
                    }
                    //添加列
                    DataTableHelper.AddColumns(dt, columnNames);
                    var row = sheet.GetRowEnumerator();
                    bool isFirstRow = true;
                    while (row.MoveNext())
                    {
                        //如果第一行为标题，则添加数据的时候过滤
                        if(isFirstColumn && isFirstRow){
                            isFirstRow = false;
                            continue;
                        }
                        DataRow dtRow = dt.NewRow();
                        IRow excelRow = row.Current as IRow;
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            var cell = excelRow.GetCell(i);

                            if (cell != null)
                            {
                                dtRow[i] = GetValue(cell);
                            }
                        }
                        dt.Rows.Add(dtRow);
                    }
                    return dt;
                }
            }

            return null;
        }


        private object GetValue(ICell cell)
        {
            object value = null;
            switch (cell.CellType)
            {
                case CellType.Blank:
                    break;
                case CellType.Boolean:
                    value = cell.BooleanCellValue ? "1" : "0"; break;
                case CellType.Error:
                    value = cell.ErrorCellValue; break;
                case CellType.Formula:
                    value = "=" + cell.CellFormula; break;
                    //cell.SetCellType(HSSFCell.CELL_TYPE_NUMERIC);
                    //value = cell.NumericCellValue.ToString();
                case CellType.Numeric:
                    value = cell.NumericCellValue.ToString(); break;
                case CellType.String:
                    value = cell.StringCellValue; break;
                case CellType.Unknown:
                    break;
            }
            return value;
        }
    }
}
