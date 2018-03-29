using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.Common.Helper;
using WSH.Tools.Internet.InternetFate;
using WSH.Options.Common;
using WSH.WinForm.Common;
using System.Runtime.InteropServices;
using System.Net;

namespace WSH.Tools.Internet
{
    public partial class FateUser : Form
    {
        public string Url = CryptHelper.DecryptDES("oej4tTHVclzGyOjTFa3acqWyt1cA+ZBPsbb0CIo86yGKNhaUZ/8LRoozWrc/krXW");

        public FateUser()
        {
            InitializeComponent();
        }
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);
        private void FateUser_Load(object sender, EventArgs e)
        {
            FateLogin l = new FateLogin();
            l.ShowDialog();
            if (l.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                FateHomeRequest request = new FateHomeRequest();
                bool login = request.Login();
                if (login)
                {
                    Result result = request.Request(request.HomePageUrl);
                    if (result.IsSuccess && !string.IsNullOrEmpty(result.Msg))
                    {
                        string url = this.Url;
                        this.web.Navigate(this.Url);
                        foreach (Cookie cookie in request.CookieCollection)
                        {
                            InternetSetCookie(url, cookie.Name, cookie.Value);
                        }
                        this.web.Navigate(url);
                        this.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        MsgBox.Alert("进入主页失败！");
                    }
                }
                else
                {
                    MsgBox.Alert("登录失败！");
                }
            }
            else {
                this.Close();
            }
        }
    }
}
