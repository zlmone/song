namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    partial class ProjectEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAttr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTemplate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.selectConnection = new WSH.WinForm.Controls.SelectBox();
            this.required1 = new WSH.WinForm.Controls.Required();
            this.required2 = new WSH.WinForm.Controls.Required();
            this.required3 = new WSH.WinForm.Controls.Required();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目名称：";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(85, 8);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(220, 21);
            this.txtProjectName.TabIndex = 1;
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(85, 35);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(220, 21);
            this.txtNameSpace.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "命名空间：";
            // 
            // txtAttr
            // 
            this.txtAttr.Location = new System.Drawing.Point(85, 62);
            this.txtAttr.Name = "txtAttr";
            this.txtAttr.Size = new System.Drawing.Size(220, 21);
            this.txtAttr.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "描述：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(85, 89);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(220, 56);
            this.txtRemark.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "备注：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "模板：";
            // 
            // cboTemplate
            // 
            this.cboTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplate.FormattingEnabled = true;
            this.cboTemplate.Location = new System.Drawing.Point(86, 152);
            this.cboTemplate.Name = "cboTemplate";
            this.cboTemplate.Size = new System.Drawing.Size(219, 20);
            this.cboTemplate.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "连接：";
            // 
            // selectConnection
            // 
            this.selectConnection.AllowEdit = false;
            this.selectConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.selectConnection.Location = new System.Drawing.Point(86, 179);
            this.selectConnection.Name = "selectConnection";
            this.selectConnection.Size = new System.Drawing.Size(219, 21);
            this.selectConnection.TabIndex = 11;
            this.selectConnection.OnSelect += new System.EventHandler(this.selectConnection_OnSelect);
            // 
            // required1
            // 
            this.required1.AutoSize = true;
            this.required1.ForeColor = System.Drawing.Color.Red;
            this.required1.Location = new System.Drawing.Point(0, 12);
            this.required1.Name = "required1";
            this.required1.Size = new System.Drawing.Size(11, 12);
            this.required1.TabIndex = 12;
            this.required1.Text = "*";
            // 
            // required2
            // 
            this.required2.AutoSize = true;
            this.required2.ForeColor = System.Drawing.Color.Red;
            this.required2.Location = new System.Drawing.Point(0, 40);
            this.required2.Name = "required2";
            this.required2.Size = new System.Drawing.Size(11, 12);
            this.required2.TabIndex = 13;
            this.required2.Text = "*";
            // 
            // required3
            // 
            this.required3.AutoSize = true;
            this.required3.ForeColor = System.Drawing.Color.Red;
            this.required3.Location = new System.Drawing.Point(20, 65);
            this.required3.Name = "required3";
            this.required3.Size = new System.Drawing.Size(11, 12);
            this.required3.TabIndex = 14;
            this.required3.Text = "*";
            // 
            // ProjectEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 258);
            this.Controls.Add(this.required3);
            this.Controls.Add(this.required2);
            this.Controls.Add(this.required1);
            this.Controls.Add(this.selectConnection);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboTemplate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAttr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNameSpace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.label1);
            this.Name = "ProjectEdit";
            this.Text = "项目-编辑";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtProjectName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNameSpace, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtAttr, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtRemark, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cboTemplate, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.selectConnection, 0);
            this.Controls.SetChildIndex(this.required1, 0);
            this.Controls.SetChildIndex(this.required2, 0);
            this.Controls.SetChildIndex(this.required3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAttr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTemplate;
        private System.Windows.Forms.Label label6;
        private WSH.WinForm.Controls.SelectBox selectConnection;
        private WSH.WinForm.Controls.Required required1;
        private WSH.WinForm.Controls.Required required2;
        private WSH.WinForm.Controls.Required required3;
    }
}