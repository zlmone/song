using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace WSH.Common.Helper
{
    public class TxtHelper
    {
        public static string RegexRow = @"\n+\r*\s*";
        public static string RegexColumn = @"\t";

        public static string TagRow = "\n\r";
        public static string TagColumn = "\t";

        #region 将txt文件或者内容转成DataTable
        /// <summary>
        /// 将文本内容转换成DataTable
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="columnNames">自定义列头集合</param>
        /// <param name="isFirstColumn">是否指定第一列数据为列头</param>
        /// <returns>DataTable</returns>
        public static DataTable ToDataTable(string content, string[] columnNames = null, bool isFirstColumn = false)
        {
            DataTable dt = new DataTable();
            if(!string.IsNullOrEmpty(content)){
                string[] lines = Regex.Split(content,RegexRow);
                bool isFirstRow = true;
                foreach (string line in lines)
                {
                    ParseLine(dt, line,ref columnNames, isFirstColumn, ref isFirstRow);
                }
            }
            return dt;
        }
        /// <summary>
        /// 将txt文件中的内容解析成DataTable
        /// </summary>
        /// <param name="fileName">txt文件地址</param>
        /// <param name="columnNames">自定义列头集合</param>
        /// <param name="isFirstColumn">是否指定第一列数据为列头</param>
        /// <returns>DataTable</returns>
        public static DataTable ParseDataTable(string fileName, string[] columnNames = null, bool isFirstColumn = false)
        {
            string text = FileHelper.GetFileContent(fileName);
            if(!string.IsNullOrEmpty(text)){
                return ToDataTable(text,columnNames,isFirstColumn);
            }
            return null;
        }
        private static void ParseLine(DataTable dt, string line,ref string[] columnNames, bool isFirstColumn, ref bool isFirstRow)
        {
            if (!string.IsNullOrEmpty(line))
            {
                line =line.TrimEnd('\n').TrimEnd('\r');
                string[] row = line.Split(TxtHelper.TagColumn.ToCharArray(), StringSplitOptions.None);
                if(row.Length<=0){
                    return;
                }
                if (isFirstRow)
                {
                    //以传来的列头为准，如果为空，判断是否第一行为列头，否则系统生成列头
                    if (columnNames == null || columnNames.Length <= 0)
                    {
                        if (isFirstColumn)
                        {
                            columnNames = row;
                        }
                        else
                        {
                            columnNames = new string[row.Length];
                            for (int i = 0; i < row.Length; i++)
                            {
                                columnNames[i] = "列" + i.ToString();
                            }
                        }
                    }
                    //创建列头
                    DataTableHelper.AddColumns(dt,columnNames);
                    //判断是否添加第一行为数据
                    if (!isFirstColumn)
                    {
                        DataTableHelper.AddRow(dt,row);
                    }
                    isFirstRow = false;
                }
                else
                {
                    try
                    {
                        //添加数据
                        DataTableHelper.AddRow(dt,row);
                    }
                    catch (Exception ex){

                        throw ex;
                    }
                }
            }
        }
        #endregion

        #region 将DataTable转换成文本内容
        public static string ToTextContent(DataTable dt, bool isColumn=true)
        {
            if (dt != null)
            {
                StringBuilder sb = new StringBuilder();
                if (isColumn)
                {
                    //添加表头
                    string colName = string.Empty;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        colName += dt.Columns[i].ColumnName;
                        if (i < dt.Columns.Count - 1)
                        {
                            colName += TagColumn;
                        }
                    }
                    sb.AppendLine(colName);
                }
                //添加数据内容
                foreach (DataRow row in dt.Rows)
                {
                    string rowValue = string.Empty;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        rowValue += row[dt.Columns[i]];
                        if (i < dt.Columns.Count - 1)
                        {
                            rowValue += TagColumn;
                        }
                    }
                    sb.AppendLine(rowValue);
                }
                return sb.ToString();
            }
            return string.Empty;
        }
        #endregion
    }
}