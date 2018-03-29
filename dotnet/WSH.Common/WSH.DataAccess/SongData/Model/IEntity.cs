using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.DataAccess.SongData.Model
{
    public interface IEntity<T>
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        T ID { get; set; }
    }
    public interface IEntity : IEntity<int?> { }
}
