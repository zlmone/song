using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Common;
using WSH.Windows.Common;
using System.Data.OleDb;
using System.IO;

namespace WSH.Tools.Connection.DB
{
    public partial class AccessConnection : UserControl
    {
        private Validation validAccess = new Validation();
        private Validation validAccessString = new Validation();
        public AccessConnection()
        {
            InitializeComponent();
            //access验证
            validAccess.Add(new ValidateItem(this.txtAccessFile));
            ValidateItem item = new ValidateItem(txtAccessFile);
            item.OnCustomValidate += (sender, result) =>
            {
                if(!File.Exists(result.Value)){
                    result.IsSuccess = false;
                    result.Msg = "文件格式不正确";
                }
            };
            validAccess.Add(item);
            validAccessString.Add(new ValidateItem(this.txtAccessString));
        }
        #region Access连接
        private void button5_Click(object sender, EventArgs e)
        {
            string fileName = Dialog.GetFileName(null, FileFilter.Access);
            if (fileName != null)
            {
                this.txtAccessFile.Text = fileName;
            }
        }

        private void checkAccess_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkAccess.Checked)
            {
                validAccessString.ClearError();
                this.txtAccessString.Enabled = false;
                this.panelAccess.Enabled = true;
            }
            else
            {
                validAccess.ClearError();
                this.txtAccessString.Enabled = true;
                this.panelAccess.Enabled = false;
            }
        }
        private void btnAccessConnection_Click(object sender, EventArgs e)
        {
            string str = this.GetAccessConnectionString();
            if (!string.IsNullOrEmpty(str))
            {
                OleDbConnection db = null;
                try
                {
                    db= new OleDbConnection(str);
                    db.Open();
                    DbConnectionManager.SetResult((DbConnection)this.ParentForm, true, str);
                    this.ParentForm.Close();
                }
                catch (OleDbException ex)
                {
                    DbConnectionManager.SetResult((DbConnection)this.ParentForm, false, str);
                    MsgBox.Alert("连接失败,错误信息：" + ex.Message);
                }
                finally
                {
                    if (db != null) { db.Close(); }
                }
            }
        }
        public string GetAccessConnectionString()
        {
            if (this.checkAccess.Checked)
            {
                return validAccessString.IsValid() ? this.txtAccessString.Text.Trim() : null;
            }
            else
            {
                if (validAccess.IsValid())
                {
                    StringBuilder sb = new StringBuilder();
                    string pwd = this.txtAccessPwd.Text.Trim();
                    string file = this.txtAccessFile.Text.Trim();
                    string provider = Path.GetExtension(file) == ".accdb" ? "Microsoft.ACE.OLEDB.12.0" : "Microsoft.Jet.OLEDB.4.0";
                    sb.AppendFormat(@"Provider={0};Data Source={1}", provider, file);
                    if (pwd != "")
                    {
                        sb.AppendFormat(";Persist Security Info=True;Database Password={0}", pwd);
                    }
                    return sb.ToString();
                }
            }
            return null;
        }
        private void btnAccessCancel_Click(object sender, EventArgs e)
        {
            DbConnectionManager.SetResult((DbConnection)this.ParentForm, false,string.Empty);
            this.ParentForm.Close();
        }
        #endregion
    }
}
