using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Controls;
using WSH.WinForm.Common;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    public partial class ProjectEdit : BaseEditForm
    {
        CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
        Validation v = new Validation();
        public string ProjectName;
        public ProjectEdit()
        {
            InitializeComponent();
            v.Add(new ValidateItem(this.txtProjectName));
            v.Add(new ValidateItem(this.txtNameSpace));
            v.Add(new ValidateItem(this.txtAttr));
            DataBind.BindCombox(this.cboTemplate, service.GetTemplateDataTable(Utils.TemplateRootID.ToString()), "TemplateName", "ID");
        }
        public override void BindData()
        {
            ProjectEntity entity = service.GetProjectById(this.RecordID);
            this.txtProjectName.Text = entity.ProjectName;
            this.txtNameSpace.Text = entity.NameSpace;
            this.txtAttr.Text = entity.Attr;
            this.txtRemark.Text = entity.Remark;
            if (entity.TemplateID > -1)
            {
                this.cboTemplate.SelectedValue = entity.TemplateID;
            }
            if (entity.ConnectionID > -1)
            {
                ConnectionEntity conn = service.GetConnectionById(entity.ConnectionID.ToString());
                this.selectConnection.Text = conn.ConnectionName;
                this.selectConnection.Value = conn.ID.ToString();
            }
        }
        public override bool IsValid()
        {
            return v.IsValid();
        }

        public override bool SaveData()
        {

            ProjectEntity entity = new ProjectEntity();
            entity.ID = Convert.ToInt32(this.RecordID);
            entity.ProjectName = this.txtProjectName.Text.Trim();
            ProjectName = entity.ProjectName;
            entity.NameSpace = this.txtNameSpace.Text.Trim();
            entity.Attr = this.txtAttr.Text.Trim();
            entity.Remark = this.txtRemark.Text.Trim();
            entity.TemplateID = Convert.ToInt32(this.cboTemplate.SelectedValue);
            entity.ConnectionID =Convert.ToInt32(this.selectConnection.Value);

            if (string.IsNullOrEmpty(this.RecordID))
            {
                int id = service.AddProject(entity);
                if (id > 0)
                {
                    this.RecordID = id.ToString();
                }
                return id > 0;
            }
            else
            {
                return service.UpdateProject(entity);
            }
        }

        private void selectConnection_OnSelect(object sender, EventArgs e)
        {
            ConnectionEdit conn = new ConnectionEdit()
            {
                RecordID = this.selectConnection.Value,
                IsSelect=true,
                EditMode = WSH.WinForm.Controls.EditMode.Edit
            };
            conn.ShowDialog();
            if(conn.SaveCount>0){
                this.selectConnection.Text = conn.ConnectionName;
                this.selectConnection.Value = conn.RecordID;
            }
        }
    }
}
