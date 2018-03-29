using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.WebForm.Controls
{
    public class ZTreeView
    {
        private bool _ShowLine=true;
        /// <summary>
        /// 是否显示边线（默认：true）
        /// </summary>
        public bool ShowLine
        {
            get { return _ShowLine; }
            set { _ShowLine = value; }
        }
        private bool _ShowTitle=true;
        /// <summary>
        /// 是否显示节点的Title（默认：true）
        /// </summary>
        public bool ShowTitle
        {
            get { return _ShowTitle; }
            set { _ShowTitle = value; }
        }
        private bool _ShowIcon=true;
        /// <summary>
        /// 是否显示节点图标（默认：true）
        /// </summary>
        public bool ShowIcon
        {
            get { return _ShowIcon; }
            set { _ShowIcon = value; }
        }
        private bool _SelectedMulti = false;
        /// <summary>
        /// 是否多选（默认：false）
        /// </summary>
        public bool SelectedMulti
        {
            get { return _SelectedMulti; }
            set { _SelectedMulti = value; }
        }
        private bool _DblClickExpand = true;
        /// <summary>
        /// 双击是否展开子节点（默认：true）
        /// </summary>
        public bool DblClickExpand
        {
            get { return _DblClickExpand; }
            set { _DblClickExpand = value; }
        }
        private bool _AutoCancelSelected = false;
        /// <summary>
        /// 是否配合Ctrl取消节点选择操作（默认：false）
        /// </summary>
        public bool AutoCancelSelected
        {
            get { return _AutoCancelSelected; }
            set { _AutoCancelSelected = value; }
        }
        private Dictionary<string, string> _FontCss=new Dictionary<string,string>();
        /// <summary>
        /// 节点字体范围样式（默认：null）
        /// </summary>
        public Dictionary<string, string> FontCss
        {
            get { return _FontCss; }
            set { _FontCss = value; }
        }

        private string _AddDiyDom;
        /// <summary>
        /// 添加节点自定义dom
        /// function(treeid,treeNode){
        ///     //获取节点的a连接dom
        ///     var aObj=$("#"+treeNode.tId+"_a");
        ///     aObj.append(dom);
        /// };
        /// </summary>
        public string AddDiyDom
        {
            get { return _AddDiyDom; }
            set { _AddDiyDom = value; }
        }
        private string _AddHoverDom;
        /// <summary>
        /// 添加鼠标移上去的节点自定义dom
        /// function(treeid,treeNode){
        ///     //获取节点的a连接dom
        ///     var aObj=$("#"+treeNode.tId+"_a");
        ///     aObj.append(dom);
        /// };
        /// </summary>
        public string AddHoverDom
        {
            get { return _AddHoverDom; }
            set { _AddHoverDom = value; }
        }
        private string _RemoveHoverDom;
        /// <summary>
        /// 移除鼠标移上去的节点自定义dom
        /// function(treeid,treeNode){
        ///     $(dom).unbind().remove();
        /// };
        /// </summary>
        public string RemoveHoverDom
        {
            get { return _RemoveHoverDom; }
            set { _RemoveHoverDom = value; }
        }
    }
}
