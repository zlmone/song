using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.TextEditor.Document;
using WSH.Common.Helper;
using WSH.Windows.Common;
using WSH.WinForm.Common;
using WSH.CodeBuilder.WinForm.Common;
using WSH.Options.Common;
using WSH.Tools.Connection.DB;
using WSH.CodeBuilder.DispatchServers;
using System.Windows.Forms;

namespace WSH.CodeBuilder.WinForm
{
    public class Utils
    {
        public static int TemplateRootID=-1;
        /// <summary>
        /// 检测链接
        /// </summary>
        public static bool CheckDbConnection() {
            if (!Global.IsConnection)
            {
                ConnectionEntity conn=Global.GetProjectConnection();
                DbConnectionOptions entity =new DbConnectionOptions ();
                WSH.CodeBuilder.DispatchServers.DataBaseType dbType = conn.ConnectionType;
                WSH.Common.DataBaseType databaseType= WSH.Common.DataBaseType.SqlServer;
                switch (dbType)
                {
                    case WSH.CodeBuilder.DispatchServers.DataBaseType.MySql:
                        databaseType = WSH.Common.DataBaseType.MySql;
                        entity = new DbConnectionOptions()
                        {
                            ConnectionString = conn.ConnectionString
                        };
                        break;
                    case WSH.CodeBuilder.DispatchServers.DataBaseType.Access:
                        databaseType = WSH.Common.DataBaseType.Access;
                        entity = new DbConnectionOptions()
                        {
                            ConnectionString = conn.ConnectionString
                        };
                        break;
                    case WSH.CodeBuilder.DispatchServers.DataBaseType.Oracle:
                        databaseType = WSH.Common.DataBaseType.Oracle;
                        entity = new DbConnectionOptions()
                        {
                            ConnectionString = conn.ConnectionString
                        };
                        break;
                    case WSH.CodeBuilder.DispatchServers.DataBaseType.SqlServer:
                        databaseType = WSH.Common.DataBaseType.SqlServer;
                        entity = new DbConnectionOptions()
                        {
                            ConnectionString = conn.ConnectionString
                        };
                        break;
                }
                Result result = DbConnectionManager.Connection(databaseType,entity);
                if (result.IsSuccess)
                {
                    Global.ConnectionString = result.Msg;
                    return true;
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// 设置代码编辑器的默认配置
        /// </summary>
        /// <param name="txtCode"></param>
        public static void SetTextEditor(ICSharpCode.TextEditor.TextEditorControl txtCode)
        {
            txtCode.ShowEOLMarkers = false;
            txtCode.ShowHRuler = false;
            txtCode.ShowInvalidLines = false;
            txtCode.ShowSpaces = false;
            txtCode.ShowTabs = false;
            txtCode.ShowVRuler = false;
            txtCode.AllowCaretBeyondEOL = false;
            txtCode.ShowMatchingBracket = true;
            txtCode.AutoScroll = true;
        }
        /// <summary>
        /// 设置代码编辑器的语言
        /// </summary>
        /// <param name="txtCode"></param>
        /// <param name="ext"></param>
        public static void SetEditorLang(ICSharpCode.TextEditor.TextEditorControl txtCode, string ext)
        {
            txtCode.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategyForFile("." + ext);
            txtCode.Encoding = System.Text.Encoding.Default;
        }
        /// <summary>
        /// 打开文件或者目录
        /// </summary>
        public static void FinishFile(string msg, DialogType type, string file)
        {
            if (MsgBox.Confirm(msg))
            {
                if (type == DialogType.Folder)
                {
                    FileHelper.OpenPath(file);
                }
                else
                {
                    FileHelper.OpenFile(file);
                }
            }
        }
        /// <summary>
        /// 显示错误信息窗口
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowErrorDialog(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                Information.Clear();
                Information.Add(msg);
                Information info = new Information();
                info.SetContent();
                info.ShowDialog();
            }
        }
        public static void SetFormNoresize(Form frm) {
            if (frm != null)
            {
                frm.MaximizeBox = false;
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }
    }
}
