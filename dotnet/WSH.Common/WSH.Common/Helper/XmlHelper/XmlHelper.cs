using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace WSH.Common.Helper
{
    public class XmlHelper
    {
        private string Path;
        public XmlHelper(string path)
        {
            this.Path = path;
            this.load();
            this.GetRoot();
        }
        /// <summary>
        /// 创建一个xml空文件
        /// </summary>
        /// <param name="fileName"></param>
        public static void Create(string fileName)
        {
            if (!File.Exists(fileName))
            {
                FileHelper.WriteFile(fileName, "<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            }
        }
        public XmlDocument Doc = new XmlDocument();
        public XmlElement Root = null;
        private void load()
        {
            this.Doc.Load(Path);
        }
        private void GetRoot()
        {
            this.Root = this.Doc.DocumentElement;
        }

        public XmlNode GetNode(string xpath)
        {
            XmlNode node = this.Root.SelectSingleNode(xpath);
            return node;
        }
        public XmlNodeList GetNodes(string xpath)
        {
            XmlNodeList nodes = this.Root.SelectNodes(xpath);
            return nodes;
        }
        public void Save()
        {
            this.Doc.Save(this.Path);
        }
        public void AddAttr(XmlNode node, string attrName, string attrValue)
        {
            XmlAttribute name = this.Doc.CreateAttribute(attrName);
            name.Value = attrValue;
            node.Attributes.Append(name);
        }
        public string GetAttr(XmlNode node, string attrName)
        {
            XmlAttribute attr = node.Attributes[attrName];
            return attr == null ? null : attr.Value;
        }
    }
}