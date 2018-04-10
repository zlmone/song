using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSH.WinForm.Controls
{
    /*
    1、仅支持输入0~9/小数点/负号/Backspace/Del/方向键等
    2、可在任意位置输入负号，自动显示在最前面，已有负号的话，自动去除负号。
    3、能自动正确识别小数
    4、数字不允许以0开头
    5、处理复制的数据
    6、对最终结果进行格式化
     */
    public partial class NumberBox : InputBox
    {
        public NumberBox()
        {
            InitializeComponent();
        }
        public override WSH.Common.RegexType RegexType
        {
            get
            {
                return WSH.Common.RegexType.None;
            }
        }
        private bool allowDecimal = true;
        /// <summary>
        /// 是否允许输入小数
        /// </summary>
        public bool AllowDecimal
        {
            get { return allowDecimal; }
            set { allowDecimal = value; }
        }
        private bool allowNegative=true;
        /// <summary>
        /// 是否允许输入负数
        /// </summary>
        public bool AllowNegative
        {
            get { return allowNegative; }
            set { allowNegative = value; }
        }
        private long maxValue = long.MaxValue;
        /// <summary>
        /// 最大值
        /// </summary>
        public long MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }
        private long minValue = long.MinValue;
        /// <summary>
        /// 最小值
        /// </summary>
        public long MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            //float _isFloat = 0;
            //float.TryParse(this.Text, out _isFloat);
          //  this.Text = _isFloat.ToString();

            base.OnLostFocus(e);
            string text = this.Text.Trim();
            //判断最大值和最小值
            if (!string.IsNullOrWhiteSpace(text))
            {
                this.Select(this.Text.Length, 0);

                long value = Convert.ToInt64(text);
                if (value > this.MaxValue)
                {
                    this.Text = this.MaxValue.ToString();
                }
                if (value < this.MinValue)
                {
                    this.Text = this.MinValue.ToString();
                }
            }
        }
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            e.Handled = true;
            //不能输入负数
            if (!this.AllowNegative && ch == 45)
            {
                return;
            }

            int startBase = base.SelectionStart;

            /// 处理负号
            if (ch == 45)
            {

                if (this.Text == "")
                    e.Handled = false;
                else if (!this.Text.StartsWith("-"))
                {
                    /// 没有负号
                    this.Text = "-" + this.Text;
                    this.Select(startBase + 1, 0);
                }
                else
                {
                    /// 有负号
                    this.Text = this.Text.Remove(0, 1);
                    if (startBase > 0)
                        this.Select(startBase - 1, 0);
                    else
                        this.Select(0, 0);
                }
                return;
            }

            /// 数字，Backspace
            if ((ch > 47 && ch < 58) || ch == 8)
            {
                e.Handled = false;

                if (this.Text == "" || this.Text == "-")
                    return;

                if (this.Text == "0" || this.Text == "-0")
                {
                    if (ch == 48)
                        e.Handled = true;
                    else
                    {
                        if (this.Text.StartsWith("-"))
                            this.Text = "-";
                        else
                            this.Text = "";
                        this.Select(this.Text.Length, 0);
                    }
                    return;
                }
                if (this.Text == "0." || this.Text == "-0.")
                    return;

                if (ch != 8)
                {
                    if (base.SelectionStart < this.Text.Length)
                    {
                        int start = base.SelectionStart;
                        string previewText = this.Text.Substring(0, base.SelectionStart) + e.KeyChar.ToString() + this.Text.Substring(base.SelectionStart);
                        float oldFloat = 0;
                        float isFloat = 0;
                        float.TryParse(previewText, out isFloat);
                        float.TryParse(this.Text, out oldFloat);

                        if (isFloat != 0)
                        {
                            this.Text = isFloat.ToString();
                            if (oldFloat != isFloat)
                                this.Select(start + 1, 0);
                            else
                                this.Select(start, 0);
                        }
                        e.Handled = true;
                    }
                }
                return;
            }

            /// 小数点
            if (ch == 46)
            {
                if (!AllowDecimal)
                {
                    return;
                }
                if (this.Text.IndexOf(".") < 0)
                    e.Handled = false;
            }
        }
    }
}
