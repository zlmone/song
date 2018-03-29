namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    partial class ReaderPdm
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
            this.selectDialog1 = new WSH.WinForm.Controls.SelectDialog();
            this.tables1 = new WSH.CodeBuilder.WinForm.UserControls.Tables();
            this.btnReader = new WSH.WinForm.Controls.ButtonImage();
            this.btnLoad = new WSH.WinForm.Controls.ButtonImage();
            this.SuspendLayout();
            // 
            // selectDialog1
            // 
            this.selectDialog1.BackColor = System.Drawing.Color.Transparent;
            this.selectDialog1.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
            this.selectDialog1.Location = new System.Drawing.Point(3, 3);
            this.selectDialog1.MaximumSize = new System.Drawing.Size(3000, 30);
            this.selectDialog1.MinimumSize = new System.Drawing.Size(100, 30);
            this.selectDialog1.Name = "selectDialog1";
            this.selectDialog1.ReadOnly = false;
            this.selectDialog1.Size = new System.Drawing.Size(400, 30);
            this.selectDialog1.TabIndex = 0;
            this.selectDialog1.Title = null;
            this.selectDialog1.Type = WSH.Windows.Common.DialogType.File;
            this.selectDialog1.OnSelectDialogOk += new WSH.WinForm.Controls.SelectDialog.SelectDialogOkHandler(this.selectDialog1_OnSelectDialogOk);
            // 
            // tables1
            // 
            this.tables1.Location = new System.Drawing.Point(4, 36);
            this.tables1.Name = "tables1";
            this.tables1.Size = new System.Drawing.Size(476, 374);
            this.tables1.TabIndex = 1;
            // 
            // btnReader
            // 
            this.btnReader.BackColor = System.Drawing.Color.Transparent;
            this.btnReader.Location = new System.Drawing.Point(211, 415);
            this.btnReader.Name = "btnReader";
            this.btnReader.Size = new System.Drawing.Size(70, 30);
            this.btnReader.TabIndex = 2;
            this.btnReader.Text = "读取";
            this.btnReader.Click += new System.EventHandler(this.btnReader_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.Transparent;
            this.btnLoad.Location = new System.Drawing.Point(409, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(70, 30);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "加载";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ReaderPdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 448);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnReader);
            this.Controls.Add(this.tables1);
            this.Controls.Add(this.selectDialog1);
            this.Name = "ReaderPdm";
            this.Text = "读取Pdm文件";
            this.Load += new System.EventHandler(this.ReaderPdm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WSH.WinForm.Controls.SelectDialog selectDialog1;
        private UserControls.Tables tables1;
        private WSH.WinForm.Controls.ButtonImage btnReader;
        private WSH.WinForm.Controls.ButtonImage btnLoad;
    }
}