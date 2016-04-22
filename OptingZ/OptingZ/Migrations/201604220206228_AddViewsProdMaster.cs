namespace OptingZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewsProdMaster : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductMaster", "Views", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductMaster", "Views");
        }
    }
}
