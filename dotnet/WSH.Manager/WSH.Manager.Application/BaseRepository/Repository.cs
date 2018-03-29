using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data;
using WSH.Manager.Models;
using WSH.Web.Mvc.Common;

namespace WSH.Manager.Applications
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class,IEntity
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly DbContext DbContext;
        public Repository(DbContext context){
            DbContext=context;
            DbSet = context.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            TEntity t= DbSet.Add(entity);
            Save();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                DbSet.Remove(entity);
                Save();
            }
        }
        public void Delete(string id)
        {
            TEntity entity = Get(id);
            Delete(entity);
        }
        public void BatchDelete(string[] ids) {
            if (ids != null && ids.Length > 0)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    TEntity entity = Get(ids[i]);
                    if(entity!=null){
                        DbSet.Remove(entity);
                    }
                }
                Save();
            }
        }

        public TEntity Update(TEntity entity)
        {
            var entry = DbContext.Entry<TEntity>(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            Save();
            return entity;
        }
        public TEntity SaveOrUpdate(TEntity entity)
        {
            if (entity != null)
            {
                if (!string.IsNullOrWhiteSpace(entity.Id))
                {
                    return Update(entity);
                }
                return Add(entity);
            }
            return entity;
        }
        public TEntity Get(string id)
        {
            return DbSet.Where(o => o.Id== id).FirstOrDefault();
        }
         
        public IQueryable<TEntity> FindAll()
        {
            return DbSet.AsQueryable();
        }
         
        public void Save() {
            DbContext.SaveChanges();
        }
    }
}
