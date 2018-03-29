namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    partial class TableEdit
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
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDataKeyType = new System.Windows.Forms.ComboBox();
            this.txtAttr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDataKey = new System.Windows.Forms.ComboBox();
            this.cboSortName = new System.Windows.Forms.ComboBox();
            this.cboSortMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.required1 = new WSH.WinForm.Controls.Required();
            this.required2 = new WSH.WinForm.Controls.Required();
            this.SuspendLayout();
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(91, 176);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(220, 56);
            this.txtRemark.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "备注：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "主键名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "主键类型：";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(91, 12);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(220, 21);
            this.txtTableName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "表名：";
            // 
            // cboDataKeyType
            // 
            this.cboDataKeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataKeyType.FormattingEnabled = true;
            this.cboDataKeyType.Location = new System.Drawing.Point(91, 39);
            this.cboDataKeyType.Name = "cboDataKeyType";
            this.cboDataKeyType.Size = new System.Drawing.Size(220, 20);
            this.cboDataKeyType.TabIndex = 16;
            // 
            // txtAttr
            // 
            this.txtAttr.Location = new System.Drawing.Point(91, 149);
            this.txtAttr.Name = "txtAttr";
            this.txtAttr.Size = new System.Drawing.Size(220, 21);
            this.txtAttr.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "描述：";
            // 
            // cboDataKey
            // 
            this.cboDataKey.FormattingEnabled = true;
            this.cboDataKey.Location = new System.Drawing.Point(91, 66);
            this.cboDataKey.Name = "cboDataKey";
            this.cboDataKey.Size = new System.Drawing.Size(220, 20);
            this.cboDataKey.TabIndex = 19;
            // 
            // cboSortName
            // 
            this.cboSortName.FormattingEnabled = true;
            this.cboSortName.Location = new System.Drawing.Point(91, 121);
            this.cboSortName.Name = "cboSortName";
            this.cboSortName.Size = new System.Drawing.Size(220, 20);
            this.cboSortName.TabIndex = 23;
            // 
            // cboSortMode
            // 
            this.cboSortMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSortMode.FormattingEnabled = true;
            this.cboSortMode.Location = new System.Drawing.Point(91, 94);
            this.cboSortMode.Name = "cboSortMode";
            this.cboSortMode.Size = new System.Drawing.Size(220, 20);
            this.cboSortMode.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "排序名：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "排序类型：";
            // 
            // required1
            // 
            this.required1.AutoSize = true;
            this.required1.ForeColor = System.Drawing.Color.Red;
            this.required1.Location = new System.Drawing.Point(31, 15);
            this.required1.Name = "required1";
            this.required1.Size = new System.Drawing.Size(11, 12);
            this.required1.TabIndex = 24;
            this.required1.Text = "*";
            // 
            // required2
            // 
            this.required2.AutoSize = true;
            this.required2.ForeColor = System.Drawing.Color.Red;
            this.required2.Location = new System.Drawing.Point(31, 152);
            this.required2.Name = "required2";
            this.required2.Size = new System.Drawing.Size(11, 12);
            this.required2.TabIndex = 25;
            this.required2.Text = "*";
            // 
            // TableEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 293);
            this.Controls.Add(this.required2);
            this.Controls.Add(this.required1);
            this.Controls.Add(this.cboSortName);
            this.Controls.Add(this.cboSortMode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboDataKey);
            this.Controls.Add(this.txtAttr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboDataKeyType);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.label1);
            this.Name = "TableEdit";
            this.Text = "表-编辑";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTableName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtRemark, 0);
            this.Controls.SetChildIndex(this.cboDataKeyType, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtAttr, 0);
            this.Controls.SetChildIndex(this.cboDataKey, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cboSortMode, 0);
            this.Controls.SetChildIndex(this.cboSortName, 0);
            this.Controls.SetChildIndex(this.required1, 0);
            this.Controls.SetChildIndex(this.required2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDataKeyType;
        private System.Windows.Forms.TextBox txtAttr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDataKey;
        private System.Windows.Forms.ComboBox cboSortName;
        private System.Windows.Forms.ComboBox cboSortMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private WSH.WinForm.Controls.Required required1;
        private WSH.WinForm.Controls.Required required2;
    }
}