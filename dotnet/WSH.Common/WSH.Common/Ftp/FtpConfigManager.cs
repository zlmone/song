using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Configuration;
using System.IO;
using System.Xml;
using WSH.Options.Common;
using WSH.Common.Helper;

namespace WSH.Common.Ftp
{
    public class FtpConfigManager
    {
        #region 私有方法属性
        private static string defaultName;
        private static Dictionary<string, FtpConfig> configs = new Dictionary<string, FtpConfig>();
        private static void Init(string configPath)
        {
            if (string.IsNullOrEmpty(configPath))
            {
                configPath = ConfigHelper.GetConfigFileName("Attachment");
            }
            XmlHelper xml = new XmlHelper(configPath);
            XmlNode serversNode = xml.GetNode("servers");
            defaultName = xml.GetAttr(serversNode, "default");
            XmlNodeList nodes = serversNode.SelectNodes("add[@type='ftp']");
            if (nodes != null && nodes.Count > 0)
            {
                foreach (XmlNode node in nodes)
                {
                    string name = xml.GetAttr(node, "name").Trim();
                    FtpConfig config = new FtpConfig()
                    {
                        Name = name,
                        Server = xml.GetAttr(node, "server"),
                        Username = xml.GetAttr(node, "username"),
                        Password = xml.GetAttr(node, "password"),
                        Port = xml.GetAttr(node, "port"),
                        Timeout = xml.GetAttr(node, "timeout"),
                        Url = xml.GetAttr(node, "url")
                    };
                    if (!configs.ContainsKey(name))
                    {
                        configs.Add(name, config);
                    }
                }
            }
        }
        #endregion

        #region 获取配置
        public static FtpConfig GetConfig(string name, string configPath = null)
        {
            if (configs.Keys.Count <= 0 || !string.IsNullOrEmpty(configPath))
            {
                Init(configPath);
            }
            return ConfigHelper.GetConfigItem<FtpConfig>(configs, name, defaultName);
        }
        public static FtpConfig GetDefaultConfig(string configPath = null)
        {
            FtpConfig config = GetConfig(null, configPath);
            return config == null ? new FtpConfig() : config;
        }
        #endregion

        #region 获取Ftp连接对象
        /// <summary>
        /// 根据配置名称获取FTP连接对象
        /// </summary>
        /// <param name="ftpConfigName">ftp配置名称，如果为空则获取默认配置</param>
        /// <returns>FTP连接对象</returns>
        public static FtpClient GetFtpClient(string ftpConfigName = null)
        {
            FtpConfig config = GetConfig(ftpConfigName);
            return GetFtpClient(config);
        }
        public static FtpClient GetFtpClient(FtpConfig config)
        {
            if (config != null)
            {
                FtpClient client = new FtpClient(config.Server, config.Username, config.Password);
                if (!string.IsNullOrEmpty(config.Port))
                {
                    client.port = Convert.ToInt32(config.Port);
                }
                if (!string.IsNullOrEmpty(config.Timeout))
                {
                    client.timeout = Convert.ToInt32(config.Timeout);
                }
                return client;
            }
            return null;
        }
        #endregion
    }
}
