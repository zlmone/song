using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSH.WinForm.Controls
{
    public partial class BaseMdiForm : Form
    {
        public BaseMdiForm()
        {
            InitializeComponent();
        }
        public void ShowChildForm(Form form)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == form.Name)
                {
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    form.Close();
                    return;
                }
            }
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }
    }
}
