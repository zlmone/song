using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using Microsoft.Office.Interop.Word;
using word = Microsoft.Office.Interop.Word;

namespace WSH.Office.Word
{
    public class WordCom
    {
        private Microsoft.Office.Interop.Word.ApplicationClass App;
        private Microsoft.Office.Interop.Word.Document Doc;
        object missing = System.Reflection.Missing.Value;
        public string FileName { get; set; }

        public bool IsVisible = false;

        public bool IsReadOnly = false;
        public Microsoft.Office.Interop.Word.ApplicationClass WordApplication
        {
            get { return App; }
        }
        public WordCom()
        {
            // activate the interface with the COM object of Microsoft Word
            App = new Microsoft.Office.Interop.Word.ApplicationClass();
        }

        public WordCom(Microsoft.Office.Interop.Word.ApplicationClass wordapp)
        {
            App = wordapp;
        }

        #region 文件操作

        // Open a file (the file must exists) and activate it
        public void Open(string strFileName)
        {
            object fileName = FileName = strFileName;
            object isreadonly = IsReadOnly;
            object isvisible = IsVisible;
            Doc = App.Documents.Open(ref fileName, ref missing, ref isreadonly,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref isvisible, ref missing, ref missing, ref missing, ref missing);

            Doc.Activate();
        }

        // Open a new document
        public void Open()
        {
            object isvisible = IsVisible;
            this.App.Visible = IsVisible;
            this.App.Activate();
            Doc = App.Documents.Add(ref missing, ref missing, ref missing, ref isvisible);
            Doc.Activate();
        }

        public void Close()
        {
            if (Doc != null)
            {
                Doc.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Doc);
                Doc = null;
            }
            if (App != null)
            {
                App.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(App);
                App = null;
            }
            GC.Collect();
        }

        /// <summary>
        /// 附加dot模版文件
        /// </summary>
        private void LoadDotFile(string strDotFile)
        {
            if (!string.IsNullOrEmpty(strDotFile))
            {
                Microsoft.Office.Interop.Word.Document wDot = null;
                if (App != null)
                {
                    Doc = App.ActiveDocument;

                    App.Selection.WholeStory();

                    //string strContent = App.Selection.Text;

                    App.Selection.Copy();
                    wDot = CreateWordDocument(strDotFile, true);

                    object bkmC = "Content";

                    if (App.ActiveDocument.Bookmarks.Exists("Content") == true)
                    {
                        App.ActiveDocument.Bookmarks.get_Item
                        (ref bkmC).Select();
                    }

                    //对标签"Content"进行填充
                    //直接写入内容不能识别表格什么的
                    //App.Selection.TypeText(strContent);
                    App.Selection.Paste();
                    App.Selection.WholeStory();
                    App.Selection.Copy();
                    wDot.Close(ref missing, ref missing, ref missing);

                    Doc.Activate();
                    App.Selection.Paste();

                }
            }
        }

