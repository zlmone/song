using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common;
using WSH.Common.Helper;

namespace WSH.Web.Common.EasyUI
{
    public class EasyTreeMgr
    {
        public static string GetEasyTree(IList<EasyTreeItem> nodes) {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < nodes.Count; i++)
            {
                EasyTreeItem node = nodes[i];
                sb.Append(GetEasyTreeItem(node));
                if (i < nodes.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }
        public static string GetEasyTreeItem(EasyTreeItem node) {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"id\":"+node.ID);
            sb.Append(",\"text\":\"" + node.Text+"\"");
            sb.Append(",\"state\":\"" + (node.IsClosed ? "closed" : "open")+ "\"");
            if (node.Checked.HasValue)
            {
                sb.Append(",\"checked\":" + node.Checked.Value.ToString().ToLower());
            }
            if(node.Attributes.Count>0){
                sb.Append(",\"attributes\":" + DictHelper.ToJson(node.Attributes));
            }
            if(node.Items.Count >0){
                sb.Append(",\"children\":" + GetEasyTree(node.Items));
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
