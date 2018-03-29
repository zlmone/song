using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WSH.Common.Helper;
using WSH.WinForm.Common;

namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            Utils.SetFormNoresize(this);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void About_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MsgBox.Alert("当前已经是最新版本");
        }

        private void buttonImage1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
