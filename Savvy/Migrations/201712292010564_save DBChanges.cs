namespace Savvy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saveDBChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "Stylist_StylistID", "dbo.Stylists");
            DropIndex("dbo.Services", new[] { "Stylist_StylistID" });
            AddColumn("dbo.Stylists", "Services_ServiceId", c => c.Int());
            CreateIndex("dbo.Stylists", "Services_ServiceId");
            AddForeignKey("dbo.Stylists", "Services_ServiceId", "dbo.Services", "ServiceId");
            DropColumn("dbo.Services", "Stylist_StylistID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Stylist_StylistID", c => c.Int());
            DropForeignKey("dbo.Stylists", "Services_ServiceId", "dbo.Services");
            DropIndex("dbo.Stylists", new[] { "Services_ServiceId" });
            DropColumn("dbo.Stylists", "Services_ServiceId");
            CreateIndex("dbo.Services", "Stylist_StylistID");
            AddForeignKey("dbo.Services", "Stylist_StylistID", "dbo.Stylists", "StylistID");
        }
    }
}
