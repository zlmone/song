using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WSH.WinForm.Controls
{
    public partial class Pagination : UserControl
    {
        private int pageIndex=1;

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }
        private int[] PageSizeList=new int[]{5,10,15,20,30,40,50,80,100};
 
        private int pageSize=20;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        private int pageCount = 0;

        public int PageCount
        {
            get { return pageCount; }
            set { pageCount = value; }
        }
        private int totalRecord=0;

        public int TotalRecord
        {
            get { return totalRecord; }
            set { totalRecord = value; }
        }
        public delegate void PagingEventHandler(int PageIndex, int PageSize);
        public event PagingEventHandler OnPagingChange;
        public Pagination()
        {
            InitializeComponent();
            this.PageList.KeyPress += new KeyPressEventHandler(PageList_KeyPress);
          
        }
        void PageList_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
        }
        private void Paging_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < PageSizeList.Length; i++)
            {
                int item=PageSizeList[i];
                if (item == this.PageSize)
                {
                    this.PageList.Items.Add(this.PageSize);
                    this.PageList.SelectedItem = PageSize;
                }
                else {
                    this.PageList.Items.Add(item);
                }
                
            }
            //this.DataBind();
        }

        public void DataBind()
        {
             
            if (OnPagingChange != null)
            {
                OnPagingChange(PageIndex, PageSize);
            }
            this.Toolbar.MoveFirstItem.Enabled = true;
            this.Toolbar.MovePreviousItem.Enabled = true;
            this.Toolbar.MoveNextItem.Enabled = true;
            this.Toolbar.MoveLastItem.Enabled = true;
            if (this.TotalRecord % this.PageSize == 0)
            {
                this.pageCount = totalRecord / pageSize;
            }
            else
            {
                this.pageCount = totalRecord / pageSize + 1;
            }
            if (pageIndex <= 1)
            {
                this.Toolbar.MoveFirstItem.Enabled = false;
                this.Toolbar.MovePreviousItem.Enabled = false;
            }
            if (pageIndex == pageCount || pageCount == 0)
            {
                this.Toolbar.MoveNextItem.Enabled = false;
                this.Toolbar.MoveLastItem.Enabled = false;
            }
            this.PageResult.Text = totalRecord.ToString();
            this.Toolbar.PositionItem.Text = pageIndex.ToString();
            this.Toolbar.CountItem.Text = "/"+pageCount.ToString();
            if (pageCount > 1)
            {
                this.Toolbar.PositionItem.Enabled = true;
            }
            else {
                this.Toolbar.PositionItem.Enabled = false;
            }
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            this.PageIndex = 1;
            this.DataBind();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            this.PageIndex--;
            this.DataBind();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            this.PageIndex++;
            this.DataBind();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            this.PageIndex = PageCount;
            this.DataBind();
        }

   
        private void PageList_TextChanged(object sender, EventArgs e)
        {
            
            string item = PageList.SelectedItem.ToString();
            if (item != PageSize.ToString())
            {
                this.pageIndex = 1;
                this.PageSize = Convert.ToInt32(item);
                this.DataBind();
            }
        }

        private void bindingNavigatorPositionItem_KeyUp(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode== Keys.Enter){
                int val=int.Parse(this.Toolbar.PositionItem.Text);
                if(val!=pageIndex){
                    if(val>pageCount){
                        val = pageCount;
                    }
                    this.pageIndex = val;
                    this.DataBind();
                }
            }
        }

        private void bindingNavigatorPositionItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
        }

        
        
    }
}
