using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WSH.WinForm.Controls
{
  public   class BaseColor
    {
      /// <summary>
      /// 通用的背景色
      /// </summary>
      public static readonly  Color Background = Color.FromArgb(255, 255, 254);
      /// <summary>
      /// 通用的字体颜色
      /// </summary>
      public static readonly Color Font = Color.FromArgb(127, 127, 127);
      public static readonly Color FontRead = ColorTranslator.FromHtml("#dddddd");
      /// <summary>
      /// 按钮的字体颜色
      /// </summary>
      public static readonly Color ButtonFont = Color.FromArgb(102, 102, 102);

      /// <summary>
      /// 导航高亮的颜色
      /// </summary>
      public static readonly Color LabelHighLight= Color.FromArgb(85, 142, 213);

      /// <summary>
      /// 导航默认字体颜色
      /// </summary>
      public static readonly Color Label= Color.FromArgb(191, 191, 191);

      public static readonly Color Border= ColorTranslator.FromHtml("#cccccc");

      public static Color GridOdd = Color.FromArgb(250, 250, 250);
      public static Color GridEven = Color.FromArgb(255, 255, 255);

      public static Color GridCellBorder = ColorTranslator.FromHtml("#EDEDED");
      public static Color GridSelectedRow = ColorTranslator.FromHtml("#DFE7F9");

      public static Color GridHeaderBorder = ColorTranslator.FromHtml("#cccccc");
      public static Color GridHeaderBegin = ColorTranslator.FromHtml("#F9F9F9");
      public static Color GridHeaderEnd = ColorTranslator.FromHtml("#E3E4E6");
    }
}
