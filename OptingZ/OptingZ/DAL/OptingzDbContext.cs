using OptingZ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OptingZ.DAL
{
    public class OptingzDbContext : DbContext
    {
        public OptingzDbContext() : base("OptingzDbContext")
        {
            Database.SetInitializer<OptingzDbContext>(new OptingZDbInitializer());
        }


        public DbSet<ProductMaster> ProductMasters { get; set; }
        public DbSet<CategoryMaster> CategoryMasters { get; set; }
        public DbSet<SubCategoryMaster> SubCategoryMasters { get; set; }
        public DbSet<StickerMaster> StickerMasters { get; set; }
        public DbSet<ProductStickerMaster> ProductStickerMasters { get; set; }
        public DbSet<ProductCategoryMaster> ProductCategoryMasters { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<SubCategoryMaster>()
                .HasRequired(c => c.CategoryMaster)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CityMaster>()
                .HasRequired(c => c.StateMaster)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StateMaster>()
                .HasRequired(c => c.CountryMaster)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CountryMaster>()
                .HasRequired(c => c.GeoMaster)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}