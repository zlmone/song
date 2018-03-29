using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WSH.Common;
using WSH.Common.Helper;

namespace WSH.Tools.UserControls
{
    [DefaultEvent("OnGetData")]
    public partial class DataMiningItem : UserControl
    {
        public event EventHandler OnGetData;
        public DataMiningItem()
        {
            InitializeComponent();
        }
        public string GroupText {
            set { this.groupBox1.Text = value; }
            get { return this.groupBox1.Text; }
        }
        public int MaxProgress {
            set { this.pb.Maximum = value; }
        }
        public void SetProgress() { 
            if(this.pb.Value>=this.pb.Maximum ){
                this.pb.Value = 0;
            }
            this.pb.Value++;
            Application.DoEvents();
        }
        public void SetMsg(string text) {
            Error = text;
        }
        public string[] GetMsgs() {
            return this.txtMsg.Lines;
        }
        public string GetMsg() {
            return this.txtMsg.Text;
        }
        public void AddMsg(string text) {
            Error += text;
        }
        public string Url {
            get {
                return this.textBox1.Text.Trim();
            }
            set {
                this.textBox1.Text = value;
            }
        }
        #region 耗时处理
        int duration = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            duration++;
            lblTime.Text = "耗时：" + GetTimeBySecount(duration);
            Application.DoEvents();
        }
        /// <summary>
        /// 通过秒返回时：分：秒格式的时间
        /// </summary>
        /// <returns></returns>
        private string GetTimeBySecount(int s)
        {
            s = s + 1;
            TimeSpan timeSpan = new TimeSpan(0, 0, s);
            string hour = timeSpan.Hours < 10 ? timeSpan.Hours.ToString().Trim().PadLeft(2, '0') : timeSpan.Hours.ToString().Trim();
            string minute = timeSpan.Minutes < 10 ? timeSpan.Minutes.ToString().Trim().PadLeft(2, '0') : timeSpan.Minutes.ToString().Trim();
            string second = timeSpan.Seconds < 10 ? timeSpan.Seconds.ToString().Trim().PadLeft(2, '0') : timeSpan.Seconds.ToString().Trim();
            return string.Format("{0}:{1}:{2}", hour, minute, second);
        }
        #endregion

        private void btnGetData_Click(object sender, EventArgs e)
        {
            duration = 0;
            this.timer.Start();
            this.timer.Enabled = true;
            this.backgroundWorker1.RunWorkerAsync();
        }
        private string Error;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (OnGetData != null)
            {
                try
                {
                    OnGetData(sender, e);
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("[" + FormatHelper.DateTime + "]获取数据出错，错误信息：");
                    sb.AppendLine(ex.Message);
                    Error = sb.ToString();                    
                }
            }
           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.timer.Stop();
            this.timer.Enabled = false;
            txtMsg.Text = Error;
        }
    }
}
