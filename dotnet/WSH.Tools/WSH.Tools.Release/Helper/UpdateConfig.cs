using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;
using WSH.Windows.Common;
using WSH.Common.Helper;
using System.Windows.Forms;

namespace WSH.Tools.Release
{
    public class UpdateConfig
    {
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        private string saveFileName;

        public string SaveFileName
        {
            get
            {
                if (string.IsNullOrEmpty(saveFileName.Trim()))
                {
                    return Path.Combine(PathHelper.GetMainPath, string.IsNullOrEmpty(defaultXmlName) ? "AutoUpdateService.xml" : defaultXmlName);
                }
                return saveFileName;
            }
            set { saveFileName = value; }
        }
        private string defaultXmlName;
        public string DefaultXmlName
        {
            set { defaultXmlName = value; }
        }
        public string XmlName
        {
            get { return Path.GetFileName(SaveFileName); }
        }
        private string url;

        public string Url
        {
            get {
                if(string.IsNullOrEmpty(url)){
                    return "http://localhost";
                }
                return StringHelper.DeleteEnd(url,"/"); 
            }
            set { url = value; }
        }
        public List<string> ReleaseFileList = new List<string>();
        public void Create(TreeNodeCollection nodes)
        {
            //创建文档对象
            XmlDocument doc = new XmlDocument();
            //创建根节点
            XmlElement root = doc.CreateElement("updateFiles");
            //头声明
            XmlDeclaration xmldecl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(xmldecl);
            //调用递归方法组装xml文件
            CreateNodesConfig(doc, root, nodes);
            //追加节点
            doc.AppendChild(root);
            //保存文档
            doc.Save(SaveFileName);
        }
        //递归组装xml文件方法
        private void CreateNodesConfig(XmlDocument doc, XmlElement root, TreeNodeCollection nodes)
        {
            if (nodes == null || nodes.Count <= 0)
            {
                return;
            }
            foreach (TreeNode node in nodes)
            {
                if (!node.Checked)
                {
                    continue;
                }
                string fileName = node.Text;
                string fullFileName = node.ToolTipText;
                string type = node.Tag.ToString();//0=文件夹，1=文件
                //排除当前目录中生成xml文件的工具文件
                if (fileName != XmlName && type == "1")
                {
                    string ext = Path.GetExtension(fileName);
                    string path = fullFileName.Replace(filePath, "").Replace("\\", "/");
                    FileInfo file = new FileInfo(fullFileName);
                    string p=StringHelper.DeleteStart(path, "/");
                    XmlElement child = doc.CreateElement("file");
                    child.SetAttribute("path", p);
                    child.SetAttribute("url", Url + path);
                    child.SetAttribute("modifyTime", file.LastAccessTime.ToString(FormatHelper.DateTime));
                    child.SetAttribute("size", file.Length.ToString());
                    child.SetAttribute("needRestart", "true");
                    child.SetAttribute("lastver", FileVersionInfo.GetVersionInfo(fullFileName).FileVersion);
                    root.AppendChild(child);
                    ReleaseFileList.Add(p);

                }
                //如果是文件夹，则递归生成
                if (type == "0")
                {
                    CreateNodesConfig(doc, root, node.Nodes);
                }
            }
        }
    }
}
