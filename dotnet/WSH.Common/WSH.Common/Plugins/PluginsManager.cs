using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using WSH.Common.Helper;
using WSH.Common.Configuration;

namespace WSH.Common.Plugins
{
    public class PluginsManager
    {
        private string fileName = ConfigHelper.GetConfigFileName("Plugins");

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public PluginsManager() { }
        public PluginsManager(string fileName)
        {
            this.FileName = fileName;
        }
        private List<PluginGroupInfo> plugins;

        public List<PluginGroupInfo> Plugins
        {
            get { return plugins; }
            set { plugins = value; }
        }
        /// <summary>
        /// 加载插件信息
        /// </summary>
        public void Load()
        {
            List<PluginGroupInfo> groups = new List<PluginGroupInfo>();
            XmlHelper xml = new XmlHelper(FileName);
            XmlNodeList groupNodes = xml.Root.SelectNodes("pluginGroup");
            foreach (XmlNode groupNode in groupNodes)
            {
                //读取插件分组
                PluginGroupInfo groupInfo = new PluginGroupInfo()
                {
                    GroupCode = groupNode.Attributes["groupCode"].Value,
                    GroupText = groupNode.Attributes["groupText"].Value,
                    GroupName = groupNode.Attributes["groupName"].Value,
                    GroupUrl = groupNode.Attributes["groupUrl"].Value
                };
                //读取插件信息
                XmlNodeList nodes = groupNode.ChildNodes;
                if (nodes != null)
                {
                    foreach (XmlNode node in nodes)
                    {
                        if (node.Name == "plugin")
                        {
                            PluginInfo info = new PluginInfo()
                            {
                                Code = node.Attributes["code"].Value,
                                Text = node.Attributes["text"].Value,
                                Name = node.Attributes["name"].Value,
                                Url = node.Attributes["url"].Value,
                                Group=groupInfo
                            };
                            groupInfo.Plugins.Add(info);
                        }
                    }
                }
                groups.Add(groupInfo);
            }
            Plugins=groups;
        }
        /// <summary>
        /// 根据分组编码获取插件集合
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        public List<PluginInfo> GetPluginsByGroupCode(string groupCode) {
            if (Plugins!=null)
            {
                foreach (PluginGroupInfo group in Plugins)
                {
                    if (group.GroupCode == groupCode)
                    {
                        return group.Plugins;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 根据插件编码获取插件信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public PluginInfo GetPluginInfo(string code) {
            if (Plugins != null)
            {
                foreach (PluginGroupInfo group in Plugins)
                {
                    foreach (PluginInfo plugin in group.Plugins)
                    {
                        if (plugin.Code==code)
                        {
                            return plugin;
                        }
                    }
                }
            }
            return null;
        }
    }
}
