using WSH.WinForm.Controls;
namespace WSH.CodeBuilder.WinForm
{
    partial class FilterData
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.页到 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelPageInfo = new System.Windows.Forms.Panel();
            this.txtPageEnd = new WSH.WinForm.Controls.NumberBox();
            this.txtPageBegin = new WSH.WinForm.Controls.NumberBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSql = new WSH.WinForm.Controls.TextArea();
            this.btnQuery = new WSH.WinForm.Controls.ButtonImage();
            this.grid = new System.Windows.Forms.DataGridView();
            this.checkBoxDataKey = new System.Windows.Forms.CheckBox();
            this.panelPageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSize
            // 
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "500",
            "1000",
            "5000",
            "10000"});
            this.cboSize.Location = new System.Drawing.Point(761, 4);
            this.cboSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(104, 23);
            this.cboSize.TabIndex = 1;
            this.cboSize.Text = "1000";
            this.cboSize.TextChanged += new System.EventHandler(this.cboSize_TextChanged);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(175, 42);
            this.lblPageInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(334, 15);
            this.lblPageInfo.TabIndex = 4;
            this.lblPageInfo.Text = "总记录：{TotalRecord}，总页数：{PageCount}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "从";
            // 
            // 页到
            // 
            this.页到.AutoSize = true;
            this.页到.Location = new System.Drawing.Point(120, 4);
            this.页到.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.页到.Name = "页到";
            this.页到.Size = new System.Drawing.Size(37, 15);
            this.页到.TabIndex = 8;
            this.页到.Text = "页到";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "页";
            // 
            // panelPageInfo
            // 
            this.panelPageInfo.Controls.Add(this.txtPageEnd);
            this.panelPageInfo.Controls.Add(this.txtPageBegin);
            this.panelPageInfo.Controls.Add(this.label4);
            this.panelPageInfo.Controls.Add(this.页到);
            this.panelPageInfo.Controls.Add(this.label3);
            this.panelPageInfo.Location = new System.Drawing.Point(577, 32);
            this.panelPageInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelPageInfo.Name = "panelPageInfo";
            this.panelPageInfo.Size = new System.Drawing.Size(291, 29);
            this.panelPageInfo.TabIndex = 10;
            // 
            // txtPageEnd
            // 
            this.txtPageEnd.AllowDecimal = true;
            this.txtPageEnd.AllowNegative = true;
            this.txtPageEnd.Location = new System.Drawing.Point(167, 0);
            this.txtPageEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPageEnd.MaxValue = ((long)(9223372036854775807));
            this.txtPageEnd.MinValue = ((long)(-9223372036854775808));
            this.txtPageEnd.Name = "txtPageEnd";
            this.txtPageEnd.RegexMessage = null;
            this.txtPageEnd.RegexType = WSH.Common.RegexType.None;
            this.txtPageEnd.Required = false;
            this.txtPageEnd.RequiredMessage = "此项必填";
            this.txtPageEnd.Size = new System.Drawing.Size(84, 25);
            this.txtPageEnd.TabIndex = 11;
            this.txtPageEnd.Text = "1";
            this.txtPageEnd.TextChanged += new System.EventHandler(this.txtPageEnd_TextChanged);
            // 
            // txtPageBegin
            // 
            this.txtPageBegin.AllowDecimal = true;
            this.txtPageBegin.AllowNegative = true;
            this.txtPageBegin.Location = new System.Drawing.Point(28, 1);
            this.txtPageBegin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPageBegin.MaxValue = ((long)(9223372036854775807));
            this.txtPageBegin.MinValue = ((long)(-9223372036854775808));
            this.txtPageBegin.Name = "txtPageBegin";
            this.txtPageBegin.RegexMessage = null;
            this.txtPageBegin.RegexType = WSH.Common.RegexType.None;
            this.txtPageBegin.Required = false;
            this.txtPageBegin.RequiredMessage = "此项必填";
            this.txtPageBegin.Size = new System.Drawing.Size(84, 25);
            this.txtPageBegin.TabIndex = 10;
            this.txtPageBegin.Text = "0";
            this.txtPageBegin.TextChanged += new System.EventHandler(this.txtPageBegin_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "表名：";
            // 
            // txtTableName
            // 
            this.txtTableName.Enabled = false;
            this.txtTableName.Location = new System.Drawing.Point(237, 4);
            this.txtTableName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(436, 25);
            this.txtTableName.TabIndex = 13;
            this.txtTableName.TextChanged += new System.EventHandler(this.txtTableName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(683, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "页大小：";
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(0, 61);
            this.txtSql.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSql.Size = new System.Drawing.Size(786, 102);
            this.txtSql.TabIndex = 16;
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.Transparent;
            this.btnQuery.Location = new System.Drawing.Point(795, 96);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(70, 30);
            this.btnQuery.TabIndex = 15;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(0, 166);
            this.grid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grid.Name = "grid";
            this.grid.RowTemplate.Height = 23;
            this.grid.Size = new System.Drawing.Size(868, 362);
            this.grid.TabIndex = 17;
            // 
            // checkBoxDataKey
            // 
            this.checkBoxDataKey.AutoSize = true;
            this.checkBoxDataKey.Checked = true;
            this.checkBoxDataKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDataKey.Location = new System.Drawing.Point(4, 38);
            this.checkBoxDataKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxDataKey.Name = "checkBoxDataKey";
            this.checkBoxDataKey.Size = new System.Drawing.Size(119, 19);
            this.checkBoxDataKey.TabIndex = 18;
            this.checkBoxDataKey.Text = "包含主键数据";
            this.checkBoxDataKey.UseVisualStyleBackColor = true;
            // 
            // FilterData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxDataKey);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelPageInfo);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.cboSize);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FilterData";
            this.Size = new System.Drawing.Size(869, 529);
            this.panelPageInfo.ResumeLayout(false);
            this.panelPageInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label 页到;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelPageInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label5;
        private ButtonImage btnQuery;
        private TextArea txtSql;
        private NumberBox txtPageEnd;
        private NumberBox txtPageBegin;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.CheckBox checkBoxDataKey;
    }
}
