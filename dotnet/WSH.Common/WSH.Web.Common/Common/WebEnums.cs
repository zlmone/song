using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Web.Common
{
    public enum AjaxDataType
    {
        Json, Xml, Script, Text, Html
    }
    public enum AjaxType
    {
        GET, POST
    }
    /// <summary>
    /// Html表单输入框类型
    /// </summary>
    public enum InputType
    {
        Text,
        Password,
        Radio,
        CheckBox,
        Button,
        Image,
        File,
        Reset,
        Submit,
        Hidden
    }
}
