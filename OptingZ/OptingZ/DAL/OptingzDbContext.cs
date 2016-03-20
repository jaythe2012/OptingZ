using Microsoft.AspNet.Identity.EntityFramework;
using OptingZ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OptingZ.DAL
{
    public class OptingzDbContext : IdentityDbContext<ApplicationUser>
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
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<UserRoleMaster> UserRoleMasters { get; set; }
        public DbSet<UserFileMaster> UserFileMasters { get; set; }
        public DbSet<UserDetailMaster> UserDetailMasters { get; set; }
        



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

         

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        

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