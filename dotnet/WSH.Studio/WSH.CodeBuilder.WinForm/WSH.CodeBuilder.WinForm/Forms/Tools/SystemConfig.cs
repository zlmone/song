using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.Common.Configuration;
using WSH.WinForm.Controls;

namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    public partial class SystemConfig : BaseEditForm
    {

        public SystemConfig()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Utils.SetFormNoresize(this);
        }

        private void SysteConfig_Load(object sender, EventArgs e)
        {
            ConfigurationState state = new ConfigurationState();
            this.checkAutoLogon.Checked = state.Get(StateKeys.IsAutoLogon) == "1" ? true : false;
            this.checkAutoUpdate.Checked = state.Get(StateKeys.IsAutoUpdate) == "1" ? true : false;
        }

        public override bool SaveData()
        {
            ConfigurationState state = new ConfigurationState();
            state.Set(StateKeys.IsAutoLogon, this.checkAutoLogon.Checked ? "1" : "0");
            state.Set(StateKeys.IsAutoUpdate, this.checkAutoUpdate.Checked ? "1" : "0");
            return true;
        }
    }
}
