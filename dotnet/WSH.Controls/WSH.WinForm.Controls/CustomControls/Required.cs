using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSH.WinForm.Controls
{
    public partial class Required : Label
    {
        public Required()
        {
            InitializeComponent();
            this.Text = "*";
            this.ForeColor = Color.Red;
        }
        public override string Text
        {
            get
            {
                return "*";
            }
            set
            {
                base.Text = value;
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
