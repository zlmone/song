using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common.Helper;
using WSH.WinForm.Common;
using WSH.WinForm.Controls;
using WSH.Common;
using WSH.Options.Common;

namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    public partial class UserRegister : Form
    {
        public UserInfoEntity User;
        private string CodeText;
        Validation valid = new Validation();
        private LoadMaskManager loading = new LoadMaskManager();
        public UserRegister()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Utils.SetFormNoresize(this);

            valid.Add(new ValidateItem(this.txtUserName));
            valid.Add(new ValidateItem(this.txtRealName) { 
                Regex=RegexHelper.Cn,
                RegexMsg="真实姓名必须是中文"
            });
            valid.Add(new ValidateItem(this.txtPassword));
            ValidateItem pwdValid = new ValidateItem(this.txtRePwd);
            pwdValid.OnCustomValidate += new CustomValidateHanlder(pwdValid_OnCustomValidate);
            valid.Add(pwdValid);
            valid.Add(new ValidateItem(this.txtEmail)
            {
                Regex = RegexHelper.Email,
                RegexMsg = RegexHelper.EmailMsg
            });
            var codeValid = new ValidateItem(this.txtCode);
            codeValid.OnCustomValidate += new CustomValidateHanlder(codeValid_OnCustomValidate);
            valid.Add(codeValid);
        }

        void codeValid_OnCustomValidate(object sender, ValidResult result)
        {
            if (result.Value.ToLower() != CodeText.ToLower())
            {
                result.IsSuccess = false;
                result.Msg = "验证码输入不正确";
            }
        }

        void pwdValid_OnCustomValidate(object sender, ValidResult result)
        {
            if (result.Value.Trim() != this.txtPassword.Text.Trim())
            {
                result.IsSuccess = false;
                result.Msg = "两次密码输入不一致";
            }
        }

        private void UserRegister_Load(object sender, EventArgs e)
        {
            GetImage();
        }
        public void GetImage()
        {
            try
            {
                WSH.Common.VerificationCode code = new WSH.Common.VerificationCode();
                code.Width = this.pictureBox.Width;
                code.Height = this.pictureBox.Height;
                code.Text = RandomHelper.GetText(new RandomText() { Length = 4, AllowAlmost = false });
                CodeText = code.Text;
                this.pictureBox.Image = code.CreateImage();
                code.Dispose();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetImage();
        }

        private void buttonImage1_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Register();
            }
        }

        #region 注册方法
        private void Register()
        {
            if (this.valid.IsValid())
            {
                //真实姓名是否为中文
                string realName = this.txtRealName.Text.Trim();
                string code = this.txtCode.Text.Trim();
                string ip = WSH.Windows.Common.HardwareInfo.GetNetCardIP();
                string mac = WSH.Windows.Common.HardwareInfo.GetMacAddress();
                loading.Show(this);
                CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
                //先看本机是否已经注册过账号
                UserInfoEntity userInfo = service.GetUserInfo(new UserInfoEntity()
                {
                    IPAddress = ip,
                    MacAddress = mac
                });
                if (userInfo != null && userInfo.ID > 0)
                {
                    MsgBox.Alert("您本机已经注册过了，如果忘记，请点击左下角链接找回用户名和密码！");
                    this.Close();
                    return;
                }
                //没注册重新注册
                string pwd = this.txtPassword.Text.Trim();
                UserInfoEntity user = new UserInfoEntity()
                {
                    UserName = this.txtUserName.Text.Trim(),
                    RealName = realName,
                    Password = CryptHelper.EncryptDES(pwd, CryptHelper.DefaultKey),
                    CreateTime = DateTime.Now,
                    Enabled = true,
                    IsAdmin = false,
                    IPAddress = ip,
                    Email=this.txtEmail.Text.Trim(),
                    MacAddress = mac
                };
                if (service.ExistsUser(user))
                {
                    loading.Hide();
                    MsgBox.Alert("用户已经存在！"); return;
                }
                user.ID = service.AddUser(user);
                loading.Hide();
                if (user.ID > 0)
                {
                    User = user;
                    User.Password = pwd;
                    MsgBox.Alert("注册成功");
                    this.Close();
                }
                else
                {
                    MsgBox.Alert("注册失败");
                }
            }
        }
        #endregion
    }
}
