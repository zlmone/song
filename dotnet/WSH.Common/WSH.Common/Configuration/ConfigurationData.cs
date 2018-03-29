using System;
using System.Collections.Generic;
using System.Text;
using WSH.Options.Common;
using System.Xml;

namespace WSH.Common.Configuration
{
    public class ConfigurationData : ConfigurationBase
    {
        public ConfigurationData() : base("ConfigurationData")
        { 
            
        }
        /// <summary>
        /// 获取配置数据
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <returns></returns>
        public IList<DataItem> Get(string name) {
            IList<DataItem> list = new List<DataItem>();
            XmlNodeList nodes = this.Xml.Root.SelectNodes("Data[@Name='" + name + "']/Item");
            if(nodes!=null && nodes.Count>0){
                foreach (XmlNode node in nodes)
                {
                    DataItem item = new DataItem();
                    item.Text = node.InnerText;
                    XmlAttributeCollection attrs = node.Attributes;
                    if (attrs != null && attrs.Count > 0)
                    {
                        foreach (XmlAttribute attr in attrs)
                        {
                            if (attr.Name.ToLower() == "value")
                            {
                                item.Value = attr.Value;
                            }
                            else {
                                item.Attributes.Add(attr.Name, attr.Value);
                            }
                        }
                    }
                    list.Add(item);
                }
            }
            return list;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name) {
            XmlNode data = GetNodeByName(name);
            if(data!=null){
                Xml.Root.RemoveChild(data);
                Xml.Save();
            }
        }
        private XmlNode GetNodeByName(string name) {
            return this.Xml.Root.SelectSingleNode("Data[@Name='" + name + "']");
        }
        /// <summary>
        /// 设置配置数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="items"></param>
        public void Set(string name, IList<DataItem> items) {
            XmlNode data = GetNodeByName(name);
            if(data==null){
                data = this.Xml.Doc.CreateElement("Data");
                XmlAttribute attr = Xml.Doc.CreateAttribute("Name");
                attr.Value = name;
                data.Attributes.Append(attr);
                Xml.Root.AppendChild(data);
            }
            if(items!=null && items.Count>0){
                foreach (DataItem item in items)
                {
                    XmlElement el = Xml.Doc.CreateElement("Item");
                    
                    if(!string.IsNullOrEmpty(item.Text)){
                        el.InnerText = item.Text;
                    }
                    if(!string.IsNullOrEmpty(item.Value) && !item.Attributes.ContainsKey("Value")){
                        item.Attributes.Add("Value",item.Value);
                    }
                    foreach (string key in item.Attributes.Keys)
                    {
                        XmlAttribute attr = Xml.Doc.CreateAttribute(key);
                        attr.Value = item.Attributes[key];
                        el.Attributes.Append(attr);
                    }
                    data.AppendChild(el);
                }
                Xml.Save();
            }
        }
        public void Set(string name, DataItem item)
        {
            Set(name, new List<DataItem>() { item });
        }
    }
}
