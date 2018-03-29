using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Common.Plugins
{
    public class PluginInfo
    {
        public PluginInfo() {
            Group = new PluginGroupInfo();
        }
        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private PluginGroupInfo group;

        public PluginGroupInfo Group
        {
            get { return group; }
            set { group = value; }
        }
    }
}
