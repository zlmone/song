using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WSH.CodeBuilder.WinForm.Forms.Model;
using WSH.CodeBuilder.WinForm.Forms;
using WSH.Tools.AutoUpdater;
using System.Net;
using System.Xml;
using WSH.WinForm.Common;
using WSH.CodeBuilder.Common;
using WSH.WinForm.Controls;
using WSH.Common.Configuration;

namespace WSH.CodeBuilder.WinForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigurationState state = new ConfigurationState();
            var isAutoUpdate=state.Get<bool>(StateKeys.IsAutoUpdate);
            if (isAutoUpdate)
            {
                AutoUpdate();
            }
            Logon logon = new Logon();
            if (logon.ShowDialog()== DialogResult.OK) {
                //初始化数据类型
                DataTypeManager.InitMappingConfig();
                //运行主页面
                Application.Run(new Main());            
            }
        }

        #region 自动更新程序
        private static  void AutoUpdate() {
            bool bHasError = false;
            IAutoUpdater autoUpdater = new AutoUpdater();
            string title = "检查更新出错，";
            try
            {
                autoUpdater.Update();
            }
            catch (WebException exp)
            {
                MsgBox.Alert(title+"找不到指定的资源");
                bHasError = true;
            }
            catch (XmlException exp)
            {
                bHasError = true;
                MsgBox.Alert(title + "下载升级文件错误");
            }
            catch (NotSupportedException exp)
            {
                bHasError = true;
                MsgBox.Alert(title + "升级的地址配置错误");
            }
            catch (ArgumentException exp)
            {
                bHasError = true;
                MsgBox.Alert(title + "下载升级文件错误");
            }
            catch (Exception exp)
            {
                bHasError = true;
                MsgBox.Alert(title);
            }
            finally
            {
                if (bHasError == true)
                {
                    try
                    {
                        autoUpdater.RollBack();
                    }
                    catch (Exception)
                    {
                        //Log the message to your file or database
                    }
                }
            }
        }
        #endregion
    }
}
