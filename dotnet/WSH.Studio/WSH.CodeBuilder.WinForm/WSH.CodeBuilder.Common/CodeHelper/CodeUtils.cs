using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.CodeBuilder.Common
{
    public class CodeUtils
    {
        public static string Tab = "\t";
        public static string Line = "\r\n";
        #region 计算属性
        /// <summary>
        /// 获取表格布局共多少行
        /// </summary>
        /// <param name="count"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static int GetRowCount(int count, int col)
        {
            int row = count % col == 0 ? count / col : (count / col) + 1;
            return row;
        }
        /// <summary>
        /// 获取div布局共多少行
        /// </summary>
        /// <param name="count"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static int GetLineCount(int count, int col)
        {
            int row = count % col == 0 ? count / col : (count / col) + 1;
            return row;
        }
        /// <summary>
        /// 获取生成的代码的Tab数
        /// </summary>
        /// <param name="tabCount"></param>
        /// <returns></returns>
        public static string GetTab(int tabCount)
        {
            string tab = "";
            for (int i = 0; i < tabCount; i++)
            {
                tab += Tab;
            }
            return tab;
        }
        public static string GetNextTab(string tab, int nextTabCount = 1)
        {
            return tab + GetTab(nextTabCount);
        }
        #endregion
    }
}
