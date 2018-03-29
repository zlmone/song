//using System;
//using System.Collections.Generic;
//using System.Web;
//using System.Web.UI.HtmlControls;
//using System.Web.UI;

////using WSH.WebForm.Common;
////using WSH.Web.Common;
////using WSH.Options.Common;
////using WSH.WebForm.Controls;

//namespace Song.WebSite.View.admin
//{
//    public class BaseEditPage:BasePage
//    {
//        private bool isClosePage = true;
//        /// <summary>
//        /// 保存之后是否关闭窗口
//        /// </summary>
//        public bool IsClosePage
//        {
//            get { return isClosePage; }
//            set { isClosePage = value; }
//        }
//        private bool isClearForm = true;
//        /// <summary>
//        /// 保存之后是否情况表单的值
//        /// </summary>
//        public bool IsClearForm
//        {
//            get { return isClearForm; }
//            set { isClearForm = value; }
//        }
//        private bool isEdit=false;
//        /// <summary>
//        /// 当前页面是否是修改模式
//        /// </summary>
//        protected bool IsEdit
//        {
//            get {
//                return isEdit;
//            }
//        }
//        private bool isView = false;
//        /// <summary>
//        /// 当前页面是否是查看模式
//        /// </summary>
//        protected bool IsView
//        {
//            get
//            {
//                return isView;
//            }
//        }
//        private bool isAdd=true;
//        /// <summary>
//        /// 当前页面是否是新增模式
//        /// </summary>
//        protected bool IsAdd
//        {
//            get
//            {
//                return isAdd;
//            }
//        }
//        private string id;
//        /// <summary>
//        /// 修改的主键ID
//        /// </summary>
//        protected string RecordID {
//            get { return id; }
//            set { id = value; }
//        }
//        /// <summary>
//        /// 保存数据成功的次数
//        /// </summary>
//        protected int SaveSuccessCount {
//            set {
//                ViewState["SaveSuccessCount"] = value;
//            }
//            get {
//                return ViewState["SaveSuccessCount"] == null ? 0 : Convert.ToInt32(ViewState["SaveSuccessCount"]);
//            }
//        }
//        /// <summary>
//        /// 输出当前的保存数据成功的次数
//        /// </summary>
//        private void WriteSaveSuccessCount()
//        {
//            string nameid = "hideSaveSuccessCount";
//            HtmlGenericControl g = new HtmlGenericControl("input");
//            g.Attributes.Add("type","hidden");
//            g.Attributes.Add("id",nameid);
//            g.Attributes.Add("name", nameid);
//            g.Attributes.Add("value",SaveSuccessCount.ToString());
//            this.Form.Controls.AddAt(0,g);
//        }
//        /// <summary>
//        /// 保存页面数据
//        /// </summary>
//        protected virtual bool SaveData(Result result)
//        {
//            return true;   
//        }
//        protected virtual bool SaveTreeData(TreeItem node,Result result) {
//            return true;
//        }
//        protected virtual void Save()
//        {
//            Result r = new Result();
//            r.Msg="保存数据成功";
//            try
//            {
//                if (Param.Has("editPageMode", "tree"))
//                {
//                    TreeItem node = new TreeItem();
//                    r.IsSuccess = this.SaveTreeData(node,r);
//                    if(r.IsSuccess){
//                        r.Attr.Add("treeNode", ZTreeMgr.GetzTreeItemData(node));
//                    }
//                }
//                else
//                {
//                    r.IsSuccess = this.SaveData(r);
//                }
//                if(!r.IsSuccess){
//                    r.Msg = "保存数据失败";
//                }
//            }
//            catch (Exception ex) {
//                r.IsSuccess = false;
//                r.Msg = "保存数据失败,错误信息：<br>"+Client.ToHtml(ex.Message);
//            }
//            if(r.IsSuccess){
//                SaveSuccessCount++;
//                if(this.IsClearForm){
//                    this.ClearForm();
//                }
//            }
//            r.Attr.Add("isClosePage", isClosePage.ToString().ToLower());
//          //  r.Attr.Add("SaveSuccessCount",SaveSuccessCount.ToString());
//            WriteSaveSuccessCount();
//            Script.WriteScript(this.Page,"SaveAfter","song.page.saveAfter(" + r.GetJsonString() + ");");
//        } 
//        /// <summary>
//        /// 绑定页面数据
//        /// </summary>
//        protected virtual void BindData()
//        { 
            
//        }
//        protected override void OnLoad(EventArgs e)
//        {
//            base.OnLoad(e);
//            string action = Param.Get("action");
//            this.isEdit = action == "Edit";
//            this.isView = action == "View";
//            this.isAdd = action == "Add";
//            //窗体的数据主键id
//            string id = Param.Get("id");
//            if(!string.IsNullOrEmpty(id)){
//                this.id = id;
//            }
//            //保存之后是否关闭窗体
//            string isclose = Param.Get("isClosePage");
//            if (!string.IsNullOrEmpty(isclose))
//            {
//                this.isClosePage = Convert.ToBoolean(isclose);
//            }
//            Control c = this.Form.FindControl("btnSaveAdd");
//            Control save = this.Form.FindControl("btnSave");
//            if (isEdit || isView)
//            {
//                if (c != null) { c.Visible = false; };
//                if(isView){
//                    if (save != null) { save.Visible = false; };
//                    this.EnabledForm();
//                }
//            }
//            //绑定保存事件
//            if(c!=null && c.Visible==true){
//                Button b = (Button)c;
//                b.Click += new EventHandler(b_Click);
//            }
//            if (save != null && save.Visible == true)
//            {
//                Button saveBtn = (Button)save;
//                saveBtn.Click += new EventHandler(saveBtn_Click);
//            }
//            if (!IsPostBack && !string.IsNullOrEmpty(id))
//            {
//                BindData();
//            }
//        }
//        //保存数据之后关闭窗口
//        void saveBtn_Click(object sender, EventArgs e)
//        {
//            this.IsClosePage = true;
//            this.IsClearForm = false;
//            this.Save();
//        }
//        //保存数据之后不关闭窗口
//        void b_Click(object sender, EventArgs e)
//        {
//            this.IsClosePage = false;
//            this.IsClearForm = true;
//            this.Save();
//        }
//        /// <summary>
//        /// 清空页面控件的值
//        /// </summary>
//        protected void ClearForm()
//        {
//            Script.WriteScript(this, "ClearForm", string.Format("$(\"#{0}\").clearForm();", this.Form.ClientID));
//        }
//        /// <summary>
//        /// 设置页面控件为只读
//        /// </summary>
//        protected void EnabledForm()
//        {
//            Script.WriteScript(this,"EnabledForm", string.Format("$(\"#{0}\").enabledForm();", this.Form.ClientID));
//        }
//    }
//}