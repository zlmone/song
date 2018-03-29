using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.WebForm.Controls
{
    public class BasePath
    {

    }
    /// <summary>
    /// jquery.extend.js
    /// </summary>
    public class ScriptJQueryExtend : ScriptBase
    {
        public ScriptJQueryExtend() : base("/js/jquery/jquery.extend.js") { }
    }

    #region zTree
    /// <summary>
    /// zTreeStyle.css
    /// </summary>
    public class StyleZTree : StyleBase
    {
        public StyleZTree() : base("/admin/js/ztree/style/zTreeStyle.css") { }
    }
    /// <summary>
    /// jquery.ztree.core-3.2.min.js
    /// </summary>
    public class ScriptZTreeCore : ScriptBase
    {
        public ScriptZTreeCore() : base("/admin/js/ztree/js/jquery.ztree.core-3.2.min.js") { }
    }
    /// <summary>
    /// jquery.ztree.excheck-3.2.min.js
    /// </summary>
    public class ScriptZTreeCheck : ScriptBase
    {
        public ScriptZTreeCheck() : base("/admin/js/ztree/js/jquery.ztree.excheck-3.2.min.js") { }
    }
    /// <summary>
    /// jquery.ztree.exedit-3.2.min.js
    /// </summary>
    public class ScriptZTreeEdit : ScriptBase
    {
        public ScriptZTreeEdit() : base("/admin/js/ztree/js/jquery.ztree.exedit-3.2.min.js") { }
    }
    #endregion

    #region Song
    /// <summary>
    /// song.menu.js
    /// </summary>
    public class ScriptSongMenu : ScriptBase
    {
        public ScriptSongMenu() : base("/js/song/song.menu.js") { }
    }
    /// <summary>
    /// song.toolbar.js
    /// </summary>
    public class ScriptSongToolbar : ScriptBase
    {
        public ScriptSongToolbar() : base("/js/song/song.toolbar.js") { }
    }
    /// <summary>
    /// song.grid.js
    /// </summary>
    public class ScriptSongGrid : ScriptBase
    {
        public ScriptSongGrid() : base("/js/song/song.grid.js") { }
    }
    #endregion
}