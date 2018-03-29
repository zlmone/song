using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Common;
using WSH.Common.Helper;
using System.IO;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common.Configuration;

namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    public partial class TemplateExport : Form
    {
        private string exportKey = "CodeBuilderExportTemplatePath";
        public string TemplateTypeID;
        public TemplateExport()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.selectDialog.Type = Windows.Common.DialogType.Folder;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportCheckedTemplate();
        }
        private List<string> ExportCheckedTemplate() {
            List<TemplateEntity> templates = template.GetCheckedFile();
            string exportPath = this.selectDialog.Text;
            if (templates.Count <= 0)
            {
                MsgBox.Alert("请选择需要导出的模板");
            }
            else if (string.IsNullOrEmpty(exportPath))
            {
                MsgBox.Alert("请选择导出地址");
            }
            else
            {
                List<string> files = new List<string>();
                //导出模板
                foreach (TemplateEntity templ in templates)
                {
                    string filePath=Path.Combine(exportPath,template.GetTemplateFileName(templ));
                    FileHelper.WriteFile(filePath, templ.Content);
                    files.Add(filePath);
                }
                if(MsgBox.Confirm("导出完成，是否打开目录？")){
                    FileHelper.OpenPath(exportPath,files[0]);
                }
                return files;
            }
            return null;
        }

        private void TemplateExport_Load(object sender, EventArgs e)
        {
            this.template.IsShowExport = false;
            this.template.IsShowCheckBox = true;
            if (!string.IsNullOrEmpty(TemplateTypeID))
            {
                template.TemplateID =Convert.ToInt32( TemplateTypeID);
            }
            this.template.DataBind();
            ConfigurationState state = new ConfigurationState();
            string path=state.Get(exportKey);
            this.selectDialog.Text = path;
        }

        private void selectDialog_OnSelectDialogOk(object sender, string url)
        {
            ConfigurationState state = new ConfigurationState();
            state.Set(exportKey,url);
        }
    }
}
