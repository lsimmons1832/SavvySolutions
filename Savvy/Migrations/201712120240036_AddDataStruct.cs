namespace Savvy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataStruct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        Customer_CustomerID = c.Int(),
                        Schedule_ScheduleId = c.Int(),
                        Service_ServiceId = c.Int(),
                        Stylist_StylistID = c.Int(),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleId)
                .ForeignKey("dbo.Services", t => t.Service_ServiceId)
                .ForeignKey("dbo.Stylists", t => t.Stylist_StylistID)
                .Index(t => t.Customer_CustomerID)
                .Index(t => t.Schedule_ScheduleId)
                .Index(t => t.Service_ServiceId)
                .Index(t => t.Stylist_StylistID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Stylist_StylistID = c.Int(),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Stylists", t => t.Stylist_StylistID)
                .Index(t => t.Stylist_StylistID);
            
            CreateTable(
                "dbo.Stylists",
                c => new
                    {
                        StylistID = c.Int(nullable: false, identity: true),
                        Salon = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StylistID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Minutes = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Stylist_StylistID = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Stylists", t => t.Stylist_StylistID)
                .Index(t => t.Stylist_StylistID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Stylist_StylistID", "dbo.Stylists");
            DropForeignKey("dbo.Appointments", "Service_ServiceId", "dbo.Services");
            DropForeignKey("dbo.Services", "Stylist_StylistID", "dbo.Stylists");
            DropForeignKey("dbo.Appointments", "Schedule_ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "Stylist_StylistID", "dbo.Stylists");
            DropForeignKey("dbo.Stylists", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appointments", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Services", new[] { "Stylist_StylistID" });
            DropIndex("dbo.Stylists", new[] { "User_Id" });
            DropIndex("dbo.Schedules", new[] { "Stylist_StylistID" });
            DropIndex("dbo.Customers", new[] { "User_Id" });
            DropIndex("dbo.Appointments", new[] { "Stylist_StylistID" });
            DropIndex("dbo.Appointments", new[] { "Service_ServiceId" });
            DropIndex("dbo.Appointments", new[] { "Schedule_ScheduleId" });
            DropIndex("dbo.Appointments", new[] { "Customer_CustomerID" });
            DropTable("dbo.Services");
            DropTable("dbo.Stylists");
            DropTable("dbo.Schedules");
            DropTable("dbo.Customers");
            DropTable("dbo.Appointments");
        }
    }
}
