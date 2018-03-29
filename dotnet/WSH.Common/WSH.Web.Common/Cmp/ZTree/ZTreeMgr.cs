using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common;
using WSH.Common.Helper;

namespace WSH.Web.Common.ZTree
{
    public class ZTreeMgr
    {
        public static string GetZTreeItemJson(ZTreeItem node)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("name:\"" + node.Text + "\"");
            sb.Append(",open:" + node.IsOpen.ToString().ToLower());
            if (!string.IsNullOrEmpty(node.Id))
            {
                sb.Append(",id:\"" + node.Id + "\"");
            }
            if (!string.IsNullOrEmpty(node.Pid))
            {
                sb.Append(",pid:\"" + node.Pid  + "\"");
            }
            if (!string.IsNullOrEmpty(node.Value))
            {
                sb.Append(",value:\"" + node.Value + "\"");
            }

            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                foreach (string key in node.Attributes.Keys)
                {
                    object value = node.Attributes[key];
                    if (DataTypeHelper.IsBool(value))
                    {
                        sb.AppendFormat(",{0}:{1}",key, value);
                    }
                    else
                    {
                        sb.AppendFormat(",{0}:\"{1}\"",key, value);
                    }
                }
            }
            if (node.IsChecked.HasValue)
            {
                sb.Append(",checked:" + node.IsChecked.ToString().ToLower());
            }
            if (node.NoCheck.HasValue)
            {
                sb.Append(",nocheck:" + node.NoCheck.ToString().ToLower());
            }
            if (node.IsLeaf.HasValue)
            {
                sb.Append(",isParent:" + (!node.IsLeaf).ToString().ToLower());
            }
            if (!string.IsNullOrEmpty(node.IconUrl))
            {
                sb.Append(",icon:\"" + node.IconUrl + "\"");
            }
            if (!string.IsNullOrEmpty(node.IconOpen))
            {
                sb.Append(",iconOpen:\"" + node.IconOpen + "\"");
            }
            if (!string.IsNullOrEmpty(node.IconClose))
            {
                sb.Append(",iconClose:\"" + node.IconClose + "\"");
            }
            if (!string.IsNullOrEmpty(node.IconClass))
            {
                sb.Append(",iconSkin:\"" + node.IconClass + "\"");
            }
            if (!string.IsNullOrEmpty(node.Target))
            {
                sb.Append(",target:\"" + node.Target + "\"");
            }
            if (!string.IsNullOrEmpty(node.Url))
            {
                sb.Append(",url:\"" + node.Url + "\"");
            }
            if (node.Items.Count > 0)
            {
                sb.Append(",children:");
                sb.Append(GetZTreeJson(node.Items));
            }
            sb.Append("}");
            return sb.ToString();
        }
        public static string GetZTreeJson(IList<ZTreeItem> nodes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < nodes.Count; i++)
            {
                ZTreeItem node = nodes[i];
                sb.Append(GetZTreeItemJson(node));
                if (i < nodes.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
