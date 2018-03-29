using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common;
using WSH.Common.Helper;
using WSH.Web.Common.Helper;

namespace WSH.Web.Common
{
     
    public class HtmlBuilder : TagBuilder
    {
        public HtmlBuilder() { }
        public HtmlBuilder(string tagName) :base(tagName){
            TagName = tagName.ToLower();
            if (IsDefault)
            {
                if ("table" == TagName)
                {
                    this.AddAttribute("cellpadding", "0");
                    this.AddAttribute("cellspacing", "0");
                    this.AddAttribute("border", "0");
                }
                if ("a" == TagName)
                {
                    this.AddAttribute("href",WebConsts.NullHref);
                }
            }
        }
        public HtmlBuilder(string tagName,bool isDefault):this(tagName) {
            IsDefault = isDefault;
        }
        private bool IsDefault = false;
        private bool enabled=true;

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        
        private List<string> ClassList=new List<string>();

        private Dictionary<string, string> Styles=new Dictionary<string, string>();
         
        
        /// <summary>
        /// 添加样式
        /// </summary>
        public void AddStyle(string key,string value) {
            if (!this.Styles.ContainsKey(key))
            {
                this.Styles.Add(key, value);
            }
            else
            {
                this.Styles[key] = value;
            }
        }
        /// <summary>
        /// 添加样式集合
        /// </summary>
        public void AddStyles(IDictionary<string, string> styles) {
            foreach (string key in styles.Keys)
            {
                this.AddStyle(key, styles[key]);
            }
        }
        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="key"></param>
        public void RemoveStyle(string key)
        {
            this.Styles.Remove(key);
        }
        /// <summary>
        /// 新增样式
        /// </summary>
        /// <param name="className"></param>
        public void AddClass(string className) { 
            if(!this.ClassList.Contains(className)){
                this.ClassList.Add(className);
            }
        }
        /// <summary>
        /// 移除样式
        /// </summary>
        /// <param name="className"></param>
        public void RemoveClass(string className) {
            this.ClassList.Remove(className);
        }
        /// <summary>
        /// 如果存在样式则移除，不存在样式则新增
        /// </summary>
        /// <param name="className"></param>
        public void ToggleClass(string className) {
            if (this.ClassList.Contains(className))
            {
                this.ClassList.Remove(className);
            }
            else {
                this.AddClass(className);
            }
        }
        /// <summary>
        /// 获取所有属性
        /// </summary>
        /// <returns></returns>
        protected override string GetAttributes()
        {
            if (Styles != null && Styles.Count > 0)
            {
                this.AddAttribute("style", ClientHelper.GetStyle(this.Styles));
            }
            if (ClassList != null && ClassList.Count > 0)
            {
                this.AddAttribute("class", string.Join(" ", this.ClassList.ToArray()));
            }
            if (!string.IsNullOrEmpty(this.ID))
            {
                this.AddAttribute("id", ID);
                if (StringHelper.HasIndexOf("input,select,textarea,button",this.TagName))
                {
                    this.AddAttribute("name", ID);
                }
            }
            if (Enabled==false)
            {
                this.AddAttribute("disabled","disabled");
            }
            return base.GetAttributes();
        }
        
    }
}
