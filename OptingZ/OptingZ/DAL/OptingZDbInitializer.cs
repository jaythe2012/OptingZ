﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OptingZ.Models;

namespace OptingZ.DAL
{
    public class OptingZDbInitializer : DropCreateDatabaseIfModelChanges<OptingzDbContext>
    {
        protected override void Seed(OptingzDbContext context)
        {
            var categories = new List<CategoryMaster>
            {
                new CategoryMaster {Name = "Store" },
                new CategoryMaster { Name = "Online" }
            };

            categories.ForEach(c => context.CategoryMasters.Add(c));
            context.SaveChanges();

            var subcategories = new List<SubCategoryMaster>
            {
                new SubCategoryMaster {Name= "Super Mall", CategoryMasterID=1 },
                new SubCategoryMaster {Name = "Mini Mall", CategoryMasterID = 1 },
                new SubCategoryMaster {Name = "Virtual Mall", CategoryMasterID = 2 }
            };

            subcategories.ForEach(s => context.SubCategoryMasters.Add(s));
            context.SaveChanges();

            var stickers = new List<StickerMaster>
            {
                new StickerMaster {Name = "Groceries" },
                new StickerMaster {Name = "Electronics" }
            };

            stickers.ForEach(s => context.StickerMasters.Add(s));
            context.SaveChanges();

            var products = new List<ProductMaster>
            {
                new ProductMaster {Name = "WalMart" , SDescription = "Nice Mall" , Website = "www.walmart.ca",IsMultipleCategory = true},
                new ProductMaster {Name = "Maxi & Cie", SDescription = "Very Nice Mall" , Website = "www.maxi.com", IsMultipleCategory= false },
                new ProductMaster {Name = "Amazon", SDescription = "Online MAll", Website = "www.amazon.ca", IsMultipleCategory = false }
            };
            products.ForEach(p => context.ProductMasters.Add(p));
            context.SaveChanges();

            var productstickers = new List<ProductStickerMaster>
            {
                new ProductStickerMaster { ProductMasterID = 1, StickerMasterID = 1},
                new ProductStickerMaster { ProductMasterID = 1, StickerMasterID= 2 },
                new ProductStickerMaster { ProductMasterID = 2, StickerMasterID = 1},
                new ProductStickerMaster { ProductMasterID = 3, StickerMasterID= 2 }
            };
            productstickers.ForEach(p => context.ProductStickerMasters.Add(p));
            context.SaveChanges();


            var productcategories = new List<ProductCategoryMaster>
            {
                new ProductCategoryMaster {ProductMasterID = 1, CategoryMasterID = 1 , SubCategoryMasterID =1, },
                new ProductCategoryMaster {ProductMasterID = 1, CategoryMasterID = 2, SubCategoryMasterID =1 },
                new ProductCategoryMaster {ProductMasterID = 2, CategoryMasterID = 1, SubCategoryMasterID = 2 },
                new ProductCategoryMaster { ProductMasterID = 3, CategoryMasterID = 2, SubCategoryMasterID = 3 }
            };

            productcategories.ForEach(p => context.ProductCategoryMasters.Add(p));
            context.SaveChanges();
            base.Seed(context);
            
        }
    }
}