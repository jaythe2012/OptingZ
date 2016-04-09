namespace OptingZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductCategoryMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductMasterID = c.Int(nullable: false),
                        CategoryMasterID = c.Int(nullable: false),
                        SubCategoryMasterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CategoryMaster", t => t.CategoryMasterID, cascadeDelete: true)
                .ForeignKey("dbo.ProductMaster", t => t.ProductMasterID, cascadeDelete: true)
                .ForeignKey("dbo.SubCategoryMaster", t => t.SubCategoryMasterID, cascadeDelete: true)
                .Index(t => t.ProductMasterID)
                .Index(t => t.CategoryMasterID)
                .Index(t => t.SubCategoryMasterID);
            
            CreateTable(
                "dbo.ProductMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SDescription = c.String(),
                        IsMultipleCategory = c.Boolean(nullable: false),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductLocationMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductMasterID = c.Int(nullable: false),
                        GeoMasterID = c.Int(nullable: false),
                        CountryMasterID = c.Int(nullable: false),
                        StateMasterID = c.Int(nullable: false),
                        CityMasterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CityMaster", t => t.CityMasterID, cascadeDelete: true)
                .ForeignKey("dbo.CountryMaster", t => t.CountryMasterID, cascadeDelete: true)
                .ForeignKey("dbo.GeoMaster", t => t.GeoMasterID, cascadeDelete: true)
                .ForeignKey("dbo.ProductMaster", t => t.ProductMasterID, cascadeDelete: true)
                .ForeignKey("dbo.StateMaster", t => t.StateMasterID, cascadeDelete: true)
                .Index(t => t.ProductMasterID)
                .Index(t => t.GeoMasterID)
                .Index(t => t.CountryMasterID)
                .Index(t => t.StateMasterID)
                .Index(t => t.CityMasterID);
            
            CreateTable(
                "dbo.CityMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StateMasterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StateMaster", t => t.StateMasterID)
                .Index(t => t.StateMasterID);
            
            CreateTable(
                "dbo.StateMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryMasterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CountryMaster", t => t.CountryMasterID)
                .Index(t => t.CountryMasterID);
            
            CreateTable(
                "dbo.CountryMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GeoMasterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GeoMaster", t => t.GeoMasterID)
                .Index(t => t.GeoMasterID);
            
            CreateTable(
                "dbo.GeoMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductStickerMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductMasterID = c.Int(nullable: false),
                        StickerMasterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductMaster", t => t.ProductMasterID, cascadeDelete: true)
                .ForeignKey("dbo.StickerMaster", t => t.StickerMasterID, cascadeDelete: true)
                .Index(t => t.ProductMasterID)
                .Index(t => t.StickerMasterID);
            
            CreateTable(
                "dbo.StickerMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubCategoryMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryMasterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CategoryMaster", t => t.CategoryMasterID)
                .Index(t => t.CategoryMasterID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserDetailMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserMasterID = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Sex = c.String(),
                        PhoneNumber = c.String(),
                        IsSubscribedByEmail = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserFileMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        UserMasterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        UserRoleMasterID = c.Int(nullable: false),
                        UserDetailMaster_ID = c.Int(),
                        UserFiles_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserDetailMaster", t => t.UserDetailMaster_ID)
                .ForeignKey("dbo.UserFileMaster", t => t.UserFiles_ID)
                .ForeignKey("dbo.UserRoleMaster", t => t.UserRoleMasterID, cascadeDelete: true)
                .Index(t => t.UserRoleMasterID)
                .Index(t => t.UserDetailMaster_ID)
                .Index(t => t.UserFiles_ID);
            
            CreateTable(
                "dbo.UserRoleMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.UserMaster", "UserRoleMasterID", "dbo.UserRoleMaster");
            DropForeignKey("dbo.UserMaster", "UserFiles_ID", "dbo.UserFileMaster");
            DropForeignKey("dbo.UserMaster", "UserDetailMaster_ID", "dbo.UserDetailMaster");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ProductCategoryMaster", "SubCategoryMasterID", "dbo.SubCategoryMaster");
            DropForeignKey("dbo.SubCategoryMaster", "CategoryMasterID", "dbo.CategoryMaster");
            DropForeignKey("dbo.ProductCategoryMaster", "ProductMasterID", "dbo.ProductMaster");
            DropForeignKey("dbo.ProductStickerMaster", "StickerMasterID", "dbo.StickerMaster");
            DropForeignKey("dbo.ProductStickerMaster", "ProductMasterID", "dbo.ProductMaster");
            DropForeignKey("dbo.ProductLocationMaster", "StateMasterID", "dbo.StateMaster");
            DropForeignKey("dbo.ProductLocationMaster", "ProductMasterID", "dbo.ProductMaster");
            DropForeignKey("dbo.ProductLocationMaster", "GeoMasterID", "dbo.GeoMaster");
            DropForeignKey("dbo.ProductLocationMaster", "CountryMasterID", "dbo.CountryMaster");
            DropForeignKey("dbo.ProductLocationMaster", "CityMasterID", "dbo.CityMaster");
            DropForeignKey("dbo.CityMaster", "StateMasterID", "dbo.StateMaster");
            DropForeignKey("dbo.StateMaster", "CountryMasterID", "dbo.CountryMaster");
            DropForeignKey("dbo.CountryMaster", "GeoMasterID", "dbo.GeoMaster");
            DropForeignKey("dbo.ProductCategoryMaster", "CategoryMasterID", "dbo.CategoryMaster");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserMaster", new[] { "UserFiles_ID" });
            DropIndex("dbo.UserMaster", new[] { "UserDetailMaster_ID" });
            DropIndex("dbo.UserMaster", new[] { "UserRoleMasterID" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.SubCategoryMaster", new[] { "CategoryMasterID" });
            DropIndex("dbo.ProductStickerMaster", new[] { "StickerMasterID" });
            DropIndex("dbo.ProductStickerMaster", new[] { "ProductMasterID" });
            DropIndex("dbo.CountryMaster", new[] { "GeoMasterID" });
            DropIndex("dbo.StateMaster", new[] { "CountryMasterID" });
            DropIndex("dbo.CityMaster", new[] { "StateMasterID" });
            DropIndex("dbo.ProductLocationMaster", new[] { "CityMasterID" });
            DropIndex("dbo.ProductLocationMaster", new[] { "StateMasterID" });
            DropIndex("dbo.ProductLocationMaster", new[] { "CountryMasterID" });
            DropIndex("dbo.ProductLocationMaster", new[] { "GeoMasterID" });
            DropIndex("dbo.ProductLocationMaster", new[] { "ProductMasterID" });
            DropIndex("dbo.ProductCategoryMaster", new[] { "SubCategoryMasterID" });
            DropIndex("dbo.ProductCategoryMaster", new[] { "CategoryMasterID" });
            DropIndex("dbo.ProductCategoryMaster", new[] { "ProductMasterID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.UserRoleMaster");
            DropTable("dbo.UserMaster");
            DropTable("dbo.UserFileMaster");
            DropTable("dbo.UserDetailMaster");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.SubCategoryMaster");
            DropTable("dbo.StickerMaster");
            DropTable("dbo.ProductStickerMaster");
            DropTable("dbo.GeoMaster");
            DropTable("dbo.CountryMaster");
            DropTable("dbo.StateMaster");
            DropTable("dbo.CityMaster");
            DropTable("dbo.ProductLocationMaster");
            DropTable("dbo.ProductMaster");
            DropTable("dbo.ProductCategoryMaster");
            DropTable("dbo.CategoryMaster");
        }
    }
}
