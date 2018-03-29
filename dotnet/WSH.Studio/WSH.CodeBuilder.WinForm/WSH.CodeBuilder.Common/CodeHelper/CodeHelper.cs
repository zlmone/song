using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.Common
{
    public enum ControlType
    {
        Song,
        Mvc,
        EasyUI,
        AspNet
    }
    public class CodeHelper
    {
        #region 常用方法
        /// <summary>
        /// 判断是否为主键
        /// </summary>
        /// <param name="table"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static bool IsDataKey(TableEntity table, string field)
        {
            return table.DataKey.ToLower() == field.ToLower();
        }
        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string GetDataKey(TableEntity table)
        {
            return string.IsNullOrEmpty(table.DataKey) ? "ID" : table.DataKey;
        }
        /// <summary>
        /// 移除前缀
        /// </summary>
        public static string RemovePrefix(string str,string split="_")
        {
            string[] strs = str.Split(split.ToCharArray());
            if (strs.Length > 1)
            {
                List<string> lis = new List<string>();
                for (int i = 1; i < strs.Length; i++)
                {
                    lis.Add(strs[i]);
                }
                return string.Join(split, lis.ToArray());
            }
            return str;
        }
        #endregion

        #region 过滤可用的列
        public static IList<ColumnEntity> FilterColumns(IList<ColumnEntity> columns, bool isQuery)
        {
            List<ColumnEntity> list = new List<ColumnEntity>();
            foreach (ColumnEntity entity in columns)
            {
                if (entity.Hidden || !entity.Enabled)
                {
                    continue;
                }
                if (isQuery)
                {
                    if (entity.Queryable)
                    {
                        list.Add(entity);
                    }
                }
                else
                {
                    list.Add(entity);
                }
            }
            return list;
        }
        #endregion

        #region 根据控件类型获取对应的控件
        public static string GetControlByType(ColumnEntity col, ControlType type, bool isQuery)
        {
            switch (type)
            {
                case ControlType.Song:
                    return CodeControlType.GetSongControl(col);
                case ControlType.EasyUI:
                    return CodeControlType.GetEasyUIControl(col, isQuery);
                case ControlType.AspNet:
                    return CodeControlType.GetAspNetControl(col);
                case ControlType.Mvc:
                    return CodeControlType.GetMvcControl(col);
            }
            return CodeControlType.GetEasyUIControl(col, isQuery);
        }
        public static string GetColumnByType(ColumnEntity col, ControlType type)
        {
            switch (type)
            {
                case ControlType.Song:
                    return CodeColumnType.GetSongColumn(col);
                case ControlType.EasyUI:
                    return CodeColumnType.GetEasyUIColumn(col);
                case ControlType.AspNet:
                    return CodeColumnType.GetAspNetColumn(col);
            }
            return CodeColumnType.GetEasyUIColumn(col);
        }
        #endregion
 
    }
}
