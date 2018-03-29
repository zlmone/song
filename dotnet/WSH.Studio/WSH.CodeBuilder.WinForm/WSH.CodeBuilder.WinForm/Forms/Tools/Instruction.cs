using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.CodeBuilder.WinForm.Common;
using WSH.Common.Helper;
using System.IO;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    public partial class Instruction : DocumentForm
    {
        public Instruction()
        {
            InitializeComponent();

        }

        private void Instruction_Load(object sender, EventArgs e)
        {
            this.web.Navigate(ServiceHelper.CodeBuilderInstructionUrl);
        }
    }
}
