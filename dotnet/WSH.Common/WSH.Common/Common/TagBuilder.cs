using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Common
{
    /// <summary>
    /// 标签渲染模式
    /// </summary>
    public enum TagReanderMode
    {
        Normal,
        StartTag,
        SelfClosing,
        EndTag
    }
    public  class TagBuilder
    {
        public static string GetAttributes(IDictionary<string, string> attrs)
        {
            string html = "";
            if (attrs != null && attrs.Count > 0)
            {
                foreach (string key in attrs.Keys)
                {
                    html += string.Format(" {0}=\"{1}\"", key, attrs[key]);
                }
            }
            return html;
        }
        private string tagName;

        public virtual string TagName
        {
            get { return tagName; }
            set { tagName = value; }
        }
        public TagBuilder(string tagName) {
            TagName = tagName.ToLower();
        }
        public TagBuilder() { 
            
        }
        private string innerHtml;

        public string InnerHtml
        {
            get { return innerHtml; }
            set { innerHtml = value; }
        }

        private string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        private Dictionary<string, string> Attributes = new Dictionary<string, string>();
        /// <summary>
        /// 添加属性
        /// </summary>
        public void AddAttribute(string key, string value)
        {
            if (!this.Attributes.ContainsKey(key))
            {
                this.Attributes.Add(key, value);
            }
            else
            {
                this.Attributes[key] = value;
            }
        }
        public string GetAttribute(string key) { 
            if(this.Attributes.ContainsKey(key)){
                return this.Attributes[key];
            }
            return null;
        }
        /// <summary>
        /// 添加属性集合
        /// </summary>
        public void AddAttributes(IDictionary<string, string> attrs)
        {
            foreach (string key in attrs.Keys)
            {
                this.AddAttribute(key, attrs[key]);
            }
        }
        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="key"></param>
        public void RemoveAttribute(string key)
        {
            this.Attributes.Remove(key);
        }
        /// <summary>
        /// 获取所有属性
        /// </summary>
        /// <returns></returns>
        protected virtual string GetAttributes()
        {
            return TagBuilder.GetAttributes(this.Attributes);
        }
        /// <summary>
        /// 转换成html字符串
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public string ToString(TagReanderMode mode)
        {
            switch (mode)
            {
                case TagReanderMode.StartTag: return string.Format("<{0}{1}>", TagName, GetAttributes());
                case TagReanderMode.SelfClosing: return string.Format("<{0}{1}/>", TagName, GetAttributes());
                case TagReanderMode.EndTag: return string.Format("</{0}>", TagName);
                default: return string.Format("<{0}{1}>{2}</{3}>", TagName, GetAttributes(), InnerHtml, TagName);
            }
        }
        public override string ToString()
        {
            string s= ToString(TagReanderMode.Normal);
            return s;
        }
    }
}
