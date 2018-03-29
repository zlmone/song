 
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WSH.Tools.AutoUpdater
{
    public class LocalFile
    {
        #region The private fields
        private string path = "";
        private string lastver = "";
        private int size = 0;
        private DateTime modifytime;
        #endregion

        #region The public property
        [XmlAttribute("path")]
        public string Path { get { return path; } set { path = value; } }
        [XmlAttribute("lastver")]
        public string LastVer { get { return lastver; } set { lastver = value; } }
        [XmlAttribute("size")]
        public int Size { get { return size; } set { size = value; } }
        [XmlIgnore]
        public DateTime ModifyTime { get { return modifytime; } set { modifytime = value; } }
        [XmlAttribute("modifyTime")]
        public string  XModifyTime {
            get { return modifytime.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { modifytime = DateTime.Parse(value); }
        }
        #endregion

        #region The constructor of LocalFile
        public LocalFile(string path, string ver, int size, DateTime modifytime)
        {
            this.path = path;
            this.lastver = ver;
            this.size = size;
            this.modifytime = modifytime;
        }

        public LocalFile()
        {
        }
        #endregion

    }
}
