using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Web.Common.EasyUI
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
       private int iD;

       public int ID
       {
           get { return iD; }
           set { iD = value; }
       }
       private string text;

       public string Text
       {
           get { return text; }
           set { text = value; }
       }
       private bool isClosed;

       public bool IsClosed
       {
           get { return isClosed; }
           set { isClosed = value; }
       }
       private bool? _checked;

       public bool? Checked
       {
           get { return _checked; }
           set { _checked = value; }
       }
       private IDictionary<string, object> attributes;

       public IDictionary<string, object> Attributes
       {
           get { return attributes; }
           set { attributes = value; }
       }
       private IList<EasyTreeItem> items;

       public IList<EasyTreeItem> Items
       {
           get { return items; }
           set { items = value; }
       }
    }
}
