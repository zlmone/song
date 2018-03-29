using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSH.Web.Common;
using System.Data;
using System.ComponentModel.Design;
using System.Drawing.Design;
using WSH.WebForm.Common;

namespace WSH.WebForm.Controls
{
    [ToolboxData("<{0}:ZTree runat=server></{0}:ZTree>")]
    public class ZTree : CompositeControl 
    {
        public override string ClientID
        {
            get
            {
                return this.ID;
            }
        }
        private DataTable dataSource;
        [Description("绑定的数据源,如设置该属性请配置好SimpleData")]
        public DataTable DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }
        #region ZTree内联属性
        private List<TreeItem> items;
        [Description("节点集合")]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content)]
        [PersistenceMode( PersistenceMode.InnerProperty)]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public List<TreeItem> Items
        {
            get { if (items == null) { this.items= new List<TreeItem>(); }; return items; }
        }
        private ZTreeAsync async;
        /// <summary>
        /// 异步加载的配置选项
        /// </summary>
        [Description("异步加载的配置选项")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ZTreeAsync Async
        {
            get { if (async == null) { this.async= new ZTreeAsync(); }; return async; }
        }
        private ZTreeCheck check;
        [Description("选择框的配置选项")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ZTreeCheck Check
        {
            get { if (check == null) { this.check= new ZTreeCheck(); }; return check; }
        }
        private ZTreeDrag drag;
        [Description("节点拖动的配置选项")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ZTreeDrag Drag
        {
            get { if (drag == null) { this.drag= new ZTreeDrag(); };return drag; }
             
        }
        private ZTreeEdit edit;
        [Description("节点编辑的配置选项")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ZTreeEdit Edit
        {
            get { if (edit == null) { this.edit= new ZTreeEdit(); }; return edit; }
            
        }
        private ZTreeSimpleData simpleData;
        [Description("简单数据模式的配置选项")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ZTreeSimpleData SimpleData
        {
            get { if (simpleData == null) { this.simpleData= new ZTreeSimpleData(); }; return simpleData; }
        }
        private ZTreeView view;
        [Description("视图的配置选项")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ZTreeView View
        {
            get { if (view == null) { this.view= new ZTreeView(); }; return view; }
        }
        #endregion

        #region 客户端Before事件集合
        private string _BeforeAsync;
        /// <summary>
        /// <para>异步加载之前的回调函数,根据返回值确定是否进行异步加载</para>
        /// function(treeID,treeNode){}
        /// </summary>
        public string BeforeAsync
        {
            get { return _BeforeAsync; }
            set { _BeforeAsync = value; }
        }
        private string _BeforeCheck;
        /// <summary>
        /// <para>勾选或取消勾选之前的回调函数,根据返回值确定是否允许勾选或取消勾选</para>
        /// function(treeID,treeNode){}
        /// </summary>
        public string BeforeCheck
        {
            get { return _BeforeCheck; }
            set { _BeforeCheck = value; }
        }
        private string _BeforeClick;
        /// <summary>
        /// <para>单击节点之前的回调函数,根据返回值确定是否允许单击操作</para>
        /// function(treeID,treeNode,clickFlag){}
        /// </summary>
        public string BeforeClick
        {
            get { return _BeforeClick; }
            set { _BeforeClick = value; }
        }
        private string _BeforeCollapse;
        /// <summary>
        /// <para>父节点折叠之前的回调函数，并且根据返回值确定是否允许折叠操作</para>
        /// function(treeID,treeNode){}
        /// </summary>
        public string BeforeCollapse
        {
            get { return _BeforeCollapse; }
            set { _BeforeCollapse = value; }
        }
        private string _BeforeDblClick;
        /// <summary>
        /// <para>Tree上鼠标双击之前的回调函数，并且根据返回值确定触发onDblClick回调函数</para>
        /// <para>function(treeID,treeNode){}</para>
        /// 如果不在节点上，treeNode返回 null
        /// </summary>
        public string BeforeDblClick
        {
            get { return _BeforeDblClick; }
            set { _BeforeDblClick = value; }
        }
        private string _BeforeDrag;
        /// <summary>
        /// <para>节点被拖拽之前的回调函数，并且根据返回值确定是否允许开启拖拽操作</para>
        /// function(treeID,Array(JSON) treeNodes){}
        /// </summary>
        public string BeforeDrag
        {
            get { return _BeforeDrag; }
            set { _BeforeDrag = value; }
        }
        private string _BeforeDragOpen;
        /// <summary>
        /// <para>拖拽节点移动到折叠状态的父节点后，即将自动展开该父节点之前的回调函数，并且根据返回值确定是否允许自动展开操作</para>
        /// function(treeID,treeNode){}
        /// </summary>
        public string BeforeDragOpen
        {
            get { return _BeforeDragOpen; }
            set { _BeforeDragOpen = value; }
        }
        private string _BeforeDrop;
        /// <summary>
        /// <para>节点拖拽操作结束之前的回调函数，并且根据返回值确定是否允许此拖拽操作</para> 
        /// <para>function(treeID,Array(JSON) treeNodes,targetNode,moveType){}</para> 
        /// <para>如果拖拽成为根节点，则 targetNode = null</para>
        /// <para>moveType["inner"：成为子节点，"prev"：成为同级前一个节点，"next"：成为同级后一个节点]</para>
        /// </summary>
        public string BeforeDrop
        {
            get { return _BeforeDrop; }
            set { _BeforeDrop = value; }
        }
        private string _BeforeExpand;
        /// <summary>
        /// <para>父节点展开之前的回调函数，并且根据返回值确定是否允许展开操作</para>
        /// function(treeID,treeNode){}
        /// </summary>
        public string BeforeExpand
        {
            get { return _BeforeExpand; }
            set { _BeforeExpand = value; }
        }
        private string _BeforeMouseDown;
        /// <summary>
        /// <para>Tree 上鼠标按键按下之前的回调函数，并且根据返回值确定触发onMouseDown回调函数</para>
        /// <para>function(treeID,treeNode){}</para>
        /// 如果不在节点上，treeNode返回 null
        /// </summary>
        public string BeforeMouseDown
        {
            get { return _BeforeMouseDown; }
            set { _BeforeMouseDown = value; }
        }
        private string _BeforeMouseUp;
        /// <summary>
        /// <para>Tree 上鼠标按键按下之前的回调函数，并且根据返回值确定触发onMouseUp回调函数</para>
        /// <para>function(treeID,treeNode){}</para>
        /// 如果不在节点上，treeNode返回 null
        /// </summary>
        public string BeforeMouseUp
        {
            get { return _BeforeMouseUp; }
            set { _BeforeMouseUp = value; }
        }
        private string _BeforeRemove;
        /// <summary>
        /// <para>节点被删除之前的回调函数，并且根据返回值确定是否允许删除操作</para>
        /// <para>function(treeID,treeNode){}</para>
        /// </summary>
        public string BeforeRemove
        {
            get { return _BeforeRemove; }
            set { _BeforeRemove = value; }
        }
        private string _BeforeRename;
        /// <summary>
        /// <para>节点编辑名称结束(Input 失去焦点 或 按下 Enter 键)之后,更新节点名称数据之前的回调函数,并且根据返回值确定是否允许更改名称</para>
        /// <para>1、如果编辑名称结束后，名称未改变，则不会触发此回调函数</para>
        /// <para>2、节点进入编辑名称状态后,按 ESC 键可以放弃当前修改,恢复原名称,取消编辑名称状态</para>
        /// <para>function(treeID,treeNode,newName){}</para>
        /// </summary>
        public string BeforeRename
        {
            get { return _BeforeRename; }
            set { _BeforeRename = value; }
        }
        private string _BeforeRightClick;
        /// <summary>
        /// <para>Tree上鼠标右键点击之前的回调函数,并且根据返回值确定触发onRightClick回调函数</para>
        /// <para>function(treeID,treeNode){}</para>
        /// 如果不在节点上，treeNode返回 null
        /// </summary>
        public string BeforeRightClick
        {
            get { return _BeforeRightClick; }
            set { _BeforeRightClick = value; }
        }
        #endregion

        #region 客户端On事件集合
        private string _OnAsyncError;
        /// <summary>
        /// <para>异步加载出现异常错误的事件回调函数</para>
        /// <para>function(event,treeID,treeNode,XMLHttpRequest,textStatus,errorThrown){}</para>
        /// </summary>
        public string OnAsyncError
        {
            get { return _OnAsyncError; }
            set { _OnAsyncError = value; }
        }
        private string _OnAsyncSuccess;
        /// <summary>
        /// <para>异步加载正常结束的事件回调函数</para>
        /// <para>function(event,treeID,treeNode,msg){}</para>
        /// </summary>
        public string OnAsyncSuccess
        {
            get { return _OnAsyncSuccess; }
            set { _OnAsyncSuccess = value; }
        }
        private string _OnCheck;
        /// <summary>
        /// <para>checkbox / radio 被勾选 或 取消勾选的事件回调函数</para>
        /// <para>function(event,treeID,treeNode){}</para>
        /// </summary>
        public string OnCheck
        {
            get { return _OnCheck; }
            set { _OnCheck = value; }
        }
        private string _OnClick;
        /// <summary>
        /// <para>节点被点击的事件回调函数</para>
        /// <para>function(event,treeID,treeNode,clickFlag){}</para>
        /// </summary>
        public string OnClick
        {
            get { return _OnClick; }
            set { _OnClick = value; }
        }
        private string _OnCollapse;
        /// <summary>
        /// <para>节点被折叠的事件回调函数</para>
        /// <para>function(event,treeID,treeNode){}</para>
        /// </summary>
        public string OnCollapse
        {
            get { return _OnCollapse; }
            set { _OnCollapse = value; }
        }
        private string _OnDblClick;
        /// <summary>
        /// <para>Tree上鼠标双击之后的事件回调函数</para>
        /// <para>function(event,treeID,treeNode){}</para>
        /// 如果不在节点上，则treeNode返回 null
        /// </summary>
        public string OnDblClick
        {
            get { return _OnDblClick; }
            set { _OnDblClick = value; }
        }
        private string _OnDrag;
        /// <summary>
        /// <para>节点被拖拽的事件回调函数</para>
        /// <para>function(event,treeID,Array(JSON) treeNodes){}</para>
        /// </summary>
        public string OnDrag
        {
            get { return _OnDrag; }
            set { _OnDrag = value; }
        }
        private string _OnDrop;
        /// <summary>
        /// <para>节点拖拽操作结束的事件回调函数</para>
        /// <para>function(event,treeID,Array(JSON) treeNodes,targetNode,moveType){}</para> 
        /// <para>如果拖拽成为根节点，则 targetNode = null</para>
        /// <para>moveType["inner"：成为子节点，"prev"：成为同级前一个节点，"next"：成为同级后一个节点]</para>
        /// </summary>
        public string OnDrop
        {
            get { return _OnDrop; }
            set { _OnDrop = value; }
        }
        private string _OnExpand;
        /// <summary>
        /// <para>节点被展开的事件回调函数</para>
        /// <para>function(event,treeID,treeNode){}</para>
        /// </summary>
        public string OnExpand
        {
            get { return _OnExpand; }
            set { _OnExpand = value; }
        }
        private string _OnMouseDown;
        /// <summary>
        /// <para>Tree上鼠标按键按下后的事件回调函数</para>
        /// <para>function(event,treeID,treeNode){}</para>
        /// 如果不在节点上，则treeNode返回 null
        /// </summary>
        public string OnMouseDown
        {
            get { return _OnMouseDown; }
            set { _OnMouseDown = value; }
        }
        private string _OnMouseUp;
        /// <summary>
        /// <para>Tree上鼠标按键按下后的事件回调函数</para>
        /// <para>function(event,treeID,treeNode){}</para>
        /// 如果不在节点上，则treeNode返回 null
        /// </summary>
        public string OnMouseUp
        {
            get { return _OnMouseUp; }
            set { _OnMouseUp = value; }
        }
        private string _OnNodeCreated;
        /// <summary>
        /// <para>节点生成 DOM 后的事件回调函数</para>
        /// <para>对于父节点为展开的子节点来说，初始化后是不会触发此回调函数，直到其父节点被展开</para>
        /// <para>大数据量的节点加载请注意：不设置 onNodeCreated，可以提升一部分初始化性能</para>
        /// <para>function(event,treeID,treeNode){}</para>
        /// 如果不在节点上，则treeNode返回 null
        /// </summary>
        public string OnNodeCreated
        {
            get { return _OnNodeCreated; }
            set { _OnNodeCreated = value; }
        }
        private string _OnRemove;
        /// <summary>
        /// <para>删除节点之后的事件回调函数</para>
        /// <para>执行 removeNode 方法也会触发此回调函数，这时不受 beforeRemove 影响</para>
        /// <para>function(event,treeID,treeNode){}</para>
        /// </summary>
        public string OnRemove
        {
            get { return _OnRemove; }
            set { _OnRemove = value; }
        }
        private string _OnRename;
        /// <summary>
        /// <para>节点编辑名称结束之后的事件回调函数</para>
        /// <para>1、节点进入编辑名称状态，并且修改节点名称后触发此回调函数</para>
        /// <para>2、如果通过直接修改treeNode的数据，并且利用updateNode方法更新，是不会触发此回调函数的</para>
        /// <para>function(event,treeID,treeNode){}</para>
        /// </summary>
        public string OnRename
        {
            get { return _OnRename; }
            set { _OnRename = value; }
        }
        private string _OnRightClick;
        /// <summary>
        /// <para>Tree上鼠标右键点击之后的事件回调函数</para>
        /// <para>function(event,treeID,treeNode){}</para>
        /// 如果不在节点上，则treeNode返回 null
        /// </summary>
        public string OnRightClick
        {
            get { return _OnRightClick; }
            set { _OnRightClick = value; }
        }
        #endregion
        public ZTree() { }
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Ul;
            }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            writer.AddAttribute("class", "ztree");
            //writer.AddAttribute("id", this.ID);
            base.Render(writer);
        }
        //public override void RenderControl(HtmlTextWriter writer)
        //{
        //    writer.Write("<ul class=\"ztree\" id=\"" + this.ID + "\"></ul>");
        //    base.RenderControl(writer);
        //}
        protected override void OnPreRender(EventArgs e)
        {
            CreateTreeScript();
            base.OnPreRender(e);
            
        }
        private void CreateTreeScript()
        {
            string treeID = this.ID;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.Append("$(function(){");

            #region 生成节点数据
            if (this.DataSource != null)
            {
                this.SimpleData.Enable = true;
                foreach (DataRow row in this.DataSource.Rows)
                {
                    TreeItem node = new TreeItem();
                    node.ID = row[this.SimpleData.IDKey].ToString();
                    node.PID = row[this.SimpleData.PIDKey].ToString();
                    node.Text = row[this.SimpleData.TextField].ToString();
                    if(!string.IsNullOrEmpty(this.SimpleData.ValueField)){
                        node.Value = row[this.SimpleData.ValueField].ToString();
                    }
                    if (this.SimpleData.AttributeFields.Count > 0)
                    {
                        foreach (string key in this.SimpleData.AttributeFields.Keys)
                        {
                            node.Attributes.Add(this.SimpleData.AttributeFields[key], row[key]);
                        }
                    }
                    this.Items.Add(node);
                }
            }
            if (this.Items.Count > 0)
            {
                sb.Append("var data=" + ZTreeMgr.GetzTreeData(this.Items) + ";");
            }
            else
            {
                sb.Append("var data=null;");
            }
            sb.AppendLine("");
            #endregion
            //生成配置参数选项
            sb.Append("var setting={");
            //sb.Append("treeId:\""+this.ID+"\",");
            #region 配置视图参数
            sb.Append("view:{");
            sb.Append("selectedMulti:" + WSH.Web.Common.Helper.ClientHelper.GetBool(this.View.SelectedMulti));
            if (this.View.SelectedMulti)
            {
                this.View.AutoCancelSelected = true;
            }
            sb.Append(",autoCancelSelected:" + WSH.Web.Common.Helper.ClientHelper.GetBool(this.View.AutoCancelSelected));
            if (!this.View.ShowLine)
            {
                sb.Append(",showLine:false");
            }
            if (!this.View.ShowIcon)
            {
                sb.Append(",showIcon:false");
            }
            if (!this.View.ShowTitle)
            {
                sb.Append(",showTitle:false");
            }
            if (!this.View.DblClickExpand)
            {
                sb.Append(",dblClickExpand:false");
            }
            if (this.View.FontCss.Count > 0)
            {
                sb.Append(",fontCss:" + WSH.Web.Common.Helper.ClientHelper.GetDictionary(this.View.FontCss));
            }
            if (!string.IsNullOrEmpty(this.View.AddDiyDom))
            {
                sb.Append(",addDiyDom:" + this.View.AddDiyDom);
            }
            if (!string.IsNullOrEmpty(this.View.AddHoverDom))
            {
                sb.Append(",addHoverDom:" + this.View.AddHoverDom);
            }
            if (!string.IsNullOrEmpty(this.View.RemoveHoverDom))
            {
                sb.Append(",removeHoverDom:" + this.View.RemoveHoverDom);
            }
            sb.Append("}");
            #endregion

            #region 配置异步参数
            if (this.Async.Enable)
            {
                sb.Append(",async:{");
                sb.Append("enable:" + WSH.Web.Common.Helper.ClientHelper.GetBool(Async.Enable));
                sb.Append(",dataType:\"" + WSH.Web.Common.Helper.ClientHelper.GetEnum(Async.DataType) + "\"");
                if (!string.IsNullOrEmpty(Async.DataFilter))
                {
                    sb.Append(",dataFilter:\"" + Async.DataFilter + "\"");
                }
                if (Async.AutoParam != null)
                {
                    sb.Append(",autoParam:" + WSH.Web.Common.Helper.ClientHelper.GetArray(Async.AutoParam));
                }
                if (Async.OtherParam.Count > 0)
                {
                    sb.Append(",otherParam:" + WSH.Web.Common.Helper.ClientHelper.GetDictionary(Async.OtherParam));
                }
                sb.Append(",url:\"" + Async.Url + "\"");
                sb.Append(",type:\"" + Async.Type.ToString().ToLower() + "\"");
                sb.Append("}");
            }
            #endregion

            #region 配置选择参数
            if (this.Check.Enable)
            {
                sb.Append(",check:{");
                sb.Append("enable:" + WSH.Web.Common.Helper.ClientHelper.GetBool(this.Check.Enable));
                sb.Append(",chkStyle:\"" + WSH.Web.Common.Helper.ClientHelper.GetEnum(this.Check.CheckStyle) + "\"");
                if (this.Check.CheckStyle == CheckStyle.Radio)
                {
                    sb.Append(",radioType:\"" + WSH.Web.Common.Helper.ClientHelper.GetEnum(this.Check.RadioType) + "\"");
                }
                else
                {
                    sb.Append(",chkboxType:" + (this.Check.TwoWay ? "{Y:\"ps\",N:\"ps\"}" : "{Y:\"\",N:\"\"}"));
                }
                sb.Append("}");
            }
            #endregion

             #region 配置客户端的回调函数
            sb.Append(",callback:{");
            //首先配置单击回调函数
            sb.Append("onClick:" + (string.IsNullOrEmpty(OnClick) ? "null" : OnClick));

            #region 配置Before回调
            if (!string.IsNullOrEmpty(BeforeAsync))
            {
                sb.Append(",beforeAsync:" + BeforeAsync);
            }
            if (!string.IsNullOrEmpty(BeforeCheck))
            {
                sb.Append(",beforeCheck:" + BeforeCheck);
            }
            if (!string.IsNullOrEmpty(BeforeClick))
            {
                sb.Append(",beforeClick:" + BeforeClick);
            }
            if (!string.IsNullOrEmpty(BeforeCollapse))
            {
                sb.Append(",beforeCollapse:" + BeforeCollapse);
            }
            if (!string.IsNullOrEmpty(BeforeDblClick))
            {
                sb.Append(",beforeDblClick:" + BeforeDblClick);
            }
            if (!string.IsNullOrEmpty(BeforeDrag))
            {
                sb.Append(",beforeDrag:" + BeforeDrag);
            }
            if (!string.IsNullOrEmpty(BeforeDragOpen))
            {
                sb.Append(",beforeDragOpen:" + BeforeDragOpen);
            }
            if (!string.IsNullOrEmpty(BeforeDrop))
            {
                sb.Append(",beforeDrop:" + BeforeDrop);
            }
            if (!string.IsNullOrEmpty(BeforeExpand))
            {
                sb.Append(",beforeExpand:" + BeforeExpand);
            }
            if (!string.IsNullOrEmpty(BeforeMouseDown))
            {
                sb.Append(",beforeMouseDown:" + BeforeMouseDown);
            }
            if (!string.IsNullOrEmpty(BeforeMouseUp))
            {
                sb.Append(",beforeMouseUp:" + BeforeMouseUp);
            }
            if (!string.IsNullOrEmpty(BeforeRemove))
            {
                sb.Append(",beforeRemove:" + BeforeRemove);
            }
            if (!string.IsNullOrEmpty(BeforeRename))
            {
                sb.Append(",beforeRename:" + BeforeRename);
            }
            if (!string.IsNullOrEmpty(BeforeRightClick))
            {
                sb.Append(",beforeRightClick:" + BeforeRightClick);
            }
            #endregion

            #region 配置On回调
            if (!string.IsNullOrEmpty(OnAsyncError))
            {
                sb.Append(",onAsyncError:" + OnAsyncError);
            }
            if (!string.IsNullOrEmpty(OnAsyncSuccess))
            {
                sb.Append(",onAsyncSuccess:" + OnAsyncSuccess);
            }
            if (!string.IsNullOrEmpty(OnCheck))
            {
                sb.Append(",onCheck:" + OnCheck);
            }
            if (!string.IsNullOrEmpty(OnCollapse))
            {
                sb.Append(",onCollapse:" + OnCollapse);
            }
            if (!string.IsNullOrEmpty(OnDblClick))
            {
                sb.Append(",onDblClick:" + OnDblClick);
            }
            if (!string.IsNullOrEmpty(OnDrag))
            {
                sb.Append(",onDrag:" + OnDrag);
            }
            if (!string.IsNullOrEmpty(OnDrop))
            {
                sb.Append(",onDrop:" + OnDrop);
            }
            if (!string.IsNullOrEmpty(OnExpand))
            {
                sb.Append(",onExpand:" + OnExpand);
            }
            if (!string.IsNullOrEmpty(OnMouseDown))
            {
                sb.Append(",onMouseDown:" + OnMouseDown);
            }
            if (!string.IsNullOrEmpty(OnMouseUp))
            {
                sb.Append(",onMouseUp:" + OnMouseUp);
            }
            if (!string.IsNullOrEmpty(OnNodeCreated))
            {
                sb.Append(",onNodeCreated:" + OnNodeCreated);
            }
            if (!string.IsNullOrEmpty(OnRemove))
            {
                sb.Append(",onRemove:" + OnRemove);
            }
            if (!string.IsNullOrEmpty(OnRename))
            {
                sb.Append(",onRename:" + OnRename);
            }
            if (!string.IsNullOrEmpty(OnRightClick))
            {
                sb.Append(",onRightClick:" + OnRightClick);
            }
            #endregion

            sb.Append("}");
            #endregion

            #region 配置编辑功能参数
            if (this.Edit.Enable)
            {
                sb.Append(",edit:{");
                sb.Append("enable:" + WSH.Web.Common.Helper.ClientHelper.GetBool(this.Edit.Enable));
                sb.AppendFormat(",removeTitle:\"{0}\"", this.Edit.RemoveTitle);
                sb.AppendFormat(",renameTitle:\"{0}\"", this.Edit.RenameTitle);
                if (!this.Edit.ShowRemoveBtn)
                {
                    sb.Append(",showRemoveBtn=false");
                }
                if (!this.Edit.ShowRenameBtn)
                {
                    sb.Append(",showRenameBtn=false");
                }

                #region 配置拖动功能参数
                sb.Append(",drag:{");
                sb.Append("isCopy:" + WSH.Web.Common.Helper.ClientHelper.GetBool(this.Drag.IsCopy));
                sb.Append(",isMove:" + WSH.Web.Common.Helper.ClientHelper.GetBool(this.Drag.IsMove));
                if (this.Drag.IsMove || this.Drag.IsCopy)
                {
                    if (!this.Drag.Prev)
                    {
                        sb.Append(",prev:false");
                    }
                    if (!this.Drag.Next)
                    {
                        sb.Append(",next:false");
                    }
                    if (!this.Drag.Inner)
                    {
                        sb.Append(",inner:false");
                    }
                    sb.Append(",maxShowNodeNum:" + this.Drag.MaxShowNodeNum.ToString());
                }
                sb.Append("}");

                #endregion

                sb.Append("}");
            }
            #endregion

            sb.Append("};");
            sb.AppendLine("");
            sb.AppendLine("var " + treeID + "=song.ztree.init($(\"#" + this.ClientID + "\"),setting,data);");
            sb.AppendLine("});");
            Script.RegisterStartupScript(this.Page, "ZTree-"+this.ID, sb.ToString());
        }
    }
}
