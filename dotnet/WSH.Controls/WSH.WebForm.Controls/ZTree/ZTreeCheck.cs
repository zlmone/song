using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.WebForm.Controls
{
    /// <summary>
    /// radio的分组范围
    /// </summary>
    public enum RadioType { 
        Level,All
    }
    public enum CheckStyle{
        CheckBox,Radio
    }
    public class ZTreeCheck
    {
        private bool _Enable = false;
        /// <summary>
        /// 是否启用选择功能（默认：false）
        /// </summary>
        public bool Enable
        {
            get { return _Enable; }
            set { _Enable = value; }
        }
        private CheckStyle _CheckStyle= CheckStyle.CheckBox;
        /// <summary>
        /// 选择框类型（单选框还是复选框，默认：CheckBox）
        /// </summary>
        public CheckStyle CheckStyle
        {
            get { return _CheckStyle; }
            set { _CheckStyle = value; }
        }
        private RadioType _RadioType= RadioType.All;
        /// <summary>
        /// 单选框的分组范围（默认：整棵树为分组范围）
        /// </summary>
        public RadioType RadioType
        {
            get { return _RadioType; }
            set { _RadioType = value; }
        }
        private bool _TwoWay=true;
        /// <summary>
        /// 复选框选择模式是否启动级联选择（默认：true）
        /// </summary>
        public bool TwoWay
        {
            get { return _TwoWay; }
            set { _TwoWay = value; }
        }
    }
}
