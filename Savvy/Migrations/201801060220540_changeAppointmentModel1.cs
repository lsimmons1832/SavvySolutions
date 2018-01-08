namespace Savvy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAppointmentModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Service_ServiceId", c => c.Int());
            CreateIndex("dbo.Appointments", "Service_ServiceId");
            AddForeignKey("dbo.Appointments", "Service_ServiceId", "dbo.Services", "ServiceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Service_ServiceId", "dbo.Services");
            DropIndex("dbo.Appointments", new[] { "Service_ServiceId" });
            DropColumn("dbo.Appointments", "Service_ServiceId");
        }
    }
}
