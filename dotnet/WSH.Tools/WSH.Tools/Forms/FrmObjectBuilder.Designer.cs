namespace WSH.Tools
{
    partial class FrmObjectBuilder
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkNote = new System.Windows.Forms.CheckBox();
            this.btnEntity = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboEntityType = new System.Windows.Forms.ComboBox();
            this.txtEntity = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataLine = new System.Windows.Forms.MaskedTextBox();
            this.checkData = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDataTable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataTableLine = new System.Windows.Forms.TextBox();
            this.checkIsExtend = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnStringBuilder = new System.Windows.Forms.Button();
            this.cboBuilderMethod = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBuilderName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboBuilderType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStringBuilder = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnLower = new System.Windows.Forms.Button();
            this.btnCapUpper = new System.Windows.Forms.Button();
            this.btnCapLower = new System.Windows.Forms.Button();
            this.btnUpper = new System.Windows.Forms.Button();
            this.txtCap = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.RichTextBox();
            this.menuCode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCode = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCode = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.menuCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Controls.Add(this.tabPage3);
            this.tab.Controls.Add(this.tabPage4);
            this.tab.Dock = System.Windows.Forms.DockStyle.Top;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Margin = new System.Windows.Forms.Padding(0);
            this.tab.Name = "tab";
            this.tab.Padding = new System.Drawing.Point(0, 0);
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(551, 277);
            this.tab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.checkNote);
            this.tabPage1.Controls.Add(this.btnEntity);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cboEntityType);
            this.tabPage1.Controls.Add(this.txtEntity);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(543, 251);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "简易实体生成器";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkNote
            // 
            this.checkNote.AutoSize = true;
            this.checkNote.Checked = true;
            this.checkNote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNote.Location = new System.Drawing.Point(331, 104);
            this.checkNote.Name = "checkNote";
            this.checkNote.Size = new System.Drawing.Size(96, 16);
            this.checkNote.TabIndex = 4;
            this.checkNote.Text = "是否生成注释";
            this.checkNote.UseVisualStyleBackColor = true;
            // 
            // btnEntity
            // 
            this.btnEntity.Location = new System.Drawing.Point(330, 139);
            this.btnEntity.Name = "btnEntity";
            this.btnEntity.Size = new System.Drawing.Size(75, 23);
            this.btnEntity.TabIndex = 3;
            this.btnEntity.Text = "生成↓";
            this.btnEntity.UseVisualStyleBackColor = true;
            this.btnEntity.Click += new System.EventHandler(this.btnEntity_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "类型";
            // 
            // cboEntityType
            // 
            this.cboEntityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntityType.FormattingEnabled = true;
            this.cboEntityType.Items.AddRange(new object[] {
            "framework2",
            "framework3+"});
            this.cboEntityType.Location = new System.Drawing.Point(363, 67);
            this.cboEntityType.Name = "cboEntityType";
            this.cboEntityType.Size = new System.Drawing.Size(121, 20);
            this.cboEntityType.TabIndex = 1;
            // 
            // txtEntity
            // 
            this.txtEntity.Location = new System.Drawing.Point(1, 3);
            this.txtEntity.Multiline = true;
            this.txtEntity.Name = "txtEntity";
            this.txtEntity.Size = new System.Drawing.Size(323, 246);
            this.txtEntity.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtDataLine);
            this.tabPage2.Controls.Add(this.checkData);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnDataTable);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtDataTableLine);
            this.tabPage2.Controls.Add(this.checkIsExtend);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(543, 251);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "自定义DataTable生成器";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "测试数据行数";
            // 
            // txtDataLine
            // 
            this.txtDataLine.Location = new System.Drawing.Point(420, 153);
            this.txtDataLine.Mask = "99999";
            this.txtDataLine.Name = "txtDataLine";
            this.txtDataLine.Size = new System.Drawing.Size(69, 21);
            this.txtDataLine.TabIndex = 6;
            this.txtDataLine.Text = "10";
            this.txtDataLine.ValidatingType = typeof(int);
            // 
            // checkData
            // 
            this.checkData.AutoSize = true;
            this.checkData.Checked = true;
            this.checkData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkData.ForeColor = System.Drawing.Color.Black;
            this.checkData.Location = new System.Drawing.Point(339, 127);
            this.checkData.Name = "checkData";
            this.checkData.Size = new System.Drawing.Size(120, 16);
            this.checkData.TabIndex = 5;
            this.checkData.Text = "是否生成测试数据";
            this.checkData.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "注：每个字段请分行";
            // 
            // btnDataTable
            // 
            this.btnDataTable.ForeColor = System.Drawing.Color.Black;
            this.btnDataTable.Location = new System.Drawing.Point(337, 185);
            this.btnDataTable.Name = "btnDataTable";
            this.btnDataTable.Size = new System.Drawing.Size(75, 23);
            this.btnDataTable.TabIndex = 3;
            this.btnDataTable.Text = "生成↓";
            this.btnDataTable.UseVisualStyleBackColor = true;
            this.btnDataTable.Click += new System.EventHandler(this.btnDataTable_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(335, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "请输入：[数据类型] [列名]";
            // 
            // txtDataTableLine
            // 
            this.txtDataTableLine.Location = new System.Drawing.Point(1, 3);
            this.txtDataTableLine.Multiline = true;
            this.txtDataTableLine.Name = "txtDataTableLine";
            this.txtDataTableLine.Size = new System.Drawing.Size(323, 246);
            this.txtDataTableLine.TabIndex = 1;
            // 
            // checkIsExtend
            // 
            this.checkIsExtend.AutoSize = true;
            this.checkIsExtend.ForeColor = System.Drawing.Color.Black;
            this.checkIsExtend.Location = new System.Drawing.Point(339, 95);
            this.checkIsExtend.Name = "checkIsExtend";
            this.checkIsExtend.Size = new System.Drawing.Size(126, 16);
            this.checkIsExtend.TabIndex = 0;
            this.checkIsExtend.Text = "是否继承DataTable";
            this.checkIsExtend.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnStringBuilder);
            this.tabPage3.Controls.Add(this.cboBuilderMethod);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.txtBuilderName);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.cboBuilderType);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.txtStringBuilder);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(543, 251);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "字符串拼接";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnStringBuilder
            // 
            this.btnStringBuilder.Location = new System.Drawing.Point(407, 168);
            this.btnStringBuilder.Name = "btnStringBuilder";
            this.btnStringBuilder.Size = new System.Drawing.Size(75, 23);
            this.btnStringBuilder.TabIndex = 9;
            this.btnStringBuilder.Text = "生成↓";
            this.btnStringBuilder.UseVisualStyleBackColor = true;
            this.btnStringBuilder.Click += new System.EventHandler(this.btnStringBuilder_Click);
            // 
            // cboBuilderMethod
            // 
            this.cboBuilderMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuilderMethod.FormattingEnabled = true;
            this.cboBuilderMethod.Items.AddRange(new object[] {
            "AppendLine",
            "Append"});
            this.cboBuilderMethod.Location = new System.Drawing.Point(407, 124);
            this.cboBuilderMethod.Name = "cboBuilderMethod";
            this.cboBuilderMethod.Size = new System.Drawing.Size(121, 20);
            this.cboBuilderMethod.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "拼接方法：";
            // 
            // txtBuilderName
            // 
            this.txtBuilderName.Location = new System.Drawing.Point(407, 90);
            this.txtBuilderName.Name = "txtBuilderName";
            this.txtBuilderName.Size = new System.Drawing.Size(121, 21);
            this.txtBuilderName.TabIndex = 6;
            this.txtBuilderName.Text = "sb";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "对 象 名：";
            // 
            // cboBuilderType
            // 
            this.cboBuilderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuilderType.FormattingEnabled = true;
            this.cboBuilderType.Items.AddRange(new object[] {
            "Net-StringBuilder",
            "Java-StringBuffer",
            "Js-song.builder",
            "Js-Array"});
            this.cboBuilderType.Location = new System.Drawing.Point(407, 56);
            this.cboBuilderType.Name = "cboBuilderType";
            this.cboBuilderType.Size = new System.Drawing.Size(121, 20);
            this.cboBuilderType.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "拼接类型：";
            // 
            // txtStringBuilder
            // 
            this.txtStringBuilder.Location = new System.Drawing.Point(3, 3);
            this.txtStringBuilder.Multiline = true;
            this.txtStringBuilder.Name = "txtStringBuilder";
            this.txtStringBuilder.Size = new System.Drawing.Size(323, 246);
            this.txtStringBuilder.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnLower);
            this.tabPage4.Controls.Add(this.btnCapUpper);
            this.tabPage4.Controls.Add(this.btnCapLower);
            this.tabPage4.Controls.Add(this.btnUpper);
            this.tabPage4.Controls.Add(this.txtCap);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(543, 251);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "大小写转换";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnLower
            // 
            this.btnLower.Location = new System.Drawing.Point(450, 80);
            this.btnLower.Name = "btnLower";
            this.btnLower.Size = new System.Drawing.Size(75, 23);
            this.btnLower.TabIndex = 7;
            this.btnLower.Text = "全部小写";
            this.btnLower.UseVisualStyleBackColor = true;
            this.btnLower.Click += new System.EventHandler(this.btnLower_Click);
            // 
            // btnCapUpper
            // 
            this.btnCapUpper.Location = new System.Drawing.Point(348, 119);
            this.btnCapUpper.Name = "btnCapUpper";
            this.btnCapUpper.Size = new System.Drawing.Size(75, 23);
            this.btnCapUpper.TabIndex = 6;
            this.btnCapUpper.Text = "首字母大写";
            this.btnCapUpper.UseVisualStyleBackColor = true;
            this.btnCapUpper.Click += new System.EventHandler(this.btnCapUpper_Click);
            // 
            // btnCapLower
            // 
            this.btnCapLower.Location = new System.Drawing.Point(450, 119);
            this.btnCapLower.Name = "btnCapLower";
            this.btnCapLower.Size = new System.Drawing.Size(75, 23);
            this.btnCapLower.TabIndex = 5;
            this.btnCapLower.Text = "首字母小写";
            this.btnCapLower.UseVisualStyleBackColor = true;
            this.btnCapLower.Click += new System.EventHandler(this.btnCapLower_Click);
            // 
            // btnUpper
            // 
            this.btnUpper.Location = new System.Drawing.Point(348, 80);
            this.btnUpper.Name = "btnUpper";
            this.btnUpper.Size = new System.Drawing.Size(75, 23);
            this.btnUpper.TabIndex = 4;
            this.btnUpper.Text = "全部大写";
            this.btnUpper.UseVisualStyleBackColor = true;
            this.btnUpper.Click += new System.EventHandler(this.btnUpper_Click);
            // 
            // txtCap
            // 
            this.txtCap.Location = new System.Drawing.Point(3, 3);
            this.txtCap.Multiline = true;
            this.txtCap.Name = "txtCap";
            this.txtCap.Size = new System.Drawing.Size(323, 246);
            this.txtCap.TabIndex = 3;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.ContextMenuStrip = this.menuCode;
            this.txtCode.Location = new System.Drawing.Point(0, 276);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(551, 321);
            this.txtCode.TabIndex = 1;
            this.txtCode.Text = "";
            // 
            // menuCode
            // 
            this.menuCode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCode,
            this.exportCode});
            this.menuCode.Name = "menuCode";
            this.menuCode.Size = new System.Drawing.Size(125, 48);
            // 
            // copyCode
            // 
            this.copyCode.Name = "copyCode";
            this.copyCode.Size = new System.Drawing.Size(124, 22);
            this.copyCode.Text = "复制代码";
            this.copyCode.Click += new System.EventHandler(this.copyCode_Click);
            // 
            // exportCode
            // 
            this.exportCode.Name = "exportCode";
            this.exportCode.Size = new System.Drawing.Size(124, 22);
            this.exportCode.Text = "导出文件";
            this.exportCode.Click += new System.EventHandler(this.exportCode_Click);
            // 
            // saveFile
            // 
            this.saveFile.FileName = "ObjectBuilder.cs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(330, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "请输入：[数据类型] [列名]";
            // 
            // FrmObjectBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 597);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.tab);
            this.Name = "FrmObjectBuilder";
            this.Text = "对象生成器";
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.menuCode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox checkIsExtend;
        private System.Windows.Forms.RichTextBox txtCode;
        private System.Windows.Forms.ContextMenuStrip menuCode;
        private System.Windows.Forms.ToolStripMenuItem copyCode;
        private System.Windows.Forms.ToolStripMenuItem exportCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDataTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataTableLine;
        private System.Windows.Forms.CheckBox checkData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtDataLine;
        private System.Windows.Forms.Button btnEntity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboEntityType;
        private System.Windows.Forms.TextBox txtEntity;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnStringBuilder;
        private System.Windows.Forms.ComboBox cboBuilderMethod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBuilderName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBuilderType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStringBuilder;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.CheckBox checkNote;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnLower;
        private System.Windows.Forms.Button btnCapUpper;
        private System.Windows.Forms.Button btnCapLower;
        private System.Windows.Forms.Button btnUpper;
        private System.Windows.Forms.TextBox txtCap;
        private System.Windows.Forms.Label label8;
    }
}