        ///  
        /// 打开Word文档,并且返回对象Doc
        /// 完整Word文件路径+名称  
        /// 返回的Word.Document Doc对象 
        public Microsoft.Office.Interop.Word.Document CreateWordDocument(string FileName, bool HideWin)
        {
            if (FileName == "") return null;

            App.Visible = HideWin;
            App.Caption = "";
            App.Options.CheckSpellingAsYouType = false;
            App.Options.CheckGrammarAsYouType = false;

            Object filename = FileName;
            Object ConfirmConversions = false;
            Object ReadOnly = true;
            Object AddToRecentFiles = false;

            Object PasswordDocument = System.Type.Missing;
            Object PasswordTemplate = System.Type.Missing;
            Object Revert = System.Type.Missing;
            Object WritePasswordDocument = System.Type.Missing;
            Object WritePasswordTemplate = System.Type.Missing;
            Object Format = System.Type.Missing;
            Object Encoding = System.Type.Missing;
            Object Visible = System.Type.Missing;
            Object OpenAndRepair = System.Type.Missing;
            Object DocumentDirection = System.Type.Missing;
            Object NoEncodingDialog = System.Type.Missing;
            Object XMLTransform = System.Type.Missing;
            try
            {
                Microsoft.Office.Interop.Word.Document wordDoc = App.Documents.Open(ref filename, ref ConfirmConversions,
                ref ReadOnly, ref AddToRecentFiles, ref PasswordDocument, ref PasswordTemplate,
                ref Revert, ref WritePasswordDocument, ref WritePasswordTemplate, ref Format,
                ref Encoding, ref Visible, ref OpenAndRepair, ref DocumentDirection,
                ref NoEncodingDialog, ref XMLTransform);
                return wordDoc;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Save()
        {
            Doc.Save();
        }

        public void SaveAs(string strFileName)
        {
            object fileName = strFileName;

            Doc.SaveAs(ref fileName, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
        }

        // Save the document in HTML format
        public void SaveAsHtml(string strFileName)
        {
            object fileName = strFileName;
            object Format = (int)Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML;
            Doc.SaveAs(ref fileName, ref Format, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
        }

        #endregion


        #region 移动光标位置

        // Go to a predefined bookmark, if the bookmark doesn't exists the application will raise an error
        public void GotoBookMark(string strBookMarkName)
        {
            // VB :  Selection.GoTo What:=wdGoToBookmark, Name:="nome"
            object Bookmark = (int)Microsoft.Office.Interop.Word.WdGoToItem.wdGoToBookmark;
            object NameBookMark = strBookMarkName;
            App.Selection.GoTo(ref Bookmark, ref missing, ref missing, ref NameBookMark);
        }

        public void GoToTheEnd()
        {
            // VB :  Selection.EndKey Unit:=wdStory
            object unit;
            unit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
            App.Selection.EndKey(ref unit, ref missing);
        }

        public void GoToLineEnd()
        {
            object unit = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            object ext = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;
            App.Selection.EndKey(ref unit, ref ext);
        }

        public void GoToTheBeginning()
        {
            // VB : Selection.HomeKey Unit:=wdStory
            object unit;
            unit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
            App.Selection.HomeKey(ref unit, ref missing);
        }

        public void GoToTheTable(int ntable)
        {
            //    Selection.GoTo What:=wdGoToTable, Which:=wdGoToFirst, Count:=1, Name:=""
            //    Selection.Find.ClearFormatting
            //    With Selection.Find
            //        .Text = ""
            //        .Replacement.Text = ""
            //        .Forward = True
            //        .Wrap = wdFindContinue
            //        .Format = False
            //        .MatchCase = False
            //        .MatchWholeWord = False
            //        .MatchWildcards = False
            //        .MatchSoundsLike = False
            //        .MatchAllWordForms = False
            //    End With

            object what;
            what = Microsoft.Office.Interop.Word.WdUnits.wdTable;
            object which;
            which = Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToFirst;
            object count;
            count = 1;
            App.Selection.GoTo(ref what, ref which, ref count, ref missing);
            App.Selection.Find.ClearFormatting();

            App.Selection.Text = "";
        }

        public void GoToRightCell()
        {
            // Selection.MoveRight Unit:=wdCell
            object direction;
            direction = Microsoft.Office.Interop.Word.WdUnits.wdCell;
            App.Selection.MoveRight(ref direction, ref missing, ref missing);
        }

        public void GoToLeftCell()
        {
            // Selection.MoveRight Unit:=wdCell
            object direction;
            direction = Microsoft.Office.Interop.Word.WdUnits.wdCell;
            App.Selection.MoveLeft(ref direction, ref missing, ref missing);
        }

        public void GoToDownCell()
        {
            // Selection.MoveRight Unit:=wdCell
            object direction;
            direction = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            App.Selection.MoveDown(ref direction, ref missing, ref missing);
        }

        public void GoToUpCell()
        {
            // Selection.MoveRight Unit:=wdCell
            object direction;
            direction = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            App.Selection.MoveUp(ref direction, ref missing, ref missing);
        }

        #endregion

        #region 插入操作

        public void InsertText(string strText)
        {
            App.Selection.TypeText(strText);
        }

        public void InsertLineBreak()
        {
            App.Selection.TypeParagraph();
        }

        /// <summary>
        /// 插入多个空行
        /// </summary>
        /// <param name="nline"></param>
        public void InsertLineBreak(int nline)
        {
            for (int i = 0; i < nline; i++)
                App.Selection.TypeParagraph();
        }

        public void InsertPagebreak()
        {
            // VB : Selection.InsertBreak Type:=wdPageBreak
            object pBreak = (int)Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
            App.Selection.InsertBreak(ref pBreak);
        }

        // 插入页码
        public void InsertPageNumber()
        {
            object wdFieldPage = Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage;
            object preserveFormatting = true;
            App.Selection.Fields.Add(App.Selection.Range, ref wdFieldPage, ref missing, ref preserveFormatting);
        }

        // 插入页码
        public void InsertPageNumber(string strAlign)
        {
            object wdFieldPage = Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage;
            object preserveFormatting = true;
            App.Selection.Fields.Add(App.Selection.Range, ref wdFieldPage, ref missing, ref preserveFormatting);
            SetAlignment(strAlign);
        }

        public void InsertImage(string strPicPath, float picWidth, float picHeight)
        {
            string FileName = strPicPath;
            object LinkToFile = false;
            object SaveWithDocument = true;
            object Anchor = App.Selection.Range;
            App.ActiveDocument.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument, ref Anchor).Select();
            App.Selection.InlineShapes[1].Width = picWidth; // 图片宽度 
            App.Selection.InlineShapes[1].Height = picHeight; // 图片高度

            // 将图片设置为四面环绕型 
            Microsoft.Office.Interop.Word.Shape s = App.Selection.InlineShapes[1].ConvertToShape();
            s.WrapFormat.Type = Microsoft.Office.Interop.Word.WdWrapType.wdWrapSquare;
        }

        public void InsertLine(float left, float top, float width, float weight, int r, int g, int b)
        {
            //SetFontColor("red");
            //SetAlignment("Center");
            object Anchor = App.Selection.Range;
            //int pLeft = 0, pTop = 0, pWidth = 0, pHeight = 0;
            //App.ActiveWindow.GetPoint(out pLeft, out pTop, out pWidth, out pHeight,missing);
            //MessageBox.Show(pLeft + "," + pTop + "," + pWidth + "," + pHeight);
            object rep = false;
            //left += App.ActiveDocument.PageSetup.LeftMargin;
            left = App.CentimetersToPoints(left);
            top = App.CentimetersToPoints(top);
            width = App.CentimetersToPoints(width);
            Microsoft.Office.Interop.Word.Shape s = App.ActiveDocument.Shapes.AddLine(0, top, width, top, ref Anchor);
            s.Line.ForeColor.RGB = RGB(r, g, b);
            s.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            s.Line.Style = Microsoft.Office.Core.MsoLineStyle.msoLineSingle;
            s.Line.Weight = weight;
        }

        #endregion

        #region 设置样式

        /// <summary>
        /// Change the paragraph alignement
        /// </summary>
        /// <param name="strType"></param>
        public void SetAlignment(string strType)
        {
            switch (strType.ToLower())
            {
                case "center":
                    App.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    break;
                case "left":
                    App.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    break;
                case "right":
                    App.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    break;
                case "justify":
                    App.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                    break;
            }

        }

        public void SetFont(string strType)
        {
            switch (strType)
            {
                case "Bold":
                    App.Selection.Font.Bold = 1;
                    break;
                case "Italic":
                    App.Selection.Font.Italic = 1;
                    break;
                case "Underlined":
                    App.Selection.Font.Subscript = 0;
                    break;
            }
        }

        public void SetFont()
        {
            App.Selection.Font.Bold = 0;
            App.Selection.Font.Italic = 0;
            App.Selection.Font.Subscript = 0;

        }

        public void SetFontName(string strType)
        {
            App.Selection.Font.Name = strType;
        }

        public void SetFontSize(float nSize)
        {
            SetFontSize(nSize, 100);
        }

        public void SetFontSize(float nSize, int scaling)
        {
            if (nSize > 0f)
                App.Selection.Font.Size = nSize;
            if (scaling > 0)
                App.Selection.Font.Scaling = scaling;
        }

        public void SetFontColor(string strFontColor)
        {
            switch (strFontColor.ToLower())
            {
                case "blue":
                    App.Selection.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorBlue;
                    break;
                case "gold":
                    App.Selection.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorGold;
                    break;
                case "gray":
                    App.Selection.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorGray875;
                    break;
                case "green":
                    App.Selection.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorGreen;
                    break;
                case "lightblue":
                    App.Selection.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorLightBlue;
                    break;
                case "orange":
                    App.Selection.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorOrange;
                    break;
                case "pink":
                    App.Selection.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorPink;
                    break;
                case "red":
                    App.Selection.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorRed;
                    break;
                case "yellow":
                    App.Selection.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorYellow;
                    break;
            }
        }

        public void SetPageNumberAlign(string strType, bool bHeader)
        {
            object alignment;
            object bFirstPage = false;
            object bF = true;
            //if (bHeader == true)
            //WordApplic.Selection.HeaderFooter.PageNumbers.ShowFirstPageNumber = bF;
            switch (strType)
            {
                case "Center":
                    alignment = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberCenter;
                    //WordApplic.Selection.HeaderFooter.PageNumbers.Add(ref alignment,ref bFirstPage);
                    //Microsoft.Office.Interop.Word.Selection objSelection = WordApplic.pSelection;
                    App.Selection.HeaderFooter.PageNumbers[1].Alignment = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberCenter;
                    break;
                case "Right":
                    alignment = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberRight;
                    App.Selection.HeaderFooter.PageNumbers[1].Alignment = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberRight;
                    break;
                case "Left":
                    alignment = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberLeft;
                    App.Selection.HeaderFooter.PageNumbers.Add(ref alignment, ref bFirstPage);
                    break;
            }
        }

        /// <summary>
        /// 设置页面为标准A4公文样式
        /// </summary>
        private void SetA4PageSetup()
        {
            App.ActiveDocument.PageSetup.TopMargin = App.CentimetersToPoints(3.7f);
            //App.ActiveDocument.PageSetup.BottomMargin = App.CentimetersToPoints(1f);
            App.ActiveDocument.PageSetup.LeftMargin = App.CentimetersToPoints(2.8f);
            App.ActiveDocument.PageSetup.RightMargin = App.CentimetersToPoints(2.6f);
            //App.ActiveDocument.PageSetup.HeaderDistance = App.CentimetersToPoints(2.5f);
            //App.ActiveDocument.PageSetup.FooterDistance = App.CentimetersToPoints(1f);
            App.ActiveDocument.PageSetup.PageWidth = App.CentimetersToPoints(21f);
            App.ActiveDocument.PageSetup.PageHeight = App.CentimetersToPoints(29.7f);
        }

        #endregion

        #region 替换

        ///<summary>
        /// 在word 中查找一个字符串直接替换所需要的文本
        /// </summary>
        /// <param name="strOldText">原文本</param>
        /// <param name="strNewText">新文本</param>
        /// <returns></returns>
        public bool Replace(string strOldText, string strNewText)
        {
            if (Doc == null)
                Doc = App.ActiveDocument;
            this.Doc.Content.Find.Text = strOldText;
            object FindText, ReplaceWith, Replace;// 
            FindText = strOldText;//要查找的文本
            ReplaceWith = strNewText;//替换文本
            Replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;/**//*wdReplaceAll - 替换找到的所有项。
                                                      * wdReplaceNone - 不替换找到的任何项。
                                                    * wdReplaceOne - 替换找到的第一项。
                                                    * */
            Doc.Content.Find.ClearFormatting();//移除Find的搜索文本和段落格式设置
            if (Doc.Content.Find.Execute(
                ref FindText, ref missing,
                ref missing, ref missing,
                ref missing, ref missing,
                ref missing, ref missing, ref missing,
                ref ReplaceWith, ref Replace,
                ref missing, ref missing,
                ref missing, ref missing))
            {
                return true;
            }
            return false;
        }

        public bool SearchReplace(string strOldText, string strNewText)
        {
            object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

            //首先清除任何现有的格式设置选项，然后设置搜索字符串 strOldText。
            App.Selection.Find.ClearFormatting();
            App.Selection.Find.Text = strOldText;

            App.Selection.Find.Replacement.ClearFormatting();
            App.Selection.Find.Replacement.Text = strNewText;

            if (App.Selection.Find.Execute(
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref replaceAll, ref missing, ref missing, ref missing, ref missing))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region 获取Sections
        public int PageCount
        {
            get { return Doc.ComputeStatistics(WdStatistic.wdStatisticPages); }
        }

        public int SectionsCount
        {
            get { return Doc.Sections.Count; }
        }

        public void SaveSection(int index, string savepath)
        {
            Doc.Sections[index].Range.Select();
            Doc.Sections[index].Range.Copy();
            Document doc = new DocumentClass();
            doc.Range().Paste();
            doc.SaveAs(savepath);
        }
        #endregion

        #region 颜色转换
        /// <summary>
        /// rgb转换函数
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        int RGB(int r, int g, int b)
        {
            return ((b << 16) | (ushort)(((ushort)g << 8) | r));
        }

        Color RGBToColor(int color)
        {
            int r = 0xFF & color;
            int g = 0xFF00 & color;
            g >>= 8;
            int b = 0xFF0000 & color;
            b >>= 16;
            return Color.FromArgb(r, g, b);
        }
        #endregion

        #region 表格操作
        /// <summary> 
        /// 向文档中插入表格 
        /// </summary> 
        /// <param name="startIndex">开始位置</param> 
        /// <param name="endIndex">结束位置</param> 
        /// <param name="rowCount">行数</param> 
        /// <param name="columnCount">列数</param> 
        /// <returns></returns> 
        public Table AppendTable(int startIndex, int endIndex, int rowCount, int columnCount)
        {
            object start = startIndex;
            object end = endIndex;
            Range tableLocation = this.Doc.Range(ref start, ref end);

            return this.Doc.Tables.Add(tableLocation, rowCount, columnCount, ref missing, ref missing);
        }
        /// <summary> 
        /// 添加行 
        /// </summary> 
        /// <param name="table"></param> 
        /// <returns></returns> 
        public Row AppendRow(Table table)
        {
            object row = table.Rows[1];
            return table.Rows.Add(ref row);
        }
        /// <summary> 
        /// 添加列 
        /// </summary> 
        /// <param name="table"></param> 
        /// <returns></returns> 
        public Column AppendColumn(Table table)
        {
            object column = table.Columns[1];
            return table.Columns.Add(ref column);
        }
        /// <summary> 
        /// 设置单元格的文本和对齐方式 
        /// </summary> 
        /// <param name="cell">单元格</param> 
        /// <param name="text">文本</param> 
        /// <param name="align">对齐方式</param> 
        public void SetCellText(Cell cell, string text, WdParagraphAlignment align)
        {
            cell.Range.Text = text;
            cell.Range.ParagraphFormat.Alignment = align;
        }

        #endregion
    }
}
