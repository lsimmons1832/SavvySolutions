namespace Savvy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodelforStylist : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Stylists", new[] { "Services_ServiceId" });
            RenameColumn(table: "dbo.Services", name: "Services_ServiceId", newName: "Stylist_StylistID");
            CreateIndex("dbo.Services", "Stylist_StylistID");
            DropColumn("dbo.Stylists", "Services_ServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stylists", "Services_ServiceId", c => c.Int());
            DropIndex("dbo.Services", new[] { "Stylist_StylistID" });
            RenameColumn(table: "dbo.Services", name: "Stylist_StylistID", newName: "Services_ServiceId");
            CreateIndex("dbo.Stylists", "Services_ServiceId");
        }
    }
}
