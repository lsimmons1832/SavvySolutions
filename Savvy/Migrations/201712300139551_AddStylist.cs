namespace Savvy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStylist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stylists", "Services_ServiceId", "dbo.Services");
            DropIndex("dbo.Stylists", new[] { "Services_ServiceId" });
            AddColumn("dbo.Services", "Stylist_StylistID", c => c.Int());
            CreateIndex("dbo.Services", "Stylist_StylistID");
            AddForeignKey("dbo.Services", "Stylist_StylistID", "dbo.Stylists", "StylistID");
            DropColumn("dbo.Stylists", "Services_ServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stylists", "Services_ServiceId", c => c.Int());
            DropForeignKey("dbo.Services", "Stylist_StylistID", "dbo.Stylists");
            DropIndex("dbo.Services", new[] { "Stylist_StylistID" });
            DropColumn("dbo.Services", "Stylist_StylistID");
            CreateIndex("dbo.Stylists", "Services_ServiceId");
            AddForeignKey("dbo.Stylists", "Services_ServiceId", "dbo.Services", "ServiceId");
        }
    }
}
