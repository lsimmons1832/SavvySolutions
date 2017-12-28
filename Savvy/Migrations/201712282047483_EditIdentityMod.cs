namespace Savvy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditIdentityMod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserRoles", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserRoles");
        }
    }
}
