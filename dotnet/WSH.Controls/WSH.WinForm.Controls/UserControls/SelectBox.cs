using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WSH.WinForm.Controls
{
    public partial class SelectBox : UserControl
    {
        public SelectBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 选择框的显示文本
        /// </summary>
        public new string Text {
            get { return this.inputBox1.Text.Trim(); }
            set { this.inputBox1.Text = value; }
        }
        /// <summary>
        /// 保存选择框的值
        /// </summary>
        public string Value;
        /// <summary>
        /// 是否允许编辑
        /// </summary>
        public bool AllowEdit{
            get{return this.inputBox1.Enabled;}
            set{this.inputBox1.Enabled=value;}
        }
        /// <summary>
        /// 选择事件
        /// </summary>
        public event EventHandler OnSelect;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(OnSelect!=null){
                OnSelect(sender,e);
            }
        }
    }
}