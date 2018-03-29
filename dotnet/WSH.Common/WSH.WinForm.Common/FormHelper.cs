using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WSH.WinForm.Common
{
    public class FormHelper
    {
        public static void SetNoresize(Form frm)
        {
            if (frm != null)
            {
                frm.MaximizeBox = false;
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }
    }
}
