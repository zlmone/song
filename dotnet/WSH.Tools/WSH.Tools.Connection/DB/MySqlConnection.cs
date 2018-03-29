using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Common;
using System.Data.SqlClient;
using WSH.Options.Common;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.Tools.Connection.DB
{
    public partial class MySqlConnection : UserControl
    {
        public MySqlConnection()
        {
            InitializeComponent();
        }
        private bool isMySqlServerChange = true;
        private Validation validMySql = new Validation();
        private Validation validMySqlString = new Validation();
        private void MySqlConnection_Load(object sender, EventArgs e)
        {
            //MySql验证
            validMySql.Add(new ValidateItem(this.cboMySqlServer));
            validMySql.Add(new ValidateItem(this.cboMySqlUid));
            validMySql.Add(new ValidateItem(this.txtMySqlPwd));
            validMySql.Add(new ValidateItem(this.cboMySqlDb));

            validMySqlString.Add(new ValidateItem(txtMySqlString));
          
        }
        #region MySql连接
        private void btnMySqlConnection_Click(object sender, EventArgs e)
        {
            string str = this.GetMySqlConnectionString(true);
            if (!string.IsNullOrEmpty(str))
            {
                Result result = DataBaseHelper.Test(DataBaseType.MySql, new DbConnectionOptions() { 
                     ConnectionString= str
                });
                if (!result.IsSuccess)
                {
                    DbConnectionManager.SetResult((DbConnection)this.ParentForm, false, string.Empty);
                    MsgBox.Alert(result.Msg);
                }
                else {
                    DbConnectionManager.SetResult((DbConnection)this.ParentForm, true, str);
                    this.ParentForm.Close();
                }
            }
        }

        private void btnMySqlCancel_Click(object sender, EventArgs e)
        {
            DbConnectionManager.SetResult((DbConnection)this.ParentForm, true, string.Empty);
            this.ParentForm.Close();
        }

        private void checkMySql_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkMySql.Checked)
            {
                validMySqlString.ClearError();
                this.txtMySqlString.Enabled = false;
                this.panelMySql.Enabled = true;
            }
            else
            {
                validMySql.ClearError();
                this.txtMySqlString.Enabled = true;
                this.panelMySql.Enabled = false;
            }
        }
        public void SetConnectionString(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                this.checkMySql.Checked = true;
                this.panelMySql.Enabled = false;
                this.txtMySqlString.Enabled = true;
                this.txtMySqlString.Text = connectionString;
            }
        }
        public string GetMySqlConnectionString(bool isDataBase)
        {
            if (this.checkMySql.Checked)
            {
                return validMySqlString.IsValid() ? this.txtMySqlString.Text.Trim() : null;
            }
            else
            {
                if (validMySql.IsValid())
                {
                    string server = this.cboMySqlServer.Text.Trim();
                    string db = this.cboMySqlDb.Text.Trim();
                    string uid = this.cboMySqlUid.Text.Trim();
                    string pwd = this.txtMySqlPwd.Text.Trim();
                    string port = this.txtMySqlPort.Text.Trim();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("server=" + server);
                    if (!string.IsNullOrEmpty(port))
                    {
                        sb.Append(";port=" + port);
                    }
                    sb.AppendFormat(";uid={0};pwd={1}", uid, pwd);
                    if (isDataBase)
                    {
                        sb.Append(";database=" + db);
                    }
                    //  return string.Format("server={0}"+(string.IsNullOrEmpty(port) ? "" : (":"+port))+";database={1};uid={2};pwd={3};", server, db, uid, pwd);
                    return sb.ToString();
                }
            }
            return null;
        }
        private void cboMySqlDb_Click(object sender, EventArgs e)
        {
            string sql = GetMySqlConnectionString(false);
            if (!string.IsNullOrEmpty(sql) && isMySqlServerChange)
            {
                string str = string.Format("show databases");
                //SqlConnection conn = new SqlConnection(str);
                //try
                //{
                //    // conn.Open();
                //    DataTable dt = new DataTable();
                //    SqlDataAdapter dr = new SqlDataAdapter(sql, conn);
                //    dr.Fill(dt);
                //    this.cboSqlDb.DisplayMember = "database";
                //    this.cboSqlDb.ValueMember = "database";
                //    this.cboSqlDb.DataSource = dt;
                //}
                //catch (SqlException ex)
                //{
                //    MsgBox.Alert("获取数据库失败，错误信息：" + ex.Message);
                //}
                //finally
                //{
                //    conn.Close();
                //    isMySqlServerChange = false;
                //}
            }
        }
        private void cboMySqlServer_TextChanged(object sender, EventArgs e)
        {
            isMySqlServerChange = true;
        }
        #endregion

       
         
    }
}
