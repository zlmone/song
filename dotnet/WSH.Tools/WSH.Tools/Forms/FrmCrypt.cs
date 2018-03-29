using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.Tools.Common;
using WSH.Common;
using WSH.WinForm.Common;
using WSH.Common.Helper;

namespace WSH.Tools
{
    public partial class FrmCrypt : BaseForm
    {
        public FrmCrypt()
        {
            InitializeComponent();
            this.cobType.SelectedIndex = 0;
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            string text = this.richBeginText.Text;
            if (text.Trim() != string.Empty)
            {
                string type = this.cobType.Text;
                string str = "";
                switch (type)
                {
                    case "md5-long":
                        {
                            str = CryptHelper.Md5Long(str);
                        }; break;
                    case "md5-short":
                        {
                            str = CryptHelper.Md5Short(str);
                        }; break;
                    case "default":
                        {
                            str = CryptHelper.EncryptDES(text);
                        }; break;
                }
                this.richEndText.Text = str;
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            string text = richBeginText.Text;
            if (text.Trim()!=string.Empty)
            {
                try
                {
                    string type = this.cobType.Text;
                    string str = "";
                    if (type == "default")
                    {
                        str = CryptHelper.DecryptDES(text);
                    }
                    this.richEndText.Text = str;
                }
                catch (Exception ex)
                {
                    MsgBox.Alert("解密失败！" + ex.Message);
                }
            }
        }
    }
}
