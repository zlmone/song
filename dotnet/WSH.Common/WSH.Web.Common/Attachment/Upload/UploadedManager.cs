using System;
using System.Collections.Generic;
using System.Text;
using WSH.Options.Common;

namespace WSH.Web.Common.Attachment
{
    public class UploadedManager
    {
        private Dictionary<string, string> dic = new Dictionary<string, string>();
        public UploadedManager()
        {

        }
        public UploadedManager Add(string filePath, string fileName)
        {
            if (!dic.ContainsKey(filePath))
            {
                this.dic.Add(filePath, fileName);
            }
            return this;
        }
        public override string ToString()
        {
            List<string> list = new List<string>();
            foreach (string key in dic.Keys)
            {
                list.Add(key + "," + dic[key]);
            }
            return string.Join("|", list.ToArray());
        }
        public static IList<UploadedItem> Parse(string str)
        {
            IList<UploadedItem> list = new List<UploadedItem>();
            if (!string.IsNullOrEmpty(str))
            {
                string[] items = str.Split('|');
                for (int i = 0; i < items.Length; i++)
                {
                    string[] subitems = items[i].Split(',');
                    list.Add(new UploadedItem()
                    {
                        FilePath = subitems[0],
                        FileName = subitems[1]
                    });
                }
            }
            return list;
        }
    }
    public class UploadedItem : ConfigItem
    {
        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
 
    }
}
