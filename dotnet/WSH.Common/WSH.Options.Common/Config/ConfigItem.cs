using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Options.Common
{
    public class ConfigItem
    {
        private string name;
        /// <summary>
        /// 配置节点名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
