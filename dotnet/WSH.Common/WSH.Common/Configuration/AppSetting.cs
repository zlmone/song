using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace WSH.Common.Configuration
{
    public class AppSetting : ConfigurationBase
    {
        public AppSetting()
            : base("AppSetting")
        {

        }
        /// <summary>
        /// 根据键获取值
        /// </summary>
        public string GetValue(string key)
        {
            return GetAttribute(key,"value");
        }
        /// <summary>
        /// 根据键获取属性
        /// </summary>
        public string GetAttribute(string key, string attribute) {
            XmlNode node = GetNodeByKey(key);
            if (node != null)
            {
                XmlAttribute attr= node.Attributes[attribute];
                return attr == null ? null : attr.Value;
            }
            return null;
        }
        private XmlNode GetNodeByKey(string key)
        {
            return this.Xml.Root.SelectSingleNode("add[@key='" + key + "']");
        }
    }
}
