using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Common.Helper
{
    public class EditorHelper
    {
        public static EditorType GetEditorType(string editorType)
        {
            if (string.IsNullOrEmpty(editorType))
            {
                return EditorType.TextBox;
            }
            EditorType type = (EditorType)Enum.Parse(typeof(EditorType), editorType);
            return type;
        }
    }
}
