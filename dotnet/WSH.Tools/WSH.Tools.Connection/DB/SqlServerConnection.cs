using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Common;
using System.Data.SqlClient;

namespace WSH.Tools.Connection.DB
{
    public partial class SqlServerConnection : UserControl
    {
        private bool isSqlServerChange = false;
        private Validation validSql = new Validation();
        private Validation validSqlString = new Validation();
        public SqlServerConnection()
        {
            InitializeComponent();
            //sql验证
            validSql.Add(new ValidateItem(this.cboSqlServer));
            validSql.Add(new ValidateItem(this.cboSqlDb));
            validSqlString.Add(new ValidateItem(this.txtSqlString));
            this.cboSqlType.SelectedIndex = 1;
        }
        #region SqlServer连接
        private void checkSql_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkSql.Checked)
            {
                validSqlString.ClearError();
                this.txtSqlString.Enabled = false;
                this.panelSql.Enabled = true;
            }
            else
            {
                validSql.ClearError();
                this.txtSqlString.Enabled = true;
                this.panelSql.Enabled = false;
            }
        }
        public void SetConnectionString(string connectionString) {
            if (!string.IsNullOrEmpty(connectionString))
            {
                this.checkSql.Checked = true;
                this.panelSql.Enabled = false;
                this.txtSqlString.Enabled = true;
                this.txtSqlString.Text = connectionString;
            }
        }
        public string GetConnectionString()
        {
            if (this.checkSql.Checked)
            {
                return validSqlString.IsValid() ? this.txtSqlString.Text.Trim() : null;
            }
            else
            {

                if (validSql.IsValid())
                {
                    string server = this.cboSqlServer.Text.Trim();
                    string db = this.cboSqlDb.Text.Trim();
                    StringBuilder sb = new StringBuilder();
                    if (this.cboSqlType.SelectedIndex == 0)
                    {
                        sb.AppendFormat("Data Source=" + server + ";Initial Catalog=" + db + ";Integrated Security=True");
                    }
                    else
                    {
                        string uid = this.cboSqlUid.Text.Trim();
                        string pwd = this.txtSqlPwd.Text.Trim();
                        sb.AppendFormat("server={0};database={1};uid={2};pwd={3};", server, db, uid, pwd);
                    }
                    return sb.ToString();
                }
            }
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str = this.GetConnectionString();
            if (!string.IsNullOrEmpty(str))
            {
                SqlConnection db = new SqlConnection(str + DbConnectionManager.TimeoutString);
                try
                {
                    db.Open();
                    db.Close();
                    DbConnectionManager.SetResult((DbConnection)this.ParentForm, true,str);
                    this.ParentForm.Close();
                }
                catch (SqlException ex)
                {
                    DbConnectionManager.SetResult((DbConnection)this.ParentForm, false,str);
                    MsgBox.Alert("连接失败,错误信息：" + ex.Message);
                }
                finally
                {
                    if (db != null) { db.Close(); }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DbConnectionManager.SetResult((DbConnection)this.ParentForm, false,string.Empty);
            this.ParentForm.Close();
        }

        private void AddSqlServerValid()
        {
            validSql.Add(new ValidateItem(this.cboSqlUid));
            validSql.Add(new ValidateItem(this.txtSqlPwd));
        }

        private void cboSqlType_TextChanged(object sender, EventArgs e)
        {
            if (this.cboSqlType.SelectedIndex == 0)
            {
                this.cboSqlUid.Enabled = false;
                this.txtSqlPwd.Enabled = false;
                validSql.RemoveAt(2);
                validSql.RemoveAt(2);
            }
            else
            {
                this.cboSqlUid.Enabled = true;
                this.txtSqlPwd.Enabled = true;
                AddSqlServerValid();
            }
        }
        private void cboSqlDb_Click(object sender, EventArgs e)
        {
            string server = this.cboSqlServer.Text.Trim();
            if (!string.IsNullOrEmpty(server) && isSqlServerChange)
            {
                string str = string.Format("data source={0};Integrated Security=True{1}", server, DbConnectionManager.TimeoutString);
                string sql = string.Format("select name from sysdatabases where dbid>=5 order by dbid desc");
                SqlConnection conn = new SqlConnection(str);
                try
                {
                    // conn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter dr = new SqlDataAdapter(sql, conn);
                    dr.Fill(dt);
                    this.cboSqlDb.DisplayMember = "name";
                    this.cboSqlDb.ValueMember = "name";
                    this.cboSqlDb.DataSource = dt;
                }
                catch (SqlException ex)
                {
                    MsgBox.Alert("获取数据库失败，错误信息：" + ex.Message);
                }
                finally
                {
                    conn.Close();
                    isSqlServerChange = false;
                }
            }
        }

        private void cboSqlServer_TextChanged(object sender, EventArgs e)
        {
            //改变服务器名则重新查询数据库
            isSqlServerChange = true;
        }
        #endregion
    }
}
