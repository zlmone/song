using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using WSH.Options.Common;
using WSH.Common.Configuration;
using WSH.Common.Helper;

namespace WSH.Common.Mail
{
    public class SmtpConfigManager
    {
        #region 私有方法属性
        private static string defaultName;
        private static Dictionary<string, SmtpConfig> configs = new Dictionary<string, SmtpConfig>();
        private static void Init(string configPath)
        {
            if (string.IsNullOrEmpty(configPath))
            {
                configPath = ConfigHelper.GetConfigFileName("Mail");
            }
            XmlHelper xml = new XmlHelper(configPath);
            XmlNode serversNode = xml.GetNode("smtps");
            defaultName = xml.GetAttr(serversNode, "default");
            XmlNodeList nodes = serversNode.SelectNodes("add");
            if (nodes != null && nodes.Count > 0)
            {
                foreach (XmlNode node in nodes)
                {
                    string name = xml.GetAttr(node, "name").Trim();
                    SmtpConfig config = new SmtpConfig()
                    {
                        Name = name,
                        Server = xml.GetAttr(node, "server"),
                        Username = xml.GetAttr(node, "username"),
                        Password = xml.GetAttr(node, "password"),
                        Port = xml.GetAttr(node, "port"),
                        SendName = xml.GetAttr(node, "sendname"),
                        Encrypt = ConvertHelper.ToBool(xml.GetAttr(node, "encrypt"))
                    };
                    //如果加密需要解密用户名和密码
                    if (config.Encrypt)
                    {
                        config.Username = CryptHelper.DecryptDES(config.Username, CryptHelper.DefaultKey);
                        config.Password = CryptHelper.DecryptDES(config.Password, CryptHelper.DefaultKey);
                    }
                    if (!configs.ContainsKey(name))
                    {
                        configs.Add(name, config);
                    }
                }
            }
        }
        #endregion

        #region 获取配置
        public static SmtpConfig GetConfig(string name, string configPath = null)
        {
            if (configs.Keys.Count <= 0 || !string.IsNullOrEmpty(configPath))
            {
                Init(configPath);
            }
            return ConfigHelper.GetConfigItem<SmtpConfig>(configs, name, defaultName);
        }
        public static SmtpConfig GetDefaultConfig(string configPath = null)
        {
            SmtpConfig config = GetConfig(null, configPath);
            return config == null ? new SmtpConfig() : config;
        }
        #endregion

        #region 获取Smtp连接对象
        public static SmtpClient GetSmtpClient(string ftpConfigName = null)
        {
            SmtpConfig config = GetConfig(ftpConfigName);
            return GetSmtpClient(config);
        }
        public static SmtpClient GetSmtpClient(SmtpConfig config)
        {
            if (config != null)
            {
                SmtpClient client = new SmtpClient()
                {
                    SmtpServer = config.Server,
                    Username = config.Username,
                    Port = config.Port,
                    Password = config.Password
                };
                return client;
            }
            return null;
        }
        #endregion
    }
    
}
