using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.Common.Helper;

namespace WSH.Tools.Internet
{
    public partial class FateLogin : Form
    {
        public FateLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            Login();
        }
        public void Login() {
            string kl = this.txtPwd.Text.Trim();
            if (!string.IsNullOrWhiteSpace(kl))
            {
                if (kl == CryptHelper.DecryptDES("r0mPNKt0G2w=") || kl == CryptHelper.DecryptDES("EKyPX1aRereBf31DNCRu2w=="))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                 
            }
             
        }
        private void FateLogin_Load(object sender, EventArgs e)
        {
            this.txtPwd.Select();
            this.txtPwd.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}
