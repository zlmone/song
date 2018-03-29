using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Web.Mvc.Controls.EasyUI 
{
    public class EasyButton : TextControlBase<IButton>, IButton
    {
        public EasyButton() :this(null){
             
        }
        public EasyButton(string id):base(id){
            this.AddClass("easyui-linkbutton");
        }
        public override string TagName
        {
            get
            {
                return "a";
            }
        }
    }
}
