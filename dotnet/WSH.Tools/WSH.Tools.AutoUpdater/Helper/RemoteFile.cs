﻿ 
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace WSH.Tools.AutoUpdater
{
    public class RemoteFile
    {
        #region The private fields
        private string path = "";
        private string url = "";
        private string lastver = "";
        private int size = 0;
        private bool needRestart = false;
        private DateTime modifytime;
        #endregion

        #region The public property
        public string Path { get { return path; } }
        public string Url { get { return url; } }
        public string LastVer { get { return lastver; } }
        public int Size { get { return size; } }
        public bool NeedRestart { get { return needRestart; } }
        public DateTime ModifyTime { get { return modifytime; } set { modifytime = value; } }
        #endregion

        #region The constructor of AutoUpdater
        public RemoteFile(XmlNode node)
        {
            this.path = node.Attributes["path"].Value;
            this.url = node.Attributes["url"].Value;
            this.lastver = node.Attributes["lastver"].Value;
            this.size = Convert.ToInt32(node.Attributes["size"].Value);
            this.needRestart = Convert.ToBoolean(node.Attributes["needRestart"].Value);
            this.modifytime = Convert.ToDateTime(node.Attributes["modifyTime"].Value);
        }
        #endregion
    }
}