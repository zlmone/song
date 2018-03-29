using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WSH.Web.Common;
using WSH.WebForm.Common;
using WSH.Web.Common.Helper;

namespace WSH.WebForm.Controls
{
    [ToolboxData("<{0}:Button runat=server></{0}:Button>")]
    public class Button : LinkButton
    {
        public Button() { }
        public Button(string text) { this.Text = text; }
        public Button(string text, ButtonSkinType skin)
        {
            this.Text = text;
            this.Skin = skin;
        }
        private ButtonSkinType skin= ButtonSkinType.LightBlue;

        public ButtonSkinType Skin
        {
            get {return skin; }
            set { skin = value; }
        }
        private CmdType cmdType = CmdType.Add;
        /// <summary>
        /// 按钮操作类型
        /// </summary>
        public CmdType CmdType
        {
            get { return cmdType; }
            set { cmdType = value; }
        }
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            string skin = ClientHelper.GetEnum(this.Skin);
            this.CssClass = "inline-block btn-" + skin;
            if(this.Skin== ButtonSkinType.LightBlue){
                this.CssClass += " radius";
            }
            HtmlGenericControl btnRight = new HtmlGenericControl("span");
            if (Skin == ButtonSkinType.Ext)
            {
                btnRight.Attributes.Add("class", string.Format("inline-block btn-{0}-right", skin));
                HtmlGenericControl btnCenter = new HtmlGenericControl("span");
                btnCenter.Attributes.Add("class", string.Format("inline-block btn-{0}-center", skin));
                btnCenter.InnerHtml = Text;
                btnRight.Controls.Add(btnCenter);
            }
            else
            {
                btnRight.Attributes.Add("class","inline-block");
                btnRight.InnerHtml = Text;
            }
            this.Controls.Add(btnRight);
            this.ChildControlsCreated = true;
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
    }
    public enum ButtonSkinType { 
        Ext,EasyUI,QQ,LightBlue
    }
    public enum CmdType { 
        Edit,Add,View,Query,Delete,Report,Print,Save,SaveAdd,Cancel,Close
    }
}
