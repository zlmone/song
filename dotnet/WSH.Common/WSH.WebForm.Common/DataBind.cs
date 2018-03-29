using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using WSH.Common;
using WSH.Web.Common;
using WSH.Options.Common;

namespace WSH.WebForm.Common
{
  public  class DataBind
    {
      //  #region 服务器树控件绑定
      //public void BindTreeView(TreeOptions tc, TreeView tv)
      //  {
      //      if (tc != null && tc.DataSource != null && tc.DataSource.Rows.Count > 0)
      //      {
      //          DataRow[] prow = tc.DataSource.Select(tc.Pid + "='" + tc.Root + "'");
      //          foreach (DataRow row in prow)
      //          {
      //              TreeNode node = new TreeNode();
      //              node.Text = row[tc.Txt].ToString();
      //              node.Value = row[tc.Id].ToString();
      //              if (!string.IsNullOrEmpty(tc.TarGet))
      //              {
      //                  node.Target = tc.TarGet;
      //              }
      //              Param param = new Param();
      //              param.Set(tc.Id, row[tc.Id].ToString());
      //              param.Set(tc.Txt, row[tc.Txt].ToString());
      //              string[] str = new string[] { };
      //              if (!string.IsNullOrEmpty(tc.OtherValue))
      //              {
      //                  str = tc.OtherValue.Split(",".ToCharArray());
      //              }
      //              for (int i = 0; i < str.Length; i++)
      //              {
      //                  param.Set(str[i], row[str[i]].ToString());
      //              }

      //              if (!string.IsNullOrEmpty(tc.Url))
      //              {
      //                  node.NavigateUrl = row[tc.Url].ToString() + param.ToAndParam();
      //              }
      //              else if (!string.IsNullOrEmpty(tc.NodeClick))
      //              {
      //                  StringBuilder sb = new StringBuilder();
      //                  sb.Append("{");
      //                  string valString = "";

      //                  for (int i = 0; i < str.Length; i++)
      //                  {
      //                      if (str[i] != tc.Txt && str[i] != tc.Id)
      //                      {
      //                          valString += str[i] + ":'" + row[str[i]].ToString() + "',";
      //                      }
      //                  }

      //                  sb.Append(valString);
      //                  sb.AppendFormat("{0}:'{1}',", tc.Id, row[tc.Id].ToString());
      //                  sb.AppendFormat("{0}:'{1}'", tc.Txt, row[tc.Txt].ToString());
      //                  sb.Append("}");
      //                  node.NavigateUrl = "javascript:" + tc.NodeClick + "(" + sb.ToString() + ");";
      //              }
      //              else
      //              {
      //                  node.NavigateUrl = tc.Href + param.ToAndParam();
      //              }
      //              tv.Nodes.Add(node);
      //              //绑定所有子节点
      //              childNodeBind(tc, node);
      //          }
      //          tv.RootNodeStyle.ImageUrl = "~/js/MzTreeView/images/folder.gif";
      //          tv.ParentNodeStyle.ImageUrl = "~/js/MzTreeView/images/folder.gif";
      //          tv.LeafNodeStyle.ImageUrl = "~/js/MzTreeView/images/file.gif";
      //          tv.CssClass = "WebTree";
      //          tv.SelectedNodeStyle.CssClass = "WebTreeSelect";
      //          tv.HoverNodeStyle.CssClass = "WebTreeHover";
      //          tv.ShowLines = true;
      //          if (tc.ShowCheck)
      //          {
      //              tv.ShowCheckBoxes = TreeNodeTypes.All;
      //          }
      //          tv.ExpandAll();
      //      }
      //  }
      //  private void childNodeBind(TreeOptions tc, TreeNode pNode)
      //  {
      //      if (tc != null && tc.DataSource != null && tc.DataSource.Rows.Count > 0)
      //      {
      //          DataRow[] crow = tc.DataSource.Select(tc.Pid + "='" + pNode.Value + "'");
      //          foreach (DataRow subrow in crow)
      //          {
      //              TreeNode subnode = new TreeNode();
      //              subnode.Text = subrow[tc.Txt].ToString();
      //              subnode.Value = subrow[tc.Id].ToString();
      //              if (!string.IsNullOrEmpty(tc.TarGet))
      //              {
      //                  subnode.Target = tc.TarGet;
      //              }
      //              Param param = new Param();
      //              param.Set(tc.Id, subrow[tc.Id].ToString());
      //              param.Set(tc.Txt, subrow[tc.Txt].ToString());
      //              string[] str = new string[] { };
      //              if (!string.IsNullOrEmpty(tc.OtherValue))
      //              {
      //                  str = tc.OtherValue.Split(",".ToCharArray());
      //              }
      //              for (int i = 0; i < str.Length; i++)
      //              {
      //                  param.Set(str[i], subrow[str[i]].ToString());
      //              }
      //              if (!string.IsNullOrEmpty(tc.Url))
      //              {
      //                  subnode.NavigateUrl = subrow[tc.Url].ToString() + param.ToAndParam();
      //              }
      //              else if (!string.IsNullOrEmpty(tc.NodeClick))
      //              {
      //                  StringBuilder sb = new StringBuilder();
      //                  sb.Append("{");
      //                  string valString = "";

