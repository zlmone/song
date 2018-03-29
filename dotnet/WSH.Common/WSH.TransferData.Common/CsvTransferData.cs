using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace WSH.TransferData.Common
{
    public class CsvTransferData : ITransferData
    {
        private Encoding _encode;
        public CsvTransferData()
        {
            this._encode = Encoding.GetEncoding("utf-8");
        }

        public byte[] GetBytes(DataTable table, bool isColumn = false)
        {
            StringBuilder sb = new StringBuilder();
            if (table != null && table.Columns.Count > 0 && table.Rows.Count > 0)
            {
                if(isColumn){
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            sb.Append(",");
                        }
                        sb.Append(table.Columns[i].ColumnName);
                        sb.Append("\n");
                    }
                }
                foreach (DataRow item in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            sb.Append(",");
                        }
                        if (item[i] != null)
                        {
                            sb.Append("\"").Append(item[i].ToString().Replace("\"", "\"\"")).Append("\"");
                        }
                    }
                    sb.Append("\n");
                }
            }
            return _encode.GetBytes(sb.ToString());
        }

        public DataTable GetData(string fileName, string[] columnNames = null, bool isFirstColumn = false)
        {
            FileStream fs = new FileStream(fileName,FileMode.Open,FileAccess.Read);
            return GetData(fs);
        }

        public DataTable GetData(Stream stream, string[] columnNames = null, bool isFirstColumn = false)
        {
            using (stream)
            {
                using (StreamReader input = new StreamReader(stream, _encode))
                {
                    //using (CsvReader csv = new CsvReader(input, false))
                    //{
                    //    DataTable dt = new DataTable();
                    //    int columnCount = csv.FieldCount;
                    //    for (int i = 0; i < columnCount; i++)
                    //    {
                    //        dt.Columns.Add("col" + i.ToString());
                    //    }

                    //    while (csv.ReadNextRecord())
                    //    {
                    //        DataRow dr = dt.NewRow();
                    //        for (int i = 0; i < columnCount; i++)
                    //        {
                    //            if (!string.IsNullOrEmpty(csv[i]))
                    //            {
                    //                dr[i] = csv[i];
                    //            }
                    //        }
                    //        dt.Rows.Add(dr);
                    //    }
                    //    return dt;
                    //}
                }
            }
            return null;
        }
    }
}
