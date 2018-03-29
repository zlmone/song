using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    public partial class TemplateTree : DockContent
    {
        public TemplateTree()
        {
            InitializeComponent();
            this.HideOnClose = true;
        }

        private void TemplateTree_Load(object sender, EventArgs e)
        {
            this.template.DataBind();
        }
    }
}
