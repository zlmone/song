using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;

namespace WSH.WebForm.Controls
{
    public static class ClientResourceUrl
    {
        public static string CssPath = ConfigurationManager.AppSettings["CssPath"];
        public static string JsPath = ConfigurationManager.AppSettings["JsPath"];

        public static string GlobalCss = Path.Combine(CssPath, "global.css");
        public static string FormCss = Path.Combine(CssPath,"form.css");
        public static string ExtendCss = Path.Combine(CssPath, "extend.css");
        public static string IconCss = Path.Combine(CssPath, "icons.css");
        public static string ButtonCss = Path.Combine(CssPath, "buttons.css");
        public static string MenuCss = Path.Combine(CssPath, "song.menu.css");
        public static string ToolbarCss = Path.Combine(CssPath, "song.toolbar.css");


        public static string LayoutJs = Path.Combine(JsPath, "common/layout.js");
        public static string DatePickerJs = Path.Combine(JsPath, "datePicker/WdatePicker.js");
        public static string LHGDialogCss = Path.Combine(JsPath, "lhgDialog/default.css");
        public static string LHGDialogJs = Path.Combine(JsPath, "lhgDialog/lhgdialog.min.js");
        public static string MenuJs = Path.Combine(JsPath, "song/song.menu.js");
        public static string ToolbarJs = Path.Combine(JsPath, "song/song.toolbar.js");
    }
}
