using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.CodeBuilder.WinForm.Properties;
using WSH.WinForm.Common;
using WSH.Common.Helper;
using WSH.Windows.Common;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common.Configuration;
using WSH.WinForm.Controls;
using WSH.CodeBuilder.WinForm.Forms.Tools;
using WSH.Common.Mail;
using System.Collections;
using WSH.Options.Common;
using WSH.Common;

namespace WSH.CodeBuilder.WinForm.Forms
{
    public partial class Logon : Form
    {
        public Logon()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
        StartLoading start = new StartLoading();
        void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateState(StateKeys.IsAutoLogon, this.checkBox.Checked ? "1" : "0");
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            CheckLogon();
        }

        private void Logon_Load(object sender, EventArgs e)
        {
            ConfigurationState state = new ConfigurationState();
            string username = state.Get(StateKeys.UserName);
            string password = state.Get(StateKeys.Password);
            string isAutoLogon = state.Get(StateKeys.IsAutoLogon);
            this.txtUserName.Text = username;
            this.txtPassWord.Text = password;
            this.checkBox.Checked = isAutoLogon == "1" ? true : false;
            this.txtUserName.TextChanged += new EventHandler(txtUserName_TextChanged);
            this.txtPassWord.TextChanged += new EventHandler(txtPassWord_TextChanged);
            this.checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
            if (this.checkBox.Checked)
            {
                Global.LoadingForm.Show();
                Application.DoEvents();
                CheckLogon();
            }
        }

        void txtPassWord_TextChanged(object sender, EventArgs e)
        {
            UpdateState(StateKeys.Password, this.txtPassWord.Text.Trim());
        }

        void txtUserName_TextChanged(object sender, EventArgs e)
        {
            UpdateState(StateKeys.UserName, this.txtUserName.Text.Trim());
        }
        void UpdateState(string key, string value)
        {
            ConfigurationState state = new ConfigurationState();
            state.Set(key, value);
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckLogon();
            }
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckLogon();
            }
        }
        private LoadMaskManager loading = new LoadMaskManager();
        //登录
        private void CheckLogon()
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassWord.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MsgBox.Alert("请输入用户名和密码");
            }
            else
            {
                loading.Show(this);
                this.btnLogon.Text = "登录中...";
                try
                {
                    string ip = HardwareInfo.GetNetCardIP();
                    string mac = HardwareInfo.GetMacAddress();
                    CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
                    UserInfoEntity userInfo = service.GetUserInfo(new UserInfoEntity()
                    {
                        UserName = username,
                        Password = CryptHelper.EncryptDES(password,CryptHelper.DefaultKey)
                    });
                    if (userInfo != null && userInfo.ID > 0)
                    {
                        //if (string.IsNullOrEmpty(userInfo.MacAddress) || userInfo.MacAddress != mac)
                        //{
                        //    Global.LoadingForm.Hide();
                        //    MsgBox.Alert("用户Mac地址不匹配");
                        //}
                        //else
                        //{
                           
                        //}
                        //记录用户信息
                        Global.User = userInfo;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        loading.Hide();
                        Global.LoadingForm.Hide();
                        MsgBox.Alert("用户名或密码不正确");
                    }
                }
                catch (Exception ex)
                {
                    loading.Hide();
                    MsgBox.Alert("用户鉴权失败，请于管理员联系，错误信息：" + ex.Message);
                }
                loading.Hide();
                Global.LoadingForm.Hide();
                this.btnLogon.Text = "登录";
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            UserRegister user = new UserRegister();
            user.ShowDialog();
            if (user.User != null)
            {
                this.txtUserName.Text = user.User.UserName;
                this.txtPassWord.Text = user.User.Password;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //先检查当前mac是否存在用户
            string ip = WSH.Windows.Common.HardwareInfo.GetNetCardIP();
            string mac = WSH.Windows.Common.HardwareInfo.GetMacAddress();
            UserInfoEntity userInfo = null;
            try
            {
                loading.Show(this);
                CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
                userInfo = service.GetUserInfo(new UserInfoEntity()
                {
                    IPAddress = ip,
                    MacAddress = mac
                });
                loading.Hide();
            }
            catch (Exception ex) {
                loading.Hide();
                MsgBox.Alert("获取用户信息失败，错误信息：" + ex.Message);
            }
            if (userInfo != null && userInfo.ID > 0)
            {
                string sendmail = userInfo.Email;
                if (string.IsNullOrEmpty(sendmail))
                {
                    //存在用户则发送邮件
                    Prompt p = new Prompt()
                    {
                        Content = "请输入您的邮箱",
                        Height = 100,
                        Width = 250
                    };
                    p.OnCustomValidate += (s, r) =>
                    {
                        if (!RegexHelper.Test(r.Value, RegexHelper.Email))
                        {
                            r.Msg = "邮箱格式不正确！";
                            r.IsSuccess = false;
                        }
                    };
                    sendmail = p.Show();
                }
                if (!string.IsNullOrEmpty(sendmail))
                {
                    loading.Show(this);
                    try
                    {
                        SmtpConfig config = SmtpConfigManager.GetDefaultConfig();
                        SmtpClient smtpClient = SmtpConfigManager.GetSmtpClient(config);
                        MailMessage mail = new MailMessage()
                        {
                            Subject = "WSH.Studio找回用户名密码",
                            BodyFormat = MailFormat.Text,
                            From = config.Username,
                            FromName = config.SendName,
                            Body =string.Format("您注册过的WSH.Studio用户名为：{0}，密码为：{1}",
                                userInfo.UserName,
                                CryptHelper.DecryptDES(userInfo.Password, CryptHelper.DefaultKey))
                        };
                        mail.AddRecipients(sendmail);
                        bool isSend = smtpClient.Send(mail);
                        if (!isSend)
                        {
                            throw new Exception(smtpClient.ErrorMsg);
                        }
                        loading.Hide();
                        MsgBox.Alert("已经将用户名和密码成功发送到您的邮箱，请查收！");
                    }
                    catch (Exception ex)
                    {
                        loading.Hide();
                        MsgBox.Alert("找回用户名密码失败，请联系管理员，错误信息：" + ex.Message);
                    }
                }
            }
            else {
                MsgBox.Alert("您本机还没有注册过账号，请先注册！");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string ip = WSH.Windows.Common.HardwareInfo.GetNetCardIP();
            string mac = WSH.Windows.Common.HardwareInfo.GetMacAddress();
            Prompt p = new Prompt();
            p.DefaultValue = "IP："+ip+"\r\n"+"Mac："+mac;
            p.Show();
        }
    }
}
