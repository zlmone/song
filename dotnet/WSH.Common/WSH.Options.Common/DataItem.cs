using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Options.Common
{
    public class DataItem
    {
        public DataItem() {
            attributes = new Dictionary<string, string>();
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
        private bool selected;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        private Dictionary<string, string> attributes;

        public Dictionary<string, string> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }
    }
}
