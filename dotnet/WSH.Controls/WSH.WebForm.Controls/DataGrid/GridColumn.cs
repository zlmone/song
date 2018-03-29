using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using WSH.Web.Common;
using WSH.Common;
using System.Data;

namespace WSH.WebForm.Controls
{
    public  class GridColumn
    {
        public GridColumn() { 
            
        }
        private string _ID;
        /// <summary>
        /// 列的ID标示
        /// </summary>
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Field;
        /// <summary>
        /// 对应的数据字段
        /// </summary>
        public string Field
        {
            get { return _Field; }
            set { _Field = value; }
        }
        private string _Header;
        /// <summary>
        /// 列头显示的名称
        /// </summary>
        public string Header
        {
            get { return _Header; }
            set { _Header = value; }
        }
        private int _Width=100;
        /// <summary>
        /// 列的宽度
        /// </summary>
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        private AlignType _Align = AlignType.Left;
        /// <summary>
        /// 列文本的对齐方式
        /// </summary>
        public AlignType Align
        {
            get { return _Align; }
            set { _Align = value; }
        }
        private bool _Hidden=false;
        /// <summary>
        /// 是否显示列
        /// </summary>
        public bool Hidden
        {
            get { return _Hidden; }
            set { _Hidden = value; }
        }
        private bool _Sortable=false;
        /// <summary>
        /// 是否允许排序
        /// </summary>
        public bool Sortable
        {
            get { return _Sortable; }
            set { _Sortable = value; }
        }
        private bool _Resizable=true;
        /// <summary>
        /// 是否允许改变列宽
        /// </summary>
        public bool Resizable
        {
            get { return _Resizable; }
            set { _Resizable = value; }
        }
        private bool _Filterable=false;
        /// <summary>
        /// 是否允许过滤数据
        /// </summary>
        public bool Filterable
        {
            get { return _Filterable; }
            set { _Filterable = value; }
        }
        private bool _Editable=false;
        /// <summary>
        /// 是否允许编辑
        /// </summary>
        public bool Editable
        {
            get { return _Editable; }
            set { _Editable = value; }
        }
        private DbType _DataType = DbType.String;
        /// <summary>
        /// 数据类型
        /// </summary>
        public DbType DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }
        private string _Renderer;
        /// <summary>
        /// 客户端的渲染函数
        /// </summary>
        public string Renderer
        {
            get { return _Renderer; }
            set { _Renderer = value; }
        }
    }
    
}
