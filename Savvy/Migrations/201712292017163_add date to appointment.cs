namespace Savvy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatetoappointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Date");
        }
    }
}
