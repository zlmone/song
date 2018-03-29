using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office;
using System.IO;
using System.Data.OleDb;

namespace WSH.Tools
{
    public partial class FrmDataOfExcel : Form
    {
        private bool IsStringJoin = false;
        private bool Joined = false;
        public FrmDataOfExcel()
        {
            InitializeComponent();
        }

        private void btnconn_Click(object sender, EventArgs e)
        {
            string str = GetConnectionString();
            if (str=="")
            {
                lbljoininfo.Text = "请输入或配置连接字符串！";
            }
            else
            {
                string sql = "select name from sysobjects where xtype='u'";
                DataTable tables = GetDataTable(sql);
                if (tables != null)
                {
                    BindCombox(this.importtables, tables, "name");
                    this.lbltableimport.ForeColor = Color.Black;
                    BindCombox(this.outputtables, tables, "name");
                    this.lbltableoutput.ForeColor = Color.Black;
                    cbotables.DataSource = GetDataTable(sql);
                    cbotables.DisplayMember = "name";
                    cbotables.ValueMember = "name";
                    lbljoininfo.Text = "连接成功！";
                    Joined = true;
                }
            }
        }
        private void BindCombox(ComboBox combox,DataTable dt,string textfield) {
            combox.DataSource = dt;
            combox.DisplayMember = textfield;
            combox.ValueMember = textfield;
        }
        private string GetConnectionString() { 
            string str=this.connstring.Text.Trim();
            if(IsStringJoin==false){
                str = string.Format("server={0};database={1};uid={2};pwd={3};",txtserver.Text.Trim(),txtdatabasse.Text.Trim(),txtuid.Text.Trim(),txtpwd.Text.Trim());
            }
            return str;
        }
        private SqlConnection GetConnection() {
            SqlConnection conn = null;
            try {
                conn = new SqlConnection(GetConnectionString());
                if(conn.State==  ConnectionState.Closed){
                    conn.Open();
                    return conn;
                }
            }catch(Exception ex){
                if (conn != null)
                {
                    conn.Close();
                }
                MessageBox.Show("连接失败！"+ex.Message);
                return null;
            }
            return conn;
        }
        private DataTable GetDataTable(string sql)
        {
            SqlConnection conn = GetConnection();
            if (conn == null) { return null; }
            DataTable dt = new DataTable();
            SqlDataAdapter dr = new SqlDataAdapter(sql, conn);
            dr.Fill(dt);
            conn.Close();
            return dt;
        }
        private void DataOfExcel_Load(object sender, EventArgs e)
        {
            selectFile.Filter = "Excel(*.xls)|*.xls;*.xlsx";
            connstring.Text = "server=SY-WANGSH\\SQLEXPRESS;database=MyProject;uid=sa;pwd=";
        }

        private void btnselectfile_Click(object sender, EventArgs e)
        {
            selectFile.ShowDialog();
            if(selectFile.FileName!=""){
                importpath.Text = selectFile.FileName;
            }
        }

        private void btnsavefile_Click(object sender, EventArgs e)
        {
            saveFile.ShowDialog();
            if(saveFile.SelectedPath!=""){
                outputpath.Text = saveFile.SelectedPath;
            }
        }

        private void output_Click(object sender, EventArgs e)
        {
            string path=outputpath.Text.Trim();
            string tableName = outputtables.Text;
            if(path==""){
                MessageBox.Show("请选择导出地址！");
            }
            else if (tableName == null || tableName=="")
            {
                MessageBox.Show("请选择表名！");
            }
            else { 
                //导出
                string filename = path + "/" + tableName + ".xls";
                string sql = "select * from " + tableName;
                DataTable dt = GetDataTable(sql);
                if (dt == null) { return; }
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                if(excel==null){
                    MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                    return; 
                }
                if(File.Exists(filename)){
                    File.Delete(filename);
                }
                Microsoft.Office.Interop.Excel.Workbooks workbooks = excel.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
                //写入字段 
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                }
                //写入数值 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cells[i+ 2, j+ 1] = dt.Rows[i][j];
                    }
                    System.Windows.Forms.Application.DoEvents(); 
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                    return;
                }
                finally {
                    workbook.Close(true);
                    excel.Quit();
                    GC.Collect();
                }
                 DialogResult result= MessageBox.Show("数据导出成功！是否打开文件？","提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result ==  DialogResult.Yes){
                    System.Diagnostics.Process.Start(filename);
                }
            }
        }
        private bool CheckJoin() {
            if (!Joined)
            {
                lbljoininfo.Text = "请先配置连接！";
                tabControl1.SelectTab(0);
                return false;
            }
            return true;
        }
        private void import_Click(object sender, EventArgs e)
        {
            string file = importpath.Text.Trim();
            string tableName="";
            if (CheckJoin())
            {
                if (file == "")
                {
                    lblimportinfo.Text = "请选择要导入的文件！";
                }
                else
                {
                    if (checkBox2.Checked)
                    {
                        tableName = importtables.Text;
                    }
                    else
                    {
                        string filename = file.Substring(file.LastIndexOf("\\") + 1);
                        tableName = filename.Replace(".xls", "").Replace(".xlsx", "");
                    }
                    if (tableName == null || tableName == "")
                    {
                        lblimportinfo.Text ="请选择表名！";
                    }
                    else
                    {
                        OleDbConnection conn = null;
                        SqlConnection con = null;
                        try
                        {
                            string connstring = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties={1};", file, "Excel 8.0");
                            conn = new OleDbConnection(@connstring);
                            DataTable dt = new DataTable();
                            string sql = "select * from [Sheet1$]";
                            OleDbDataAdapter dr = new OleDbDataAdapter(sql, conn);
                            dr.Fill(dt);
                            //拼接连接sql
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine("truncate table [" + tableName + "];");
                            sb.AppendLine("SET IDENTITY_INSERT [" + tableName + "] ON;");
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                StringBuilder col = new StringBuilder();
                                StringBuilder val = new StringBuilder();
                                for (int j = 0; j < dt.Columns.Count; j++)
                                {
                                    string last = j == dt.Columns.Count - 1 ? "" : ",";
                                    val.AppendFormat("'{0}'" + last, dt.Rows[i][j]);
                                    col.Append(dt.Columns[j].ColumnName + last);
                                }
                                sb.AppendFormat("insert into [{0}]([{1}]) values({2}", tableName, col.ToString(), val.ToString());
                                sb.AppendLine(");");
                            }
                            sb.AppendFormat("SET IDENTITY_INSERT [{0}] OFF", tableName);
                            string insertsql = sb.ToString();
                            con = GetConnection();
                            SqlCommand cmd = new SqlCommand(insertsql, con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("导入成功！");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("导入失败！" + ex.Message);
                        }
                        finally
                        {
                            if (conn != null)
                            {
                                conn.Close();
                            }
                            if (con != null)
                            {
                                con.Close();
                            }
                        }
                    }
                }
            }
        }

        private void togridimport_Click(object sender, EventArgs e)
        {

        }

        private void togridoutput_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel1.Enabled = true;
                panel2.Enabled = false;
                IsStringJoin = true;
            }
            else {
                panel1.Enabled = false;
                panel2.Enabled = true;
                IsStringJoin = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                importtables.Enabled = true;
            }
            else {
                importtables.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckJoin()){
                string sql = string.Format("select {0} from [{1}]", txttopall.Text, cbotables.Text);
                string where=txtwhere.Text.Trim();
                if(where!=""){
                    sql += " where "+where;
                }
                DataTable dt = GetDataTable(sql);
                this.gvtest.DataSource = dt;
            }
        }
    }
}
