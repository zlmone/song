using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace WSH.Office.Excel
{
    public class ExcelOleDb
    {
        public ExcelOleDb() { }
        public ExcelOleDb(string fileName, string sheetName) {
            this.fileName = fileName;
            this.sheetName = sheetName;
        }
        private OleDbConnection conn = null;

        #region 属性
        private string fileName;
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private string sheetName="Sheet1";
        /// <summary>
        /// 工作表名
        /// </summary>
        public string SheetName
        {
            get { return sheetName; }
            set { sheetName = value; }
        }
        private string columns="*";
        /// <summary>
        /// 查询的列
        /// </summary>
        public string Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        private bool isColumn=true;
        /// <summary>
        /// 是否将数据第一行查询为表头
        /// </summary>
        public bool IsColumn
        {
            get { return isColumn; }
            set { isColumn = value; }
        }
        private string top;
        /// <summary>
        /// 查询前几条数据
        /// </summary>
        public string Top
        {
            get { return top; }
            set { top = value; }
        }
        #endregion

        #region 连接对象
        /// <summary>
        /// 获取连接对象
        /// </summary>
        public void Open()
        {
            string connstring = string.Format("Provider=Microsoft.Ace.OleDb.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR={1}\";", this.FileName, (this.IsColumn ? "Yes" : "No"));
            conn = new OleDbConnection(connstring);
            try
            {
                conn.Open();
            }
            catch
            {
                conn.ConnectionString = string.Format("Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR={1}\";", this.FileName, (this.IsColumn ? "Yes" : "No"));
                conn.Open();
            }
        }
        public void Close()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
        #endregion

        #region 查询数据
        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                this.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("select");
                if (!string.IsNullOrEmpty(Top))
                {
                    sb.Append(" top " + Top);
                }
                sb.AppendFormat(" {0} from [{1}$]", Columns, SheetName);
                OleDbDataAdapter dr = new OleDbDataAdapter(sb.ToString(), conn);
                dr.Fill(dt);
            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.Close();
            }
            return dt;
        }
        #endregion

        #region 查询工作表名
        public string[] GetSheetNames()
        {
            List<string> list = new List<string>();
            this.Open();
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            foreach (DataRow row in dt.Rows)
            {
                list.Add(sheetName);
            }
            this.Close();
            return list.ToArray();
        }
        #endregion
    }
}
