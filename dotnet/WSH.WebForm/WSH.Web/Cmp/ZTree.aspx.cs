using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSH.WebForm.Controls;

namespace WSH.Web.Cmp
{
    public partial class TreeControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            BindTreeItems();
           
        }
        public void BindTreeItems()
        {
            this.tree.Items.Add(
                 new TreeItem()
                 {
                     ID = "1",
                     Text = "我是后台添加的节点",
                 });
        }

    }
}