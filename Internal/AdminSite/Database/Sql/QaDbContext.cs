using QA.Core.Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace AdminSite.Database.Sql
{
    public class QaDbContext : DbContext
    {
        public QaDbContext() : base()
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var conventions = modelBuilder.Conventions;
            var configurations = modelBuilder.Configurations;
            base.OnModelCreating(modelBuilder);
        }

        //collection is null error change to something else?
        public DbSet<User> Users { get; set; }
        public DbSet<AthleteAccount> AthleteAccounts {get;set;}
    }
}