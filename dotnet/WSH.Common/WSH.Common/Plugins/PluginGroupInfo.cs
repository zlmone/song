using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Common.Plugins
{
    public class PluginGroupInfo
    {
        public PluginGroupInfo() {
            Plugins = new List<PluginInfo>();
        }
        private string groupCode;

        public string GroupCode
        {
            get { return groupCode; }
            set { groupCode = value; }
        }
        private string groupText;

        public string GroupText
        {
            get { return groupText; }
            set { groupText = value; }
        }
        private string groupName;

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }
        private string groupUrl;

        public string GroupUrl
        {
            get { return groupUrl; }
            set { groupUrl = value; }
        }
        private List<PluginInfo> plugins;

        public List<PluginInfo> Plugins
        {
            get { return plugins; }
            set { plugins = value; }
        }
    }
}
