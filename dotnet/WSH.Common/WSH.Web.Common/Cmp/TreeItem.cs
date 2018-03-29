using System;
using System.Collections.Generic;
using System.Text;


namespace WSH.Web.Common
{

    public class TreeItem
    {
        public TreeItem()
        {
            Items = new List<TreeItem>();
            Attributes = new Dictionary<string, object>();
        }
        private IList<TreeItem> items;

        public virtual IList<TreeItem> Items
        {
            get { return items; }
            set { items = value; }
        }
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string pid;

        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        private string value;

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private IDictionary<string, object> attributes;

        public IDictionary<string, object> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }
        private bool isOpen;

        public bool IsOpen
        {
            get { return isOpen; }
            set { isOpen = value; }
        }
        private bool? isChecked;

        public bool? IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }
        private bool? noCheck;

        public bool? NoCheck
        {
            get { return noCheck; }
            set { noCheck = value; }
        }
        private bool? isLeaf;

        public bool? IsLeaf
        {
            get { return isLeaf; }
            set { isLeaf = value; }
        }
        private string iconClass;

        public string IconClass
        {
            get { return iconClass; }
            set { iconClass = value; }
        }
        private string iconUrl;

        public string IconUrl
        {
            get { return iconUrl; }
            set { iconUrl = value; }
        }
        private string iconOpen;

        public string IconOpen
        {
            get { return iconOpen; }
            set { iconOpen = value; }
        }
        private string iconClose;

        public string IconClose
        {
            get { return iconClose; }
            set { iconClose = value; }
        }
        private string target;

        public string Target
        {
            get { return target; }
            set { target = value; }
        }
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

    }
}
