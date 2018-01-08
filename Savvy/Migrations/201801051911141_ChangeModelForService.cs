namespace Savvy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModelForService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "IsSelected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "IsSelected");
        }
    }
}
