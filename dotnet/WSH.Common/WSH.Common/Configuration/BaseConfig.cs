using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using System.IO;

namespace WSH.Common.Configuration
{
    public class BaseConfig
    {
        #region 初始化
        /// <summary>
        /// 配置文件的路径，默认（程序根目录/Config）
        /// </summary>
        public string FilePath = PathHelper.GetConfigPath;
        private string fileName;
        protected string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }
        public BaseConfig(string name,bool autoCreate=true)
        {
            this.FileName = ConfigHelper.GetConfigFileName(name, FilePath);
            //如果配置文件不存在则创建
            if (autoCreate)
            {
                XmlHelper.Create(this.FileName);
            }
        }
        #endregion

    }
    public class ConfigurationBase : BaseConfig
    {
        public XmlHelper Xml;
        public ConfigurationBase(string name)
            : base(name)
        {
            Xml = new XmlHelper(this.FileName);
        }
    }
}
