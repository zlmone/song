using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Web.Common.ZTree
{
    public class ZTreeItem : TreeItem
    {
        public ZTreeItem()
        {
            Items = new List<ZTreeItem>();
        }
        private IList<ZTreeItem> items;

        public new IList<ZTreeItem> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
}
