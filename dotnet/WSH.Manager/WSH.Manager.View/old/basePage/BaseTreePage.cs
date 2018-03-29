//using System;
//using System.Collections.Generic;
//using System.Web;
//using WSH.WebForm.Controls;
//using WSH.Web.Common;
//using WSH.Options.Common;

//namespace Song.WebSite.View.admin
//{
//    public class BaseTreePage : BaseListPage
//    {
//        protected override void OnLoad(EventArgs e)
//        {
//            base.OnLoad(e);
//            //异步加载树节点
//            if (Param.IsAsync("asyncLoadTree"))
//            {
//                List<TreeItem> items=AsyncLoad();
//                if (items!=null)
//                {
//                    string json = ZTreeMgr.GetzTreeData(items);
//                    ResponseWrite(json);
//                }
//            }
//            //编辑树节点
//            if(Param.IsAsync("editTreeNode")){
//                string nodeText = Param.Get("treeNodeText");
//                string nodeValue = Param.Get("treeNodeValue");
//                Result result = new Result();
//                try
//                {
//                    result.IsSuccess = EditTreeNode(nodeText, nodeValue, result);
//                    if (result.IsSuccess)
//                    {
//                        result.Msg = "保存成功";
//                    }
//                    else {
//                        result.Msg = "保存失败";
//                    }
//                }
//                catch (Exception ex) {
//                    result.IsSuccess = false;
//                    result.Msg = "保存失败，错误信息："+Client.ToHtml(ex.Message);
//                }
//                ResponseWrite(result.GetJsonString());
//            }
//            //删除树节点
//            if (Param.IsAsync("removeTreeNode"))
//            {
//                string nodeValue = Param.Get("treeNodeValue");
//                Result result = new Result();
//                try
//                {
//                    result.IsSuccess = RemoveTreeNode(nodeValue, result);
//                    if (result.IsSuccess)
//                    {
//                        result.Msg = "删除节点成功";
//                    }
//                    else {
//                        result.Msg = "删除节点失败";
//                    }
//                }
//                catch (Exception ex) {
//                    result.IsSuccess = false;
//                    result.Msg = "删除节点失败，错误信息："+Client.ToHtml(ex.Message);
//                }
//                ResponseWrite(result.GetJsonString());
//            }
//            //添加子节点 
//            if (Param.IsAsync("addTreeChildNode"))
//            {
//                string nodeText = Param.Get("treeNodeText");
//                string parentValue = Param.Get("parentNodeValue");
//                TreeItem node = new TreeItem();
//                node.Text = nodeText;
//                node.PID=parentValue;
//                Result result = new Result();
//                try
//                {
//                    result.IsSuccess = AddTreeNode(node,result);
//                    if (result.IsSuccess)
//                    {
//                        result.Msg = "添加节点成功";
//                    }
//                    else
//                    {
//                        result.Msg = "添加节点失败";
//                    }
//                }
//                catch (Exception ex)
//                {
//                    result.IsSuccess = false;
//                    result.Msg = "添加节点失败，错误信息：" + Client.ToHtml(ex.Message);
//                }
//                result.Attr.Add("newNode", ZTreeMgr.GetzTreeItemData(node));
//                ResponseWrite(result.GetJsonString());
//            }
//            //绑定树节点
//            BindTree();
//        }
//        public virtual List<TreeItem> AsyncLoad() {
//            return null;
//        }
//        public virtual bool EditTreeNode(string text,string value,Result result) {
//            return true;
//        }
//        public virtual bool RemoveTreeNode(string value, Result result) {
//            return true;
//        }
//        public virtual bool AddTreeNode(TreeItem item, Result result)
//        {
//            return true;
//        }
//        public virtual void BindTree() { 
            
//        }
//    }
//}