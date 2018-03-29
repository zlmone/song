using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WSH.WinForm.Controls
{
    public partial class Loading : UserControl
    {
        public  string Text{
            set { this.lbLoadingText.Text = value; }
            get { return this.lbLoadingText.Text; }
        }
        public Loading()
        {
            InitializeComponent();
        }
    }
}
