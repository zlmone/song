using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using excel = Microsoft.Office.Interop.Excel;

namespace WSH.Office.Excel
{
   public class ExcelCom
    {
       public ExcelCom()
       {
           
           App = new excel.ApplicationClass();
       }
       private excel.ApplicationClass  App=null;
       private excel.Workbook Book = null;
       private excel.Worksheet Sheet = null;
       private object missing = System.Reflection.Missing.Value;
       /// <summary>
       /// 是否显示
       /// </summary>
       public  bool IsVisible = false;
       public void SetVisible(bool isVisible) {
           this.App.Visible = isVisible;
           IsVisible = isVisible;
       }
       /// <summary>
       /// 隐藏不兼容等提示框
       /// </summary>
       public void HideAlert() {
           this.App.DisplayAlerts = false;
       }
       /// <summary>
       /// 新建一个Excel文件并添加一个工作表
       /// </summary>
       public void New() {
           this.HideAlert();
           this.App.Visible = IsVisible;
           Book = App.Workbooks.Add(true);
           try{Book.CheckCompatibility = false;}catch {}
           this.Sheet = Book.ActiveSheet as excel.Worksheet;
       }
       /// <summary>
       /// 打开Excel文件
       /// </summary>
       /// <param name="fileName"></param>
       public void Open(string fileName) {
           if (System.IO.File.Exists(fileName))
           {
               this.HideAlert();
               this.App.Visible = IsVisible;
               Book = App.Workbooks.Open(fileName);
               App.ScreenUpdating = false;
               this.HideAlert();
           }
       }
       /// <summary>
       /// 获取工作表
       /// </summary>
       /// <param name="index"></param>
       public void GetSheet(int index) {
           this.Sheet = (excel.Worksheet)Book.Sheets[index];
       }
       public void GetSheet(string sheetName) {
           this.Sheet = (excel.Worksheet)Book.Sheets[sheetName];
       }
       /// <summary>
       /// 复制工作表内容
       /// </summary>
       public void CopySheet() {
           Sheet.Activate();
           Sheet.Select();
           Sheet.UsedRange.Copy();
       }
       /// <summary>
       /// 粘贴工作表内容
       /// </summary>
       public void PasteSheet()
       {
           Sheet.Activate();
           Sheet.Select();
           Sheet.Range["A1"].PasteSpecial(excel.XlPasteType.xlPasteFormats);
           Sheet.Range["A1"].PasteSpecial(excel.XlPasteType.xlPasteValues);
       }
       /// <summary>
       /// 获取工作表的数量
       /// </summary>
       /// <returns></returns>
       public int GetSheetCount()
       {
           return Book==null ? 0 : Book.Sheets.Count;
       }
       /// <summary>
       /// 获取工作表的名称集合
       /// </summary>
       /// <returns></returns>
       public string[] GetSheetNames()
       {
           int count = GetSheetCount();
           string[] sheets = new string[count];
           for (int i = 0; i < count; i++)
           {
               sheets[i] = ((excel.Worksheet)Book.Sheets[i + 1]).Name;
           }
           return sheets;
       }
       /// <summary>
       /// 设置当前工作表的名称
       /// </summary>
       public void SetSheetName(string name)
       {
           this.Sheet.Name = name;
       }
       /// <summary>
       /// 列的宽度自适应
       /// </summary>
       public void AutoColumn() {
           Sheet.Columns.EntireColumn.AutoFit();
       }
       /// <summary>
       /// 在当前的工作表的前或者后插入新的工作表
       /// </summary>
       /// <param name="isActiveSheetAfter">是否在当前的工作表的后面插入新工作表</param>
       public void AddSheet(bool isActiveSheetAfter)
       {
           if (Book == null)
           {
               this.New();
           }
           else
           {
               this.Sheet = this.App.Worksheets.Add((isActiveSheetAfter ? missing : this.Sheet),
                   isActiveSheetAfter ? this.Sheet : missing) as excel.Worksheet;
           }
       }
       /// <summary>
       /// 获取总行数
       /// </summary>
       /// <returns></returns>
       public int GetRowCount()
       {
           return ((object[,])Sheet.UsedRange.Value2).GetLength(0); 
       }
       /// <summary>
       /// 获取单元格的值
       /// </summary>
       public object GetCell(int row, int col)
       {
           return ((excel.Range)Sheet.Cells[row, col]).Text;
       }
       /// <summary>
       /// 设置单元格的值
       /// </summary>
       public void WriteCell(int row, int col, object o)
       {
           Sheet.Cells[row, col] = o;
       }
       public void Write(DataTable dt, int beginRow, int beginCol, bool isColumn) {
           if (dt == null || dt.Rows.Count <= 0) { return; }
           int cols = dt.Columns.Count;
           int rows = dt.Rows.Count;
           if (isColumn)
           {
               for (int k = 0; k < cols; k++)
               {
                   this.Sheet.Cells[beginRow, beginCol + k] = dt.Columns[k].ColumnName;
               }
               beginRow++;
           }
           for (int i = 0; i < rows; i++)
           {
               for (int j = 0; j < cols; j++)
               {
                   this.Sheet.Cells[beginRow + i, beginCol + j] = dt.Rows[i][j];
               }
           }
       }
       public DataTable Read(int beginRow, int beginCol, int endRow, int endCol)
       {
           excel.Range range = Sheet.get_Range(ToExcelCellIndex(beginRow, beginCol), ToExcelCellIndex(endRow, endCol));
           object[,] values = (object[,])range.Value2;
           DataTable dt = new DataTable();
           DataRow dr = null;
           for (int i = 0; i < values.GetLength(1); i++) dt.Columns.Add();
           for (int i = 0; i < values.GetLength(0); i++)
           {
               dr = dt.NewRow();
               for (int j = 0; j < values.GetLength(1); j++)
               {
                   dr[j] = values[i + 1, j + 1];
               }
               dt.Rows.Add(dr);
           }
           return dt;
       }
       public DataTable Read()
       {
           object[,] values = (object[,])Sheet.UsedRange.Value2;
           DataTable dt = new DataTable();
           for (int i = 0; i < values.GetLength(1); i++)
           {
               dt.Columns.Add();
           }
           for (int i = 0; i < values.GetLength(0); i++)
           {
               DataRow dr = dt.NewRow();
               for (int j = 0; j < values.GetLength(1); j++)
                   dr[j] = values[i + 1, j + 1];
               dt.Rows.Add(dr);
           }
           return dt;
       }
       public DataTable ReadWithColumn()
       {
           object[,] values = (object[,])Sheet.UsedRange.Value2;
           DataTable dt = new DataTable();
           for (int i = 0; i < values.GetLength(1); i++)
           {
               dt.Columns.Add();
               if (values[1, i + 1] != null)
               {
                   dt.Columns[i].ColumnName = values[1, i + 1].ToString();
               }
           }
           for (int i = 1; i < values.GetLength(0); i++)
           {
               DataRow dr = dt.NewRow();
               for (int j = 0; j < values.GetLength(1); j++)
                   dr[j] = values[i + 1, j + 1];
               dt.Rows.Add(dr);
           }
           return dt;
       }
       public void DeleteRange(int startRow, int startColumn, int endRow, int endColumn, bool IsDeleteEntireRow)
       {
         excel.Range  range = App.get_Range(App.Cells[startRow, startColumn], App.Cells[endRow, endColumn]);
           range.Select();
           if (IsDeleteEntireRow)
           {
               range.EntireRow.Delete(excel.XlDeleteShiftDirection.xlShiftUp); //是否整行删除 
           }
           else
           {
               range.Delete(excel.XlDeleteShiftDirection.xlShiftUp);
           }
       }
       /// <summary>
       /// 插入行
       /// </summary>
       public void InsertRow(int startRow, int count)
       {
            excel.Range range1 =(excel.Range)Sheet.Rows.get_Item(startRow, Type.Missing);
           for (int i = 0; i < count; i++)
           {
               range1.Insert(excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
           }
           range1 = null;
       }
       /// <summary>
       /// 插入列
       /// </summary>
       public void InsertColumn(int startCol, int count)
       {
           excel.Range range1 =(excel.Range)Sheet.Columns.get_Item(startCol, Type.Missing);
           for (int i = 0; i < count; i++)
           {
               range1.Insert(excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
           }
           range1 = null;
       }
       /// <summary>
       /// 合并单元格
       /// </summary>
       public void MergeCell(int beginRow, int beginCol, int endRow, int endCol)
       {
           Sheet.get_Range(Sheet.Cells[beginRow, beginCol], Sheet.Cells[endRow, endCol]).Merge(true);
       }
       /// <summary>
       /// 设置格式
       /// </summary>
       public void SetFormat(int startRow, int startCol, int endRow, int endCol, System.Collections.Hashtable htFormat)
       {
           object m_objOpt = System.Reflection.Missing.Value;
           excel.Range  range = Sheet.get_Range(ToExcelCellIndex(startRow, startCol), ToExcelCellIndex(endRow, endCol));
           if (htFormat.Contains("NumberFormat")) range.NumberFormatLocal = htFormat["NumberFormat"];
           if (htFormat.Contains("BoldFont")) range.Font.Bold = htFormat["BoldFont"];
           if (htFormat.Contains("SetBorders"))
               if (htFormat["SetBorders"].Equals("粗")) range.Borders.Weight = excel.XlBorderWeight.xlThick;
               else if (htFormat["SetBorders"].Equals("细")) range.Borders.Weight = excel.XlBorderWeight.xlThin;
               else range.Borders.Weight = excel.XlBorderWeight.xlMedium;
           if (htFormat.Contains("LeftThickBorder") && htFormat.ContainsValue("加粗"))
               range.Borders[excel.XlBordersIndex.xlEdgeLeft].Weight = excel.XlBorderWeight.xlMedium;
           if (htFormat.Contains("RightThickBorder") && htFormat.ContainsValue("加粗"))
               range.Borders[excel.XlBordersIndex.xlEdgeRight].Weight = excel.XlBorderWeight.xlMedium;
           if (htFormat.Contains("BottomtThickBorder") && htFormat.ContainsValue("加粗"))
               range.Borders[excel.XlBordersIndex.xlEdgeBottom].Weight = excel.XlBorderWeight.xlMedium;
           if (htFormat.Contains("TopThickBorder") && htFormat.ContainsValue("加粗"))
               range.Borders[excel.XlBordersIndex.xlEdgeTop].Weight = excel.XlBorderWeight.xlMedium;
           if (htFormat.Contains("FontName")) range.Font.Name = htFormat["FontName"];
           if (htFormat.Contains("FontSize")) range.Font.Size = htFormat["FontSize"];
           if (htFormat.Contains("FontColor")) range.Font.Color = htFormat["FontColor"];
           if (htFormat.Contains("RowHeight")) range.RowHeight = htFormat["RowHeight"];
           if (htFormat.Contains("ColumnWidth")) range.ColumnWidth = htFormat["ColumnWidth"];
       }
       public string ToExcelCellIndex(int row, int col)
       {
           string index = "";
           do
           {
               col--;
               index = (char)('A' + col % 26) + index;
               col = col / 26;
           } while (col > 0);
           index += row.ToString();
           return index;
       }
       /// <summary>
       /// 另存为
       /// </summary>
       public void SaveAs(string fileName)
       {
           Book.Saved = true;
           Book.SaveAs(fileName, excel.XlFileFormat.xlWorkbookNormal, missing, missing,missing,missing,
                        excel.XlSaveAsAccessMode.xlNoChange);
       }
       /// <summary>
       /// 保存
       /// </summary>
       public void Save()
       {
           Book.Saved = true;
           Book.Save();
       }
       #region 关闭资源
       public void Close()
       {
           if (Sheet != null)
           {
               System.Runtime.InteropServices.Marshal.ReleaseComObject(Sheet);
               Sheet = null;
           }
           if (Book != null)
           {
               System.Runtime.InteropServices.Marshal.ReleaseComObject(Book);
               Book = null;
           }
           if (App != null)
           {
               App.Application.Workbooks.Close();
               App.Quit();
               System.Runtime.InteropServices.Marshal.ReleaseComObject(App);
               App = null;
           }
           GC.Collect();
       }
       #endregion

    }
}
