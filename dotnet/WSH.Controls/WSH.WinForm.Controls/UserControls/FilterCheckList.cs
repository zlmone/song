using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Common;

namespace WSH.WinForm.Controls
{
    public partial class FilterCheckList : UserControl
    {
        public FilterCheckList()
        {
            InitializeComponent();
           // this.txtFilter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        }
        /// <summary>
        /// 是否默认全部选中
        /// </summary>
        public bool AllChecked = false;

        protected void CheckedAll() { 
            //检测全选按钮
            var checkedItemsCount = this.checkList.CheckedItems.Count;
            var itemsCount = this.checkList.Items.Count;
            if (itemsCount > 0 && itemsCount == checkedItemsCount)
            {
                this.checkBox.Checked = true;
            }
            else {
                this.checkBox.Checked = false;
            }
        }
        
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="displayField"></param>
        /// <param name="checkedField"></param>
        public void DataBind(DataTable dt,string displayField,string checkedField) {
            //Source = dt;
            foreach (DataRow  row in dt.Rows)
            {
                bool selected=string.IsNullOrEmpty(checkedField) ? AllChecked : Convert.ToBoolean(row[checkedField]);
                this.checkList.Items.Add(row[displayField], selected);
            }
            CheckedAll();
        }
       
        public void DataBind(DataTable dt, string displayField) {
            DataBind(dt,displayField,null);
        }
        public void AddItem(object item,bool isChecked) {
            this.checkList.Items.Add(item,isChecked);
            CheckedAll();
        }
        public bool ExistsItem(object item) {
            return this.checkList.Items.Contains(item);
        }
        public void Clear() {
            this.checkList.Items.Clear();
            this.checkBox.Checked = false;
            this.txtFilter.Text = "";
        }
        /// <summary>
        /// 设置选中的项
        /// </summary>
        private void SetSelected() {
            string value = this.txtFilter.Text.Trim().ToLower();
            if (value != string.Empty)
            {
                foreach (object item in this.checkList.Items)
                {
                    if (item.ToString().ToLower().StartsWith(value))
                    {
                        this.checkList.SelectedItem = item;
                        break;
                    }
                }
                CheckedAll();
            }
        }
        /// <summary>
        /// 得到复选框选中的值
        /// </summary>
        /// <returns></returns>
        public List<string> GetChecked() {
            List<string> list = new List<string>();
            foreach (object  item in this.checkList.CheckedItems)
            {
                list.Add(item.ToString());
            }
            return list;
        }
        /// <summary>
        /// 控制文本框的输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            int index = this.checkList.SelectedIndex;
            if (e.KeyCode == Keys.Enter)
            {
                if(this.checkList.SelectedItem!=null){
                    this.checkList.SetItemChecked(index, !this.checkList.GetItemChecked(index));
                }
            }
            else if(e.KeyCode== Keys.Down){
                index++;
                if(index<checkList.Items.Count){
                    this.checkList.SetSelected(index, true);
                }
            }else if(e.KeyCode== Keys.Up){
                index--;
                if(index>=0){
                    this.checkList.SetSelected(index,true);
                }
            }
            else {
                SetSelected();                
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkList.Items.Count; i++)
            {
                this.checkList.SetItemChecked(i, this.checkBox.Checked);
            }
        }

         
    }
}
