using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using WSH.Manager.Models;
using WSH.Manager.Models.Admin;

namespace WSH.Manager.Applications 
{
    public class ManagerContext : DbContext
    {
        public ManagerContext() : base() { 
            
        }


        public DbSet<UrlsEntity> Urls { get; set; }


        public DbSet<DictEntity> Dicts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<Author>().ToTable("Author");
        }
    }
}
