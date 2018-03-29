using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Common;
using WSH.Common.Helper;
using WSH.Common.Configuration;
using WSH.Common.Ftp;


namespace WSH.Tools.Connection.FTP
{
    public partial class FTPConnection : Form
    {
        private string ftpAddressKey = "FTPConnectionAddress";
        private string ftpPortKey = "FTPConnectionPort";
        private string ftpUidKey = "FTPConnectionUid";
        private string ftpPwdKey = "FTPConnectionPwd";
        private Validation validFTP = new Validation();

        public delegate void ConnectionHandler(object sender,FtpResult result);
        public event ConnectionHandler OnConnection;
        public FTPConnection()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            validFTP.Add(new ValidateItem(this.txtAddress));
            validFTP.Add(new ValidateItem(this.txtUid));
            validFTP.Add(new ValidateItem(this.txtPwd));
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (validFTP.IsValid())
            {
                this.btnConnection.Text = "连接中...";
                Application.DoEvents();
                FtpResult result = new FtpResult();
                try
                {
                    FtpClient client = new FtpClient(
                        txtAddress.Text.Trim(),
                        txtUid.Text.Trim(),
                        txtPwd.Text.Trim()
                    );
                    if(!string.IsNullOrEmpty(txtPort.Text)){
                        client.port = Convert.ToInt32(txtPort.Text.Trim());
                    }
                    result.IsSuccess = client.Connect();
                    if (!result.IsSuccess)
                    {
                        result.Msg = string.IsNullOrEmpty(client.errormessage) ? "连接失败" : client.errormessage;
                    }
                    else {
                        result.Msg = "连接成功";
                    }
                }
                catch (Exception ex) {
                    result.IsSuccess = false;
                    result.Msg ="连接失败，错误信息："+ ex.Message;
                }
                this.btnConnection.Text = "连接";
                ConnectResult(result);
            }
        }
        private void ConnectResult(FtpResult result)
        { 
            //if(!result.IsSuccess){
            //    MsgBox.Alert(result.Msg);
            //}
            //执行连接事件
            if (OnConnection != null)
            {
                OnConnection(this, result);
            }
            else {
                MsgBox.Alert(result.Msg);
            }
        }

        private void FTPConnection_Load(object sender, EventArgs e)
        {
            ConfigurationState state = new ConfigurationState();
            this.txtAddress.Text = state.Get(ftpAddressKey);
            this.txtPort.Text = state.Get(ftpPortKey);
            this.txtUid.Text = state.Get(ftpUidKey);
            this.txtPwd.Text = state.Get(ftpPwdKey);
        }

        private void UpdateState(string key, string value) {
            ConfigurationState state = new ConfigurationState();
            state.Set(key,value);
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            UpdateState(ftpAddressKey,this.txtAddress.Text.Trim());
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            UpdateState(ftpPortKey, this.txtPort.Text.Trim());
        }

        private void txtUid_TextChanged(object sender, EventArgs e)
        {
            UpdateState(ftpUidKey, this.txtUid.Text.Trim());
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            UpdateState(ftpPwdKey, this.txtPwd.Text.Trim());
        }

    }
}
