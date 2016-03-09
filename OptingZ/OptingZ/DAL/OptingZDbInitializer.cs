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
                //Products for "Super Market's" Sub Category.
                new ProductMaster {Name = "WalMart" , SDescription = "Nice Mall" , Website = "www.walmart.ca",IsMultipleCategory = true},
                new ProductMaster {Name = "Maxi & Cie", SDescription = "Very Nice Mall" , Website = "www.maxi.com", IsMultipleCategory= false },
                new ProductMaster {Name = "IGA" , SDescription = "Expensive Mall" , Website = "www.IGA.ca",IsMultipleCategory = false},
                new ProductMaster {Name = "Canadien Tire" , SDescription = "Famous mall for house-hold stuff" , Website = "http://www.canadiantire.ca/en.html",IsMultipleCategory = false},
                new ProductMaster {Name = "Super C" , SDescription = "Very nice big grocessary store" , Website = "http://www.superc.ca/en/index.html",IsMultipleCategory = false},
                new ProductMaster {Name = "Metro" , SDescription = "" , Website = "",IsMultipleCategory = false},
                
                //Products for Website Category.
                new ProductMaster {Name = "Amazon US", SDescription = "Online MAll", Website = "www.amazon.ca", IsMultipleCategory = false },
                new ProductMaster {Name = "Ebay China" , SDescription = "Online cheap Mall" , Website = "www.ebay.ca",IsMultipleCategory = false},

                //Products for "Grocessary store" sub category
                new ProductMaster {Name = "Almizan" , SDescription = "Arabic grocessary store" , Website = "",IsMultipleCategory = false},
                new ProductMaster {Name = "Supermarche PA" , SDescription = "General grocessary store specialised for fruits" , Website = "http://www.supermarchepa.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Marche Jolee" , SDescription = "Grocessary store, bit expensive than others" , Website = "",IsMultipleCategory = false},
                new ProductMaster {Name = "Ecollegrey" , SDescription = "Grocessary store, very affordable prices" , Website = "http://www.ecollegey.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Sami Fruits" , SDescription = "General grocessary stores specialised for fruits" , Website = "",IsMultipleCategory = false},
                
                //Products for "Convenient Stores" sub category
                new ProductMaster {Name = "Beau Soir" , SDescription = "Small number of stores in the city" , Website = "",IsMultipleCategory = false},
                new ProductMaster {Name = "Couche-Tard" , SDescription = "Very nice store but little bit costly." , Website = "http://www.couche-tard.com/index.html",IsMultipleCategory = false},
                new ProductMaster {Name = "Depanneur" , SDescription = "Very good store and you can find good deal here." , Website = "http://www.ultramarcst.ca",IsMultipleCategory = false},
                new ProductMaster {Name = "Monoprix" , SDescription = "Nice store but more constly." , Website = "https://www.monoprix.fr/",IsMultipleCategory = false},
                new ProductMaster {Name = "Marché Cosmopolitain" , SDescription = "Very few number of stores." , Website = "",IsMultipleCategory = false},
                
                //Products for "Pharmacies" sub category
                new ProductMaster {Name = "Jean Coutu" , SDescription = "Big pharmacy store with very good deals available." , Website = "https://www.jeancoutu.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Pharmaprix" , SDescription = "Big pharmacy store with very good deals available." , Website = "http://www1.pharmaprix.ca/",IsMultipleCategory = false},
                new ProductMaster {Name = "Uniprix" , SDescription = "Good pharmacy store but little bit costly." , Website = "http://www.uniprix.com/en/homepage",IsMultipleCategory = false},
                new ProductMaster {Name = "Pharmacie Linda Frayne & John Genova" , SDescription = "Small pharmacy store, main important items are available." , Website = "http://www.pharmafrayne.com/",IsMultipleCategory = false},
                
                //Products for "Clothes" sub category
                new ProductMaster {Name = "Holister" , SDescription = "Famous brand, varity of cloths on average price." , Website = "http://www.hollisterco.ca",IsMultipleCategory = false},
                new ProductMaster {Name = "A & F" , SDescription = "Cloths for Men, Women and Kids. Its little bit costly." , Website = "http://www.abercrombie.ca",IsMultipleCategory = false},
                new ProductMaster {Name = "American Eagle" , SDescription = "Famous store in North america with variety of cloths availabe online and in store." , Website = "http://www.ae.com/web/canada/index.jsp",IsMultipleCategory = false},
                new ProductMaster {Name = "Simons" , SDescription = "Stores available in many cities in North America. average price clothes are available here." , Website = "http://www.simons.ca/simons/",IsMultipleCategory = false},
                new ProductMaster {Name = "Levis" , SDescription = "Famous brand for clothes. Awesome Jeans and Suits availbe in big price." , Website = "http://www.levi.ca/canada/en/default.asp",IsMultipleCategory = false},

                //Products for "Electornics" sub category
                new ProductMaster {Name = "Dell" , SDescription = "Well known company for Laptops and Copmputers." , Website = "http://www.dell.com/en-ca/",IsMultipleCategory = false},
                new ProductMaster {Name = "LG" , SDescription = "Famous brand for Mobile and Tablets." , Website = "http://www.lg.com/ca_en",IsMultipleCategory = false},
                new ProductMaster {Name = "Samsung" , SDescription = "Highly selling Mobile company in North America." , Website = "http://www.samsung.com/ca/home/",IsMultipleCategory = false},
                new ProductMaster {Name = "Nikon" , SDescription = "Mainly famous for Cameras and small stuff." , Website = "http://www.nikon.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Lenovo" , SDescription = "Known for laptops and now a days in mobiles as well." , Website = "http://www.lenovo.com/ca/en/",IsMultipleCategory = false},

                //Products for "Health Care" sub category
                new ProductMaster {Name = "Axe" , SDescription = "Best Men's Products in great prices." , Website = "http://www.axe.ca/",IsMultipleCategory = false},
                new ProductMaster {Name = "Dove" , SDescription = "Famous for various products for health care." , Website = "http://www.dove.ca/en/default.aspx",IsMultipleCategory = false},
                new ProductMaster {Name = "Aveno" , SDescription = "Fmouse for bath products." , Website = "http://www.avino.com/s/Home.asp",IsMultipleCategory = false},
                new ProductMaster {Name = "Old Spice" , SDescription = "Most famous brand for Men." , Website = "http://oldspice.com/en",IsMultipleCategory = false},
                new ProductMaster {Name = "Nevia" , SDescription = "Verity of Products for health care." , Website = "http://www.nivea.ca",IsMultipleCategory = false},

                //Products for "Social Network" sub category
                new ProductMaster {Name = "Facebook" , SDescription = "" , Website = "https://www.facebook.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Twitter" , SDescription = "" , Website = "https://twitter.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Pinterest" , SDescription = "" , Website = "https://www.pinterest.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Google" , SDescription = "" , Website = "https://plus.google.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Instagram" , SDescription = "" , Website = "https://www.instagram.com/",IsMultipleCategory = false},
            
                //Products for "E-Commerce" sub category
                new ProductMaster {Name = "Amazon" , SDescription = "" , Website = "http://www.amazon.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Ebay" , SDescription = "" , Website = "http://www.ebay.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Think Geek" , SDescription = "" , Website = "http://www.thinkgeek.com/i",IsMultipleCategory = false},
                new ProductMaster {Name = "Ali Express" , SDescription = "" , Website = "http://www.aliexpress.com/",IsMultipleCategory = false},

                //Products for "Financial/Banks" sub category
                new ProductMaster {Name = "TD" , SDescription = "" , Website = "https://www.tdcanadatrust.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Scotia Bank" , SDescription = "" , Website = "http://www.scotiabank.com",IsMultipleCategory = false},
                new ProductMaster {Name = "RBC" , SDescription = "" , Website = "http://www.rbcroyalbank.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "BMO" , SDescription = "" , Website = "https://www.bmo.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "CIBC" , SDescription = "" , Website = "https://www.cibc.com",IsMultipleCategory = false},

                //Products for "Job Hunting" sub category
                new ProductMaster {Name = "Monster" , SDescription = "" , Website = "www.monster.ca",IsMultipleCategory = false},
                new ProductMaster {Name = "LinkedIn" , SDescription = "" , Website = "linkedin.com",IsMultipleCategory = false},
                new ProductMaster {Name = "Indeed" , SDescription = "" , Website = "ca.indeed.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Wokopolis" , SDescription = "" , Website = "www.workopolis.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Job Bank" , SDescription = "" , Website = "www.jobbank.gc.ca/",IsMultipleCategory = false},

                //Products for "Video Streaming" sub category
                new ProductMaster {Name = "" , SDescription = "" , Website = "",IsMultipleCategory = false},
                new ProductMaster {Name = "" , SDescription = "" , Website = "",IsMultipleCategory = false},
                new ProductMaster {Name = "" , SDescription = "" , Website = "",IsMultipleCategory = false},
                new ProductMaster {Name = "" , SDescription = "" , Website = "",IsMultipleCategory = false},
                new ProductMaster {Name = "" , SDescription = "" , Website = "",IsMultipleCategory = false},

                //Products for "Secutiry Software" sub category
                new ProductMaster {Name = "Avira" , SDescription = "" , Website = "https://www.avira.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Ad-Aware" , SDescription = "" , Website = "http://lavasoft.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Avast" , SDescription = "" , Website = "https://www.avast.com/index",IsMultipleCategory = false},
                new ProductMaster {Name = "Karspersky" , SDescription = "" , Website = "http://www.kaspersky.ca/",IsMultipleCategory = false},
                new ProductMaster {Name = "AVG" , SDescription = "" , Website = "http://www.avg.com/",IsMultipleCategory = false},

                //Products for "Productive Tools" sub category
                new ProductMaster {Name = "Jira" , SDescription = "" , Website = "",IsMultipleCategory = false},
                new ProductMaster {Name = "Evernote" , SDescription = "Free edition for everyone" , Website = "https://evernote.com/?var=1",IsMultipleCategory = false},
                new ProductMaster {Name = "ODesk" , SDescription = "Busineess helper." , Website = "https://www.upwork.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Freed Camp" , SDescription = "This tool is for everyone with many features." , Website = "https://freedcamp.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Pocket" , SDescription = "Famous application in North America." , Website = "https://getpocket.com/",IsMultipleCategory = false},

                //Products for "Developement Tools" sub category
                new ProductMaster {Name = "Eclipse" , SDescription = "Open source tools for Java based applications." , Website = "https://netbeans.org/",IsMultipleCategory = false},
                new ProductMaster {Name = "Netbeans" , SDescription = "IDE for Java and Php applications." , Website = "http://www.eclipse.org/",IsMultipleCategory = false},
                new ProductMaster {Name = "Visual Studio" , SDescription = "IDE for .net applications." , Website = "https://www.visualstudio.com",IsMultipleCategory = false},
                new ProductMaster {Name = "Komodo Edit" , SDescription = "IDE for open source Extension developement." , Website = "http://komodoide.com/komodo-edit/",IsMultipleCategory = false},
                new ProductMaster {Name = "Code::Blocks" , SDescription = "I even dont know what it is." , Website = "http://codeblocks.org/",IsMultipleCategory = false},

                //Products for "Communication Tools" sub category
                new ProductMaster {Name = "Skype" , SDescription = "Famous for business." , Website = "https://slack.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Slake" , SDescription = "New start up and famous for developer." , Website = "http://www.skype.com/en/",IsMultipleCategory = false},
                new ProductMaster {Name = "HipChat" , SDescription = "New Start up." , Website = "https://www.hipchat.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Discord" , SDescription = "NOt as good as skype." , Website = "https://discordapp.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Glip" , SDescription = "Mainly famous in North America." , Website = "https://glip.com/",IsMultipleCategory = false},

                //Products for "Games" sub category
                new ProductMaster {Name = "Call of Duty" , SDescription = "Action game." , Website = "https://www.callofduty.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "FIFA" , SDescription = "Soccer game." , Website = "http://www.fifa.com/",IsMultipleCategory = false},
                new ProductMaster {Name = "Counter Strike" , SDescription = "Best action team game." , Website = "http://blog.counter-strike.net/",IsMultipleCategory = false},
                new ProductMaster {Name = "Splace Invaders" , SDescription = "New Game" , Website = "http://www.space-invaders.com/home/",IsMultipleCategory = false},
                new ProductMaster {Name = "Spidare Solitare" , SDescription = "Card Game" , Website = "http://www.free-spider-solitaire.com/",IsMultipleCategory = false}
            };
            products.ForEach(p => context.ProductMasters.Add(p));
            context.SaveChanges();

            //Forget about the sticker's entry for now. we will create some sort of UI for this.
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
                //SuperMarket
               	new ProductCategoryMaster { ProductMasterID = 1, CategoryMasterID = 3, SubCategoryMasterID = 11 },
                new ProductCategoryMaster { ProductMasterID = 2, CategoryMasterID = 3, SubCategoryMasterID = 11 },
                new ProductCategoryMaster { ProductMasterID = 3, CategoryMasterID = 3, SubCategoryMasterID = 11 },
                new ProductCategoryMaster { ProductMasterID = 4, CategoryMasterID = 3, SubCategoryMasterID = 11 },
                new ProductCategoryMaster { ProductMasterID = 5, CategoryMasterID = 3, SubCategoryMasterID = 11 },
                new ProductCategoryMaster { ProductMasterID = 6, CategoryMasterID = 3, SubCategoryMasterID = 11 },
                
                //Grocery Stores
                new ProductCategoryMaster { ProductMasterID = 9, CategoryMasterID = 3, SubCategoryMasterID = 12 },
                new ProductCategoryMaster { ProductMasterID = 10, CategoryMasterID = 3, SubCategoryMasterID = 12 },
                new ProductCategoryMaster { ProductMasterID = 11, CategoryMasterID = 3, SubCategoryMasterID = 12 },
                new ProductCategoryMaster { ProductMasterID = 12, CategoryMasterID = 3, SubCategoryMasterID = 12 },
                new ProductCategoryMaster { ProductMasterID = 13, CategoryMasterID = 3, SubCategoryMasterID = 12 },
                
                //Convenience Stores
                new ProductCategoryMaster { ProductMasterID = 14, CategoryMasterID = 3, SubCategoryMasterID = 13 },
                new ProductCategoryMaster { ProductMasterID = 15, CategoryMasterID = 3, SubCategoryMasterID = 13 },
                new ProductCategoryMaster { ProductMasterID = 16, CategoryMasterID = 3, SubCategoryMasterID = 13 },
                new ProductCategoryMaster { ProductMasterID = 17, CategoryMasterID = 3, SubCategoryMasterID = 13 },
                new ProductCategoryMaster { ProductMasterID = 18, CategoryMasterID = 3, SubCategoryMasterID = 13 },
                
                //Pharmacies
                new ProductCategoryMaster { ProductMasterID = 19, CategoryMasterID = 3, SubCategoryMasterID = 14 },
                new ProductCategoryMaster { ProductMasterID = 20, CategoryMasterID = 3, SubCategoryMasterID = 14 },
                new ProductCategoryMaster { ProductMasterID = 21, CategoryMasterID = 3, SubCategoryMasterID = 14 },
                new ProductCategoryMaster { ProductMasterID = 22, CategoryMasterID = 3, SubCategoryMasterID = 14 },
				
                //Clothes
                new ProductCategoryMaster { ProductMasterID = 23, CategoryMasterID = 4, SubCategoryMasterID = 15 },
                new ProductCategoryMaster { ProductMasterID = 24, CategoryMasterID = 4, SubCategoryMasterID = 15 },
                new ProductCategoryMaster { ProductMasterID = 25, CategoryMasterID = 4, SubCategoryMasterID = 15 },
                new ProductCategoryMaster { ProductMasterID = 26, CategoryMasterID = 4, SubCategoryMasterID = 15 },
                new ProductCategoryMaster { ProductMasterID = 27, CategoryMasterID = 4, SubCategoryMasterID = 15 },
                
                //Electronics
                new ProductCategoryMaster { ProductMasterID = 28, CategoryMasterID = 4, SubCategoryMasterID = 16 },
                new ProductCategoryMaster { ProductMasterID = 29, CategoryMasterID = 4, SubCategoryMasterID = 16 },
                new ProductCategoryMaster { ProductMasterID = 30, CategoryMasterID = 4, SubCategoryMasterID = 16 },
                new ProductCategoryMaster { ProductMasterID = 31, CategoryMasterID = 4, SubCategoryMasterID = 16 },
                new ProductCategoryMaster { ProductMasterID = 32, CategoryMasterID = 4, SubCategoryMasterID = 16},

                //Health Care
                new ProductCategoryMaster { ProductMasterID = 33, CategoryMasterID = 4, SubCategoryMasterID = 17 },
                new ProductCategoryMaster { ProductMasterID = 34, CategoryMasterID = 4, SubCategoryMasterID = 17 },
                new ProductCategoryMaster { ProductMasterID = 35, CategoryMasterID = 4, SubCategoryMasterID = 17 },
                new ProductCategoryMaster { ProductMasterID = 36, CategoryMasterID = 4, SubCategoryMasterID = 17 },
                new ProductCategoryMaster { ProductMasterID = 37, CategoryMasterID = 4, SubCategoryMasterID = 17 }
            };

            productcategories.ForEach(p => context.ProductCategoryMasters.Add(p));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}