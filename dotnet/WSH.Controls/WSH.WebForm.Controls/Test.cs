using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSH.WebForm.Controls
{
    [DefaultProperty("Text")]//作用：黑色粗体显示
    //ToolBoxItem:是否在工具箱显示
      /*
      * 将嵌套标记解析成子控件还是属性,true表示解析成属性
     [ParseChildren(bool Property,string DefaultProperty)]
     */ 
     /*
     * 把标记中的内容保存为属性还是子控件，false表示属性
     * [PersistChildren(bool)]
     */
    //如果继承WebControl，默认为ParseChildren(true),PersistChildren(false)--解析成属性
    [ToolboxData("<{0}:Test runat=server></{0}:Test>")]
    public class Test : CompositeControl, IPostBackEventHandler,IPostBackDataHandler
    {
        [Bindable(true)]//是否需要绑定
        [Browsable(true)]//是否在属性窗口显示
        [EditorBrowsable(EditorBrowsableState.Always)]//是否在智能提示或编辑显示
        /*在属性窗口中的分组，通常包括
        (Appearance外观,Behavior行为,Layout布局,Data数据,Action操作,Key,Mouse)*/
        [Category("Appearance")]
        [Description("文本值")]//属性说明
        //非属性的默认值，而是输入的值如果跟设置的值一样，不会装载
        [DefaultValue("")]
        [Localizable(true)]
        [NotifyParentProperty(false)]//属性值修改时将通知父类属性
        /*
         * 表示属性到页面保持的类型
         * Attribute:复杂属性作为主控件的属性,如果复杂属性包含子属性,则子属性持久化如Font-Bold样式
         * InnerProperty:用属性名称做为嵌套标记表示复杂属性。如<HeaderStyle...>嵌套在gridview里
         * InnerDefaultProperty:可以不需要用属性名作为标记。如<ListItem>,在一个控件内只能设置 一个
         * EncodedInnerDefaultProperty:与上同，但对属性值会进行html编码，如<div>=>&ltdiv&gt
         * [PersistenceMode(enum)]
         */
        /*
         * Visible:默认,修改属性窗口生成相应代码
         * Hidden:与上相反
         * Content:序列化是内容，而非本身，如Items中的ListItem
         * [DesignerSerializationVisibilit(enum)]
         */

        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }
        //定义事件,实现IPostBackEventHandler接口
        public void RaisePostBackEvent(string eventArgument)
        {
            //if(){}
            //获得回发脚本
            //this.Page.ClientScript.GetPostBackEventReference(this, "");
            //GetPostBackClientHyperlink与上同。加javascript:前缀
        }
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            //自己实现数据比较逻辑
            string newValue=postCollection[this.UniqueID];
            //检索子控件的值
          //  string childValue=postCollection[this.UniqueID+this.IdSeparator+'子控件ID'];
            return true;
        }
        public void RaisePostDataChangedEvent()
        {
            //如果LoadPostData返回true则调用自定义事件
        }
        //重写默认标记
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        //自定义页面标记解析(子标记一定是子控件,必须有runat和前缀可用ControlBuilder代替)
        protected override void AddParsedSubObject(object obj)
        {
            if(obj is ListItem){
                //this.Items.Add(obj);
            }
        }
        //定制页面标签解析逻辑
        protected class MyItemBuilder : ControlBuilder {
            //在页面解析器分析主控件的每个子标记时，都会调用一次此方法
            public override Type GetChildControlType(string tagName, System.Collections.IDictionary attribs)
            {
                if (tagName.ToLower() == "myitem")
                {
                //    return typeof(MyItem);
                }
                return null;
            }
            //指定控件的开始标记和结束标记之间是否允许存在空白
            public override bool AllowWhitespaceLiterals()
            {
                return base.AllowWhitespaceLiterals();
            }
        }
        /*
         * 类型转换器,用于数据类型之间的转换
         * WebColorConverter:颜色
         * ControlIDConverter:控件ID列表
         * EnumConverter：枚举
         * ExpandableObjectConverter：可扩展对象
         * DataFieldConverter：数据源字段
         *[TypeConverter(typeof(Int32Converter))]
         *解决CreateChildControls在设计器中不会自动运行
         */
        protected override void RecreateChildControls()
        {
            if (this.ChildControlsCreated == false)
            {
                base.RecreateChildControls();
            }
        }
        /*
         * 属性编辑器
         * [Editor(typeof(FileNameEditor),typeof(UITypeEditor))]
         */
        //一般只有生成子控件添加到controls逻辑，其他逻辑分开写。因为可以外部随意调用
        protected override void CreateChildControls()
        {
            
            this.Controls.Clear();
            LinkButton lb = new LinkButton();
            lb.Text = "王松华";
            this.Controls.Add(lb);
            this.ChildControlsCreated = true;
        }
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            //基类分别判断如ID,Enabled,Title,AccessKey,TabIndex,TagKey,Style不为空的情况下添加相应属性
            base.AddAttributesToRender(writer);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            //基类分别调用AddAttributesToRender,RenderContents,RenderBeginTag方法
            base.Render(writer);
        }

     

       
    }
}
