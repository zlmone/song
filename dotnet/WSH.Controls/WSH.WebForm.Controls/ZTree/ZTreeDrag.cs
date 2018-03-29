using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.WebForm.Controls
{
    public class ZTreeDrag
    {
        private bool _IsCopy=false;
        /// <summary>
        /// 是否允许复制节点（默认：false）
        /// </summary>
        public bool IsCopy
        {
            get { return _IsCopy; }
            set { _IsCopy = value; }
        }
        private bool _IsMove = false;
        /// <summary>
        /// 是否允许移动节点，与IsCopy不冲突（默认：false）
        /// </summary>
        public bool IsMove
        {
            get { return _IsMove; }
            set { _IsMove = value; }
        }
        private bool _Prev = true;
        /// <summary>
        /// <para>拖拽到目标节点时，是否允许移动到目标节点前面的操作</para>
        /// <para>拖拽目标是 根 的时候，不触发 prev 和 next，只会触发 inner</para>
        /// </summary>
        public bool Prev
        {
            get { return _Prev; }
            set { _Prev = value; }
        }
        private bool _Next = true;
        /// <summary>
        /// <para>拖拽到目标节点时，是否允许移动到目标节点后面的操作</para>
        /// <para>拖拽目标是 根 的时候，不触发 prev 和 next，只会触发 inner</para>
        /// </summary>
        public bool Next
        {
            get { return _Next; }
            set { _Next = value; }
        }
        private bool _Inner = true;
        /// <summary>
        /// <para>拖拽到目标节点时，是否允许成为目标节点的子节点</para>
        /// <para>拖拽目标是 根 的时候，不触发 prev 和 next，只会触发 inner</para>
        /// </summary>
        public bool Inner
        {
            get { return _Inner; }
            set { _Inner = value; }
        }
        private int _MaxShowNodeNum = 5;
        /// <summary>
        /// 设置同级多节点拖拽操作时跟随鼠标移动的最大节点数，多余节点用...代替
        /// </summary>
        public int MaxShowNodeNum
        {
            get { return _MaxShowNodeNum; }
            set { _MaxShowNodeNum = value; }
        }
    }
}
