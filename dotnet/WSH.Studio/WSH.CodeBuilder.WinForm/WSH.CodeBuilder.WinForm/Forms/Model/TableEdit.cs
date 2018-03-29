using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Controls;
using WSH.Common.Helper;
using WSH.WinForm.Common;
using WSH.Options.Common;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    public partial class TableEdit : BaseEditForm
    {
        CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
        Validation v = new Validation();
        public string TableName;
        public TableEdit()
        {
            InitializeComponent();
            v.Add(new ValidateItem(this.txtTableName));
            v.Add(new ValidateItem(this.txtAttr));
            this.cboDataKeyType.DataSource = Enum.GetNames(typeof(WSH.CodeBuilder.DispatchServers.DataKeyType));
            this.cboSortMode.DataSource = Enum.GetNames(typeof(WSH.CodeBuilder.DispatchServers.SortMode));

        }
        public override bool IsValid()
        {
            return v.IsValid();
        }
        public override void BindData()
        {
            DataTable columns1 = service.GetColumnDataTable(this.RecordID);
            DataTable columns2 = columns1.Copy();
            DataBind.BindCombox(this.cboDataKey, columns1, "Field");
            DataBind.BindCombox(this.cboSortName, columns2, "Field");
            TableEntity entity = service.GetTableById(this.RecordID);
            txtTableName.Text = entity.TableName;
            txtAttr.Text = entity.Attr;
            txtRemark.Text = entity.Remark;
            cboDataKey.Text = entity.DataKey;
            cboDataKeyType.Text = entity.DataKeyType.ToString();
            cboSortMode.Text = entity.DefaultSortMode.ToString();
            cboSortName.Text = entity.DefaultSortName;
        }
        public override bool SaveData()
        {
            TableEntity entity = new TableEntity();
            entity.ProjectID =Convert.ToInt32(Global.GetCurrentProjectID());
            entity.TableName = this.txtTableName.Text.Trim();
            entity.Attr = this.txtAttr.Text.Trim();
            entity.Remark = this.txtRemark.Text.Trim();
            entity.DataKey = this.cboDataKey.Text.Trim();
            entity.Enabled = true;
            entity.DataKeyType = StringHelper.ToEnum<WSH.CodeBuilder.DispatchServers.DataKeyType>(this.cboDataKeyType.Text);
            entity.DefaultSortMode = StringHelper.ToEnum<WSH.CodeBuilder.DispatchServers.SortMode>(this.cboSortMode.Text);
            entity.DefaultSortName = this.cboSortName.Text.Trim();
            TableName = entity.TableName;
            if (service.ExistsTableName(TableName, Global.GetCurrentProjectID(), this.RecordID))
            {
                throw new Exception("表名已经存在！");
            }
            if (string.IsNullOrEmpty(this.RecordID))
            {
                int id = service.AddTable(entity);
                if(id>0){
                    this.RecordID = id.ToString();
                    return true;
                }
                return false;
            }
            else {
                entity.ID =Convert.ToInt32( this.RecordID);
                return service.UpdateTable(entity);
            }
        }

         
    }
}
