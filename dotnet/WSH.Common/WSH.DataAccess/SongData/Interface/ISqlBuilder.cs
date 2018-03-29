using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.DataAccess.SongData
{
    public interface ISqlBuilder
    {
        /// <summary>
        /// 查询单条记录
        /// </summary>
        ISqlInfo ToEntity();
        /// <summary>
        /// 查询多条记录
        /// </summary>
        /// <param name="top">限制显示的数量</param>
        /// <param name="isDistinct">返回当前条件下非重复数据</param>
        /// <param name="isRand">返回当前条件下随机的数据</param>
        ISqlInfo ToList(int top = 0, bool isDistinct = false);
        /// <summary>
        /// 查询多条记录
        /// </summary>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="pageIndex">分页索引</param>
        /// <param name="isDistinct">返回当前条件下非重复数据</param>
        ISqlInfo ToPagedList(int pageSize, int pageIndex, bool isDistinct = false);
        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="isDistinct">返回当前条件下非重复数据</param>
        ISqlInfo Count(bool isDistinct = false);
        /// <summary>
        /// 累计和
        /// </summary>
        ISqlInfo Sum();
        /// <summary>
        /// 查询最大数
        /// </summary>
        ISqlInfo Max();
        /// <summary>
        /// 查询最小数
        /// </summary>
        ISqlInfo Min();
        /// <summary>
        /// 查询单个值
        /// </summary>
        ISqlInfo GetSingleValue();
        /// <summary>
        /// 删除
        /// </summary>
        ISqlInfo Delete();
        /// <summary>
        /// 插入
        /// </summary>
        ISqlInfo Insert();
        /// <summary>
        /// 插入，并返回标识
        /// </summary>
        ISqlInfo InsertIdentity();
        /// <summary>
        /// 修改
        /// </summary>
        ISqlInfo Update();
    }
}
