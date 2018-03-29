using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.DataAccess.SongData.Model
{
    public class Entity<T> : IEntity<T>
    {
        public T ID
        {
            get;
            set;
        }
    }
    public class Entity : IEntity
    {
        public int? ID
        {
            get;
            set;
        }
    }

}
