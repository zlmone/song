using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Controls;
using WSH.Common.Helper;
using WSH.Options.Common;
using System.IO;
using WSH.WinForm.Common;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common.Configuration;

namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    public partial class TemplateEdit : BaseEditForm
    {
        Validation v = new Validation();
        /// <summary>
        /// 文件内容是否改变
        /// </summary>
        public bool IsChange = false;
        private string OldContent = string.Empty;
        public TemplateEdit()
        {
            InitializeComponent();
        //    Utils.SetTextEditor(this.txtCode);
            v.Add(new ValidateItem(this.txtTemplateName) { Required = true });
            ConfigurationData config = new ConfigurationData();
            this.cboCodeType.DataSource = config.Get("CodeFileType");
            this.cboCodeType.DisplayMember = "Text";
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Maximized;
        }
        public int ParentID;
        public string TypeName;
        public string OldFileName;
        public override bool IsValid()
        {
            return v.IsValid();
        }
        public override void BindData()
        {
            using (CodeBuilderService service = ServiceHelper.GetCodeBuilderService())
            {
                TemplateEntity entity = service.GetTemplateById(this.RecordID);

                this.txtFileName.Text = entity.FileName;
                this.cboCodeType.Text = entity.FileExtensions.Replace(".", "");
                this.txtTemplateName.Text = entity.TemplateName;
                this.txtPrefix.Text = entity.FilePrefix;
                //this.txtCode.LoadFile(TemplateManager.GetTemplateFile(entity.TemplateName, TypeName), true, true);
                this.txtCode.Text = entity.Content;
               // Utils.SetEditorLang(this.txtCode, "cs");
            }
            //OldFileName = TemplateManager.GetTemplateFile(entity.TemplateName, TypeName);
            OldContent = this.txtCode.Text;
            BindTextBoxChange();
        }
        public override bool SaveData()
        {
            string templateName = this.txtTemplateName.Text.Trim();
            TemplateEntity entity = new TemplateEntity()
            {
                FileExtensions = "." + this.cboCodeType.Text,
                FilePrefix = this.txtPrefix.Text,
                FileName = this.txtFileName.Text,
                TemplateName = templateName,
                ParentID = ParentID,
                Content = this.txtCode.Text
            };
            bool result = false;
            using (CodeBuilderService service = ServiceHelper.GetCodeBuilderService())
            {
                if (string.IsNullOrEmpty(this.RecordID))
                {
                    result = service.AddTemplate(entity) > 0;
                }
                else
                {
                    entity.ID = Convert.ToInt32(RecordID);
                    result = service.UpdateTemplate(entity);
                }
            }
            //if (result)
            //{
            //    try
            //    {
            //        string fileName=TemplateManager.GetTemplateFile(templateName, TypeName);
            //        FileHelper.WriteFile(fileName, this.txtCode.Text);
            //        if (!string.IsNullOrEmpty(OldFileName) && fileName!=OldFileName)
            //        {
            //            File.Delete(OldFileName);
            //        }
            //        result = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        result = false;
            //        throw new Exception(ex.Message);
            //    }
            //}
            if (result)
            {
                //保存成功后，表示页面未发生改变
                IsChange = false;
                OldContent = entity.Content;
            }
            return result;
        }

        private void TemplateEdit_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            if (this.EditMode == WSH.WinForm.Controls.EditMode.Add)
            {
              //  Utils.SetEditorLang(this.txtCode, "." + this.cboCodeType.Text);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<#@ template language=\"C#\" HostSpecific=\"true\" #><#");
                sb.AppendLine("CodeBuilderHost host = (CodeBuilderHost)(Host);");
                sb.AppendLine("List<ColumnEntity> columns=host.Columns;");
                sb.AppendLine("TableEntity table=host.Table;");
                sb.AppendLine("ProjectEntity project=host.Project;");
                sb.AppendLine("string name=CodeHelper.RemovePrefix(table.TableName);");
                sb.AppendLine("string upperName=StringHelper.Capitalize(name);");
                sb.AppendLine("string lowerName=StringHelper.Capitalize(name,CaseType.Lower);");
                sb.AppendLine("IList<ColumnEntity> list = CodeHelper.FilterColumns(columns,false);");
                sb.AppendLine("//DataTypeManager.InitMappingConfig(null);#>/*");
                sb.AppendLine("Author:\t\t\t\t<#=host.User.RealName#>");
                sb.AppendLine("Content:\t\t\t\t");
                sb.AppendLine("CreateTime:\t\t\t<#=DateTime.Now.ToString(\"yyyy-MM-dd\")#>");
                sb.AppendLine("UpdateList:\t\t\t");
                sb.AppendLine("*/");
                this.txtCode.Text = sb.ToString();
                OldContent = this.txtCode.Text;
            }
        }
        //关闭之前看数据是否有保存
        private void TemplateEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OldContent != this.txtCode.Text)
            {
                IsChange = true;
            }
            if (IsChange)
            {
                DialogResult result = MsgBox.Question("模板内容发生改变，是否保存？");
                if (result == DialogResult.Yes)
                {
                    Save();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void txtTemplateName_TextChanged(object sender, EventArgs e)
        {
            IsChange = true;
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            IsChange = true;
        }


        private void BindTextBoxChange()
        {
            this.txtTemplateName.TextChanged += new System.EventHandler(this.txtTemplateName_TextChanged);
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
        }

        private void TemplateEdit_KeyDown(object sender, KeyEventArgs e)
        {
            //快捷键保存
            if (e.Control & e.KeyCode == Keys.S)
            {
                if (IsValid() && OldContent != this.txtCode.Text)
                {
                 //   SaveData();
                }
            }
        }



    }
}
