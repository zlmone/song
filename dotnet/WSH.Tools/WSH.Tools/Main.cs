using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.Tools.Common;

namespace WSH.Tools
{
    public partial class Main : BaseForm
    {
        public Main()
        {
            InitializeComponent();
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackColor = this.BackColor;
                }
            }
            FrmFormatCode f = new FrmFormatCode();
            ShowChildForm(f);
        }
        public void ShowChildForm(Form form)
        {
            foreach (Form f in this.MdiChildren)
            {
                if(f.Name==form.Name){
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
        private void menuObjectBuilder_Click(object sender, EventArgs e)
        {
            FrmObjectBuilder builder = new FrmObjectBuilder();
            ShowChildForm(builder);
        }

        private void menuBackgroundSplit_Click(object sender, EventArgs e)
        {
           
        }

        private void menuCrypt_Click(object sender, EventArgs e)
        {
            FrmCrypt c = new FrmCrypt();
            ShowChildForm(c);
        }

        private void menuFmtCode_Click(object sender, EventArgs e)
        {
            FrmFormatCode f = new FrmFormatCode();
            ShowChildForm(f);
        }

        private void menuToExcel_Click(object sender, EventArgs e)
        {
            
        }

        private void menuControl_Click(object sender, EventArgs e)
        {
            FrmControlBuilder c = new FrmControlBuilder();
            ShowChildForm(c);
        }

        private void menuClearIIS_Click(object sender, EventArgs e)
        {
            
        }

        private void menuDataMining_Click(object sender, EventArgs e)
        {
             
        }

        private void menuAddressBook_Click(object sender, EventArgs e)
        {
            FrmAddressBook a = new FrmAddressBook();
            ShowChildForm(a);
        }
 
        
    }
}
