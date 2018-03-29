using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Manager.Models;

namespace WSH.Manager.Applications
{
    interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        void Delete(string id);
        void BatchDelete(string[] ids);
        TEntity Update(TEntity entity);
        TEntity SaveOrUpdate(TEntity entity);
        TEntity Get(string id);
        IQueryable<TEntity> FindAll();
    }
}
