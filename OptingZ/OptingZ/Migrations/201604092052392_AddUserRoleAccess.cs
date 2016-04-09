namespace OptingZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserRoleAccess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRoleMaster", "Access", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRoleMaster", "Access");
        }
    }
}
