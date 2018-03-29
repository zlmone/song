using System;
using System.Collections.Generic;
using System.Text;
using WSH.Web.Common;
using System.Web.UI;
using WSH.Common;
using WSH.Web.Common.Helper;

namespace WSH.WebForm.Controls
{
   public class MenuMgr
    {
      
       public static string GetMenuItemData(MenuItem item)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append("{");
           sb.AppendFormat("text:'{0}'",item.Text);
           if(!string.IsNullOrEmpty(item.IconUrl)){
               sb.AppendFormat(",icon:'{0}'",item.IconUrl);
           }
           if(item.Icon!= Icons.None){
               item.IconClass = "icon-" + ClientHelper.GetEnum(item.Icon);
           }
           if(!string.IsNullOrEmpty(item.IconClass)){
               sb.AppendFormat(",iconClass:'{0}'",item.IconClass);
           }
           if(!string.IsNullOrEmpty(item.ID)){
               sb.AppendFormat(",id:'{0}'",item.ID);
           }
           if(!string.IsNullOrEmpty(item.OnClientClick)){
               sb.AppendFormat(",onClick:{0}",item.OnClientClick);
           }
           if(!item.Enabled){
               sb.Append(",enabled:false");
           }
           if(item.Items.Count>0){
               if(item.ItemsWidth>0){
                   sb.AppendFormat(",width:"+item.ItemsWidth);
               }
               sb.Append(",items:"+GetMenuData(item.Items));
           }
           sb.Append("}");
           return sb.ToString();
       }
       public static string GetMenuData(List<MenuItem> items) {
           StringBuilder sb = new StringBuilder();
           sb.Append("[");
           for (int i = 0; i < items.Count; i++)
           {
               MenuItem item=items[i];
               sb.Append(GetMenuItemData(item));
               if (i < items.Count - 1)
               {
                   sb.Append(",");
               }
           }
           sb.Append("]");
           return sb.ToString();
       }
    }
}
