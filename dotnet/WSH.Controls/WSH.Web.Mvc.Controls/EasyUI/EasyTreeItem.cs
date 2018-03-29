using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Web.Mvc.Controls.EasyUI
{
   public class EasyTreeItem
    {
       /// <summary>
       /// EasyTree节点属性
       /// </summary>
       public EasyTreeItem() {
           Items = new List<EasyTreeItem>();
           Attributes = new Dictionary<string, object>();
       }
       public string ID{get;set;}
       public string Text{get;set;}
       public string State{get;set;}
       public bool Checked{get;set;}
       public IDictionary<string, object> Attributes { get; set; }
       public IList<EasyTreeItem> Items { get; set; }
    }
}
