using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace WSH.WPF.Common
{
   public class DataGridHelper
   {
       #region 单击单元格编辑
       public static void SingleClickEditing(object gridCell) {
           DataGridCell cell = gridCell as DataGridCell;
           if (cell != null && !cell.IsEditing && !cell.IsReadOnly)
           {
               if (!cell.IsFocused)
               {
                   cell.Focus();
               }
               DataGrid dataGrid = FindVisualParent<DataGrid>(cell);
               if (dataGrid != null)
               {
                   if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow)
                   {
                       if (!cell.IsSelected)
                           cell.IsSelected = true;
                   }
                   else
                   {
                       DataGridRow row = FindVisualParent<DataGridRow>(cell);
                       if (row != null && !row.IsSelected)
                       {
                           row.IsSelected = true;
                       }
                   }
               }
           }
       }
       #endregion

       #region 查找父元素
       public  static T FindVisualParent<T>(UIElement element) where T : UIElement
       {
           UIElement parent = element;
           while (parent != null)
           {
               T correctlyTyped = parent as T;
               if (correctlyTyped != null)
               {
                   return correctlyTyped;
               }

               parent = VisualTreeHelper.GetParent(parent) as UIElement;
           }
           return null;
       }
       #endregion
   }
}
