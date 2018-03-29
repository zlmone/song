using System;
using System.Collections.Generic;

using System.Text;
using System.ComponentModel;

namespace WSH.Common
{
    #region 图标枚举
    public enum Icons
    {
        None,
        Add,
        Edit,
        Delete,
        Remove,
        Update,
        DeleteRow,
        AddRow,
        Back,
        Cancel,
        Close,
        Config,
        Goto,
        Folder,
        Error,
        Copy,
        Query,
        Search,
        Word,
        Excel,
        Print,
        Preview,
        Save,
        SaveAdd,
        Reload,
        Pdf,
        Success,
        Grid,
        Info,
        First,
        FirstDisabled,
        Prev,
        PrevDisabled,
        Next,
        NextDisabled,
        Last,
        LastDisabled
    }
    #endregion

    #region 数据库相关枚举
    /// <summary>
    /// 数据连接类型
    /// </summary>
    public enum DataBaseType
    {
        SqlServer,
        Oracle,
        MySql,
        Access,
        SQLite,
        Other
    }
    public enum AlignType
    {
        Left,
        Center,
        Right
    }
    /// <summary>
    /// 主键类型
    /// </summary>
    public enum DataKeyType
    {
        IdEntity,
        Guid,
        Custom
    }
    public enum SortMode
    {
        Asc,
        Desc
    }
    #endregion

    #region 文件类型枚举
    public enum FileType
    {
        [Description("Excel文件")]
        Excel,
        [Description("Word文件")]
        Word,
        [Description("PPT文件")]
        PPT,
        [Description("图片")]
        Image,
        [Description("文本文件")]
        Txt,
        [Description("网页静态文件")]
        Html,
        [Description("Flash文件")]
        Flash,
        [Description("配置文件")]
        Config,
        [Description("NET代码")]
        DotNet,
        [Description("JAVA代码")]
        Java,
        [Description("压缩包")]
        Package,
        [Description("数据库文件")]
        DB,
        [Description("程序集")]
        Assembly,
        [Description("可执行文件")]
        Execute,
        /// <summary>
        /// 种子文件
        /// </summary>
        [Description("种子文件")]
        BT,
        /// <summary>
        /// 视频
        /// </summary>
        [Description("视频")]
        Video,
        /// <summary>
        /// 音频
        /// </summary>
        [Description("音频")]
        Voice,
        [Description("其他")]
        Other
    }
    #endregion

    #region 编辑器枚举
    /// <summary>
    /// 编辑器类型
    /// </summary>
    public enum EditorType
    {
        TextBox,
        TextBoxLine,
        TextArea,
        RichTextBox,
        NumberBox,
        IntBox,
        UIntBox,
        DateBox,
        CheckBox,
        ComboBox,
        SearchBox,
        FileUpload,
        Template
    }
    /// <summary>
    /// 区域类型
    /// </summary>
    public enum RegionType
    {
        /// <summary>
        /// 东
        /// </summary>
        East,
        /// <summary>
        /// 南
        /// </summary>
        South,
        /// <summary>
        /// 西
        /// </summary>
        West,
        /// <summary>
        /// 北
        /// </summary>
        North,
        /// <summary>
        /// 中
        /// </summary>
        Center
    }
    #endregion

    #region 正则表达式枚举
    public enum RegexType
    {
        None,
        Int,
        Float,
        Email,
        Tel,
        Mobile,
        En,
        Cn,
        Url,
        IP,
        Zip,
        Alpha,
        IdCard,
        CarNo,
        QQ,
        Msn
    }
    #endregion

    #region 邮件相关枚举
    public enum MailFormat
    {
        Text,
        HTML
    };
    public enum MailPriority
    {
        Low = 1,
        Normal = 3,
        High = 5
    };
    #endregion

    #region Http网络枚举
    public enum RequestMethod
    {
        POST,
        GET,
        PUT,
        DELETE
    }
    #endregion
}
