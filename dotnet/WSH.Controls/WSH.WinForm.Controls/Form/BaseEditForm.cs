using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Common;

namespace WSH.WinForm.Controls
{
    public partial class BaseEditForm : BaseForm
    {
        public BaseEditForm()
        {
            InitializeComponent();
        }
        private string id;

        public string RecordID
        {
            get { return id; }
            set { id = value; }
        }
        private EditMode editMode = EditMode.Add;
        /// <summary>
        /// 编辑页面的模式
        /// </summary>
        public EditMode EditMode
        {
            get { return editMode; }
            set { editMode = value; }
        }
        private int saveCount = 0;
        /// <summary>
        /// 保存成功的次数
        /// </summary>
        public int SaveCount
        {
            get { return saveCount; }
            set { saveCount = value; }
        }
        private bool isClose;
        /// <summary>
        /// 保存之后是否关闭窗体
        /// </summary>
        public bool IsClose
        {
            get { return isClose; }
            set { isClose = value; }
        }
        private bool isClear = false;
        /// <summary>
        /// 保存之后是否清空页面的值
        /// </summary>
        public bool IsClear
        {
            get { return isClear; }
            set { isClear = value; }
        }

        public virtual void BindData()
        {

        }
        public virtual bool SaveData()
        {
            return true;
        }
        public virtual bool IsValid() {
            return true;
        }
        protected void Save()
        {
            if(!this.IsValid()){
                this.isClose = false;
                return;
            }
            string msg = "保存成功";
            bool result = true;
            try
            {
                result = this.SaveData();
                if (!result)
                {
                    this.isClose = false;
                    msg = "保存失败";
                }
                else
                {
                    SaveCount++;
                }
            }
            catch (Exception ex)
            {
                result = false;
                msg = "保存失败，错误信息：" + ex.Message;
                this.isClose = false;
            }
            if(!result){
                MsgBox.Alert(msg);
            }
            if (this.isClear && result)
            {
                this.ClearForm();
            }
            if (this.isClose)
            {
                this.Close();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.isClose = true;
            this.Save();
        }

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            this.isClose = false;
            this.isClear = true;
            this.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 清除form里的控件值
        /// </summary>
        public void ClearForm()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBoxBase)
                {
                    item.Text = string.Empty;
                }
            }
        }
        /// <summary>
        /// 设置form里的控件为只读
        /// </summary>
        public void EnableForm()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBoxBase || item is CheckBox || item is RadioButton || item is ListControl)
                {
                    item.Enabled = false;
                }
            }
        }
        public void HideButtons() {
            this.panelButtons.Visible = false;
        }

        private void BaseEditForm_Load(object sender, EventArgs e)
        {
            if (this.editMode == WinForm.Controls.EditMode.Edit || this.editMode == WinForm.Controls.EditMode.View)
            {
                this.btnSaveAdd.Visible = false;
                if (this.editMode == WinForm.Controls.EditMode.View)
                {
                    this.btnSave.Visible = false;
                    this.EnableForm();
                }
            }
            if(!string.IsNullOrEmpty(id)){
                BindData();
            }
        }
    }
    public enum EditMode
    {
        Edit, Add, View
    }
}
