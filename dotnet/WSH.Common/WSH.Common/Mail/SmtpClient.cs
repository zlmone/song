using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Common.Mail
{
    /// <summary>
    /// 发送邮件例子
    /// </summary>
    //--------------------调用-----------------------
    //MailAttachments ma=new MailAttachments();
    //ma.Add(@"附件地址");
    //MailMessage mail = new MailMessage();
    //mail.Attachments=ma;
    //mail.Body="你好";
    //mail.AddRecipients("zjy99684268@163.com");
    //mail.From="zjy99684268@163.com";
    //mail.FromName="zjy";
    //mail.Subject="Hello";
    //SmtpClient sp = new SmtpClient();
    //sp.SmtpServer = "smtp.163.com";
    //sp.Send(mail, "zjy99684268@163.com", "123456");
    //------------------------------------------------

    /*--------------------通过配置调用-----------------------
    /SmtpClient smtpClient=SmtpConfigManager.GetSmtpClient();
    /smtpClient.Send(new MailMessage(){});
    -------------------------------------------------------*/
    public class SmtpClient
    {
        #region 构造函数
        public SmtpClient()
        { }

        public SmtpClient(string _smtpServer)
        {
            _SmtpServer = _smtpServer;
        }
        #endregion

        #region 私有字段
        private string errmsg;
        private string _SmtpServer;
        #endregion

        #region 公有属性
        /// <summary>
        /// 错误消息反馈
        /// </summary>
        public string ErrorMsg
        {
            get { return errmsg; }
        }

        /// <summary>
        /// 邮件服务器
        /// </summary>
        public string SmtpServer
        {
            set { _SmtpServer = value; }
            get { return _SmtpServer; }
        }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string port;

        public string Port
        {
            get { return port; }
            set { port = value; }
        }
        #endregion

        public bool Send(MailMessage mailMessage)
        {
            SmtpServerHelper helper = new SmtpServerHelper();
            int p = 25;
            if(!string.IsNullOrEmpty(Port)){
                p = Convert.ToInt32(Port);
            }
            if (helper.SendEmail(_SmtpServer, p, username, password, mailMessage))
                return true;
            else
            {
                errmsg = helper.ErrorMsg;
                return false;
            }
        }
    }
}
