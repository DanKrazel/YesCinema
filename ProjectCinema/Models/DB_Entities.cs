using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace ProjectCinema.Models
{
    public class DB_Entities : DbContext
    {
        public DB_Entities() : base("Movie") { }
        public DbSet <REGISTER> Users { get; set; }
        public DbSet<MOVIE> MOVIES { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<demoEntities>(null);
            modelBuilder.Entity<REGISTER>().ToTable("REGISTER");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<MOVIE>().ToTable("MOVIES");
        //    modelBuilder.Entity<Movie>().HasKey(e => e.ID);
            base.OnModelCreating(modelBuilder);

        }
    }
}