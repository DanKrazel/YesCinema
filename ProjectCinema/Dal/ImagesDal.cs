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
    public class ImagesDal : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ImageModel>().ToTable("tblImages");
        }

        public DbSet<ImageModel> Images { get; set; }
    }
}