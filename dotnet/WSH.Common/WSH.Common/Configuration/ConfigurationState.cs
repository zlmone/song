using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;

namespace WSH.Common.Configuration
{
    /// <summary>
    /// 保存历史记录信息和状态
    /// </summary>
    public class ConfigurationState : ConfigurationBase
    {
        public ConfigurationState() : base("ConfigurationState") { 
            
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public string Get(string key) {
            XmlNode node = GetNodeByKey(key);
            if(node!=null){
                return node.Attributes["value"].Value;
            }
            return null;
        }
        public T Get<T>(string key) { 
            string value=Get(key);
            object result;
            if (typeof(T).Name.ToLower().Contains("bool"))
            {
                if (value == "1" || (!string.IsNullOrEmpty(value) && value.ToLower() == "true"))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else {
                result = value;
            }
            return (T)result;
        }
        /// <summary>
        /// 根据名称删除值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void Remove(string key) {
            XmlNode node = GetNodeByKey(key);
            if(node!=null){
                this.Xml.Root.RemoveChild(node);
                Xml.Save();
            }
        }
        private XmlNode GetNodeByKey(string key) {
            return this.Xml.Root.SelectSingleNode("add[@key='" + key + "']");
        }
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key, string value)
        {
            XmlNode node = GetNodeByKey(key);
            if (node == null)
            {
                XmlElement el = Xml.Doc.CreateElement("add");
                XmlAttribute attrKey = Xml.Doc.CreateAttribute("key");
                attrKey.Value = key;
                XmlAttribute attrValue = Xml.Doc.CreateAttribute("value");
                attrValue.Value = value;
                el.Attributes.Append(attrKey);
                el.Attributes.Append(attrValue);
                this.Xml.Root.AppendChild(el);
            }
            else {
                node.Attributes["value"].Value = value;
            }
            Xml.Save();
        }
    }
}
