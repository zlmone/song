using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WSH.CodeBuilder.WinForm.Common
{
    public partial class DocumentForm : DockContent
    {
        public DocumentForm()
        {
            InitializeComponent();
            
            
        }

        private void menuCloseCurrent_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuCloseAll_Click(object sender, EventArgs e)
        {
            IDockContent[] documents = DockPanel.DocumentsToArray();

            foreach (IDockContent content in documents)
            {
                content.DockHandler.Close();
            }
        }

        private void menuCloseOther_Click(object sender, EventArgs e)
        {
            IDockContent[] documents = DockPanel.DocumentsToArray();

            foreach (IDockContent content in documents)
            {
                if (!content.Equals(this))
                {
                    content.DockHandler.Close();
                }
            }
        }

    }
}
