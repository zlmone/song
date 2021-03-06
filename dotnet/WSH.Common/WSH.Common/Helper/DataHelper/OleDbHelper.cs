﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace WSH.Common.Helper
{
    public class OleDbHelper
    {
        public OleDbHelper() { }
        public OleDbHelper(string fileName, string sheetName)
        {
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
        public static DataTable GetDataTableFromFile(string path, string tname)
        {
            string ace = "Microsoft.ACE.OLEDB.12.0";
            string jet = "Microsoft.Jet.OLEDB.4.0";
            string xl2007 = "Excel 12.0 Xml";
            string xl2003 = "Excel 8.0";
            string imex = "IMEX=1";
            string hdr = "Yes";
            string conn = "Provider={0};Data Source={1};Extended Properties=\"{2};HDR={3};{4}\";";
            string select = "";
            string ext = Path.GetExtension(path);
            OleDbDataAdapter oda;
            DataTable dt = new DataTable(tname);
            switch (ext.ToLower())
            {
                case ".xlsx":
                    conn = String.Format(conn, ace, Path.GetFullPath(path), xl2007, hdr, imex);
                    select = string.Format("SELECT * FROM [{0}$]", tname);
                    break;
                case ".xls":
                    conn = String.Format(conn, jet, Path.GetFullPath(path), xl2003, hdr, imex);
                    select = string.Format("SELECT * FROM [{0}$]", tname);
                    break;
                case ".accdb":
                    conn = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= {0};Persist Security Info=False;", path);
                    select = string.Format("SELECT * FROM [{0}]", tname);
                    break;
                case ".csv":
                    conn = String.Format(conn, ace, path.Substring(0, path.LastIndexOf('\\')), "text;Excel 12.0", hdr, imex);
                    select = string.Format("SELECT * FROM [{0}]", Path.GetFileName(path));
                    break;
                default:
                    throw new Exception("File Not Supported!");
            }
            OleDbConnection con = new OleDbConnection(conn);
            con.Open();
            oda = new OleDbDataAdapter(select, con);
            oda.Fill(dt);
            con.Close();
            return dt;
        }
        private string GetConnectionString()
        {

            string ext = Path.GetExtension(fileName).ToLower();
            if (ext == ".xls")
            {
                return string.Format("Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR={1}\";", this.FileName, (this.IsColumn ? "Yes" : "No"));
            }
            return string.Format("Provider=Microsoft.Ace.OleDb.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR={1}\";", this.FileName, (this.IsColumn ? "Yes" : "No"));
        }
        /// <summary>
        /// 获取连接对象
        /// </summary>
        public void Open()
        {
            conn = new OleDbConnection(GetConnectionString());
            conn.Open();
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
        public DataTable GetDataTable(string sheetName=null)
        {
            if (!string.IsNullOrEmpty(sheetName))
            {
                this.SheetName = sheetName;
            }
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
