using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjectCinema.Models;
using ProjectCinema.Dal;

namespace ProjectCinema.Dal
{
    public class UserDal : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<demoEntities>(null);
            modelBuilder.Entity<User>().ToTable("tblUser");
            base.OnModelCreating(modelBuilder);

        }
    }
}