      //                  for (int i = 0; i < str.Length; i++)
      //                  {
      //                      if (str[i] != tc.Txt && str[i] != tc.Id)
      //                      {
      //                          valString += str[i] + ":'" + subrow[str[i]].ToString() + "',";
      //                      }
      //                  }

      //                  sb.Append(valString);
      //                  sb.AppendFormat("{0}:'{1}',", tc.Id, subrow[tc.Id].ToString());
      //                  sb.AppendFormat("{0}:'{1}'", tc.Txt, subrow[tc.Txt].ToString());
      //                  sb.Append("}");
      //                  subnode.NavigateUrl = "javascript:" + tc.NodeClick + "(" + sb.ToString() + ");";
      //              }
      //              else
      //              {
      //                  subnode.NavigateUrl = tc.Href + param.ToAndParam();
      //              }
      //              pNode.ChildNodes.Add(subnode);
      //              //递归绑定所有子节点
      //              childNodeBind(tc, subnode);
      //          }
      //      }
      //  }
      //  #endregion


        //#region 绑定MzTreeView的方法
        //public void MzTreeViewBind(TreeConfig tc, bool isMenu)
        //{
        //    if (tc != null && tc.DataSource != null && tc.DataSource.Rows.Count > 0)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("<script type='text/javascript'>");
        //        sb.Append("window.tree = new MzTreeView('tree');\n");
        //        sb.Append("tree.setIconPath('../js/MzTreeView/images/');\n");
        //        foreach (DataRow row in tc.DataSource.Rows)
        //        {
        //            sb.Append("tree.N['" + row[tc.Pid].ToString() + "_" + row[tc.Id].ToString() + "']= ");
        //            sb.Append("'");
        //            sb.Append("ctrl:" + tc.CheckName + ";");
        //            sb.Append("checked:false;");
        //            sb.Append("T:" + row[tc.Txt].ToString() + ";");
        //            sb.Append("url:" + tc.Url);
        //            sb.Append("'\n");
        //        }
        //        sb.Append("document.getElementById('" + tc.TreeId + "').innerHTML=tree.toString();");
        //        sb.Append("tree.setTarget('" + tc.TarGet + "');");
        //        sb.Append("tree.expandAll();");
        //        sb.Append("</script>");
        //        tc.ScriptId.Text = sb.ToString();
        //    }
        //}
        //#endregion

        //#region 绑定DTree的方法
        //public void DTreeBind(TreeConfig TC)
        //{
        //    if (TC != null && TC.DataSource != null && TC.DataSource.Rows.Count > 0)
        //    {
        //        StringBuilder builder = new StringBuilder();
        //        builder.Append("<script type='text/javascript'>");
        //        builder.Append("d=new dTree('d');\n");
        //        foreach (DataRow row in TC.DataSource.Rows)
        //        {
        //            builder.Append("d.add('" + row[TC.Id].ToString() + "',");
        //            builder.Append("'" + row[TC.Pid].ToString() + "',");
        //            builder.Append("'" + row[TC.Txt].ToString() + "',");
        //            builder.Append("'" + row[TC.Url].ToString() + "',");
        //            builder.Append("'" + TC.Hint + "',");
        //            builder.Append("'" + TC.TarGet + "'");
        //            builder.Append(");\n");
        //        }
        //       // builder.Append("alert(d);");
        //        builder.Append("document.write(d);");
        //        builder.Append("</script>");
        //        TC.ScriptId.Text = builder.ToString();
        //    }
        //}
        //#endregion
        //#region 服务器树控件绑定
        //public void TreeViewBind(TreeView tv, DataTable dt)
        //{
        //    DataView dv = new DataView(dt);
        //    dv.RowFilter = "ParentID='-1'";

        //    foreach (DataRow row in dv.Table.Rows)
        //    {
        //        TreeNode node = new TreeNode();
        //        node.Text = row["DepartmaneName"].ToString();
        //        node.Value = row["DepartmentID"].ToString();
        //        tv.Nodes.Add(node);
        //        //绑定所有子节点
        //        childNodeBind(dt, node);
        //    }
        //    tv.ShowLines = true;//显示虚线
        //    tv.ExpandAll();//全部展开
        //}
        //private void childNodeBind(DataTable dt, TreeNode pNode)
        //{
        //    DataView dv = new DataView(dt);
        //    dv.RowFilter = "ParentID='" + pNode.Value + "'";

        //    foreach (DataRow subrow in dv.Table.Rows)
        //    {
        //        TreeNode subnode = new TreeNode();
        //        subnode.Text = subrow["DepartmaneName"].ToString();
        //        subnode.Value = subrow["DepartmentID"].ToString();
        //        pNode.ChildNodes.Add(subnode);
        //        //递归绑定所有子节点
        //        childNodeBind(tc, subnode);
        //    }
        //}
        // #endregion
    }
}
