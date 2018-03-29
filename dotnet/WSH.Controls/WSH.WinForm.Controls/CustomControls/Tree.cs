using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSH.WinForm.Controls
{
    public partial class Tree : TreeView
    {
        public Tree()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 右键选中树节点
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TreeNode node = this.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    this.SelectedNode = node;
                }
            }
        }
        /// <summary>
        /// 设置子节点的选中状态
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="nodeChecked"></param>
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
        /// <summary>
        /// 设置父节点的选中状态
        /// </summary>
        /// <param name="treeNode"></param>
        private void CheckParentNodes(TreeNode treeNode)
        {
            if (treeNode.Level > 0)
            {
                for (int i = 0; i < treeNode.Parent.GetNodeCount(false); i++)
                {
                    if (treeNode.Parent.Checked == false)
                    {
                        if (treeNode.Parent.Nodes[i].Checked == true)
                        {
                            treeNode.Parent.Checked = true;
                            CheckParentNodes(treeNode.Parent);
                            return;
                        }
                    }
                    else
                    {
                        if (treeNode.Parent.Nodes[i].Checked == true)
                        {
                            CheckParentNodes(treeNode.Parent);
                            return;
                        }
                        if (i == treeNode.Parent.GetNodeCount(false) - 1 && treeNode.Parent.Nodes[i].Checked == false)
                        {
                            treeNode.Parent.Checked = false;
                            CheckParentNodes(treeNode.Parent);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 级联选中节点
        /// </summary>
        /// <param name="e"></param>
        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Level > 0)
                {
                    if (e.Node.Nodes.Count > 0 && e.Node.Parent.Nodes.Count > 0)
                    {
                        CheckAllChildNodes(e.Node, e.Node.Checked);
                        CheckParentNodes(e.Node);
                    }
                    else if (e.Node.Nodes.Count > 0)
                    {
                        CheckAllChildNodes(e.Node, e.Node.Checked);
                    }
                    else if (e.Node.Nodes.Count == 0)
                    {
                        CheckParentNodes(e.Node);
                    }
                }
                else
                {
                    CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
            base.OnAfterCheck(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
