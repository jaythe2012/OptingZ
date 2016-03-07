using System;
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
                new CategoryMaster { Name = "Websites" },
                new CategoryMaster { Name = "Softwares" },
                new CategoryMaster {Name = "Stores" },
                new CategoryMaster { Name = "Brands" }
            };

            categories.ForEach(c => context.CategoryMasters.Add(c));
            context.SaveChanges();

            var subcategories = new List<SubCategoryMaster>
            {
                new SubCategoryMaster {Name= "Social Networking", CategoryMasterID= 1 },
                new SubCategoryMaster {Name = "E-Commerce", CategoryMasterID = 1 },
                new SubCategoryMaster {Name= "Financial/Banks", CategoryMasterID= 1 },
                new SubCategoryMaster {Name = "Job Hunting", CategoryMasterID = 1 },
                new SubCategoryMaster {Name= "Video Streaming", CategoryMasterID= 1 },
                
                new SubCategoryMaster {Name = "Security Software", CategoryMasterID = 2 },               
                new SubCategoryMaster {Name = "Productivity Tools", CategoryMasterID = 2 },
                new SubCategoryMaster {Name = "Developement Tools", CategoryMasterID = 2 },
                new SubCategoryMaster {Name = "Communication Tools", CategoryMasterID = 2 },
                new SubCategoryMaster {Name = "Games", CategoryMasterID = 2 },
                
                new SubCategoryMaster {Name = "Super Market", CategoryMasterID = 3 },
                new SubCategoryMaster {Name = "Grocery Stores", CategoryMasterID = 3 },
                new SubCategoryMaster {Name = "Convenient Stores", CategoryMasterID = 3 },
                new SubCategoryMaster {Name = "Pharmacies", CategoryMasterID = 3 },

                new SubCategoryMaster {Name = "Clothes", CategoryMasterID = 4 },               
                new SubCategoryMaster {Name = "Electronics", CategoryMasterID = 4 },
                new SubCategoryMaster {Name = "Health Care", CategoryMasterID = 4 }
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
                new ProductMaster {Name = "Amazon", SDescription = "Online MAll", Website = "www.amazon.ca", IsMultipleCategory = false },
                new ProductMaster {Name = "Ebay" , SDescription = "Online cheap Mall" , Website = "www.ebay.ca",IsMultipleCategory = false},
                new ProductMaster {Name = "IGA" , SDescription = "Expensive Mall" , Website = "www.IGA.ca",IsMultipleCategory = false}
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
                new ProductCategoryMaster {ProductMasterID = 2, CategoryMasterID = 1, SubCategoryMasterID = 2 },
                new ProductCategoryMaster { ProductMasterID = 3, CategoryMasterID = 2, SubCategoryMasterID = 3 },
                new ProductCategoryMaster { ProductMasterID = 4, CategoryMasterID = 2, SubCategoryMasterID = 3 },
                new ProductCategoryMaster { ProductMasterID = 5, CategoryMasterID = 1, SubCategoryMasterID = 2 }


            };

            productcategories.ForEach(p => context.ProductCategoryMasters.Add(p));
            context.SaveChanges();
            base.Seed(context);

        }
    }
}