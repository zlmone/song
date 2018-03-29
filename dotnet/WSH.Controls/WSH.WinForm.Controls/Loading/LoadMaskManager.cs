using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WSH.WinForm.Controls
{
    public class LoadMaskManager
    {
       
        private LoadMask loading = null;//半透明蒙板层

        /// <summary>
        /// 显示遮罩层
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="alpha">透明度</param>
        /// <param name="isShowLoadingImage">是否显示图标</param>
        public void Show(Control control, int alpha)
        {
            try
            {
                if (this.loading == null)
                {
                    this.loading = new LoadMask(alpha,true);
                    control.Controls.Add(this.loading);
                    this.loading.Dock = DockStyle.Fill;
                    this.loading.BringToFront();
                }
                this.loading.Enabled = true;
                this.loading.Visible = true;
            }
            catch { }
        }
        public void Show(Control control) {
            Show(control,125);
            Application.DoEvents();
        }
        public void Close() { 
            if(this.loading!=null){
                loading.Dispose();
                this.loading = null;
            }
        }
        /// <summary>
        /// 隐藏遮罩层
        /// </summary>
        public void Hide()
        {
            try
            {
                if (this.loading != null)
                {
                    this.loading.Visible = false;
                    this.loading.Enabled = false;
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
