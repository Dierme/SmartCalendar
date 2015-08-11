namespace SmartCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "DateAdd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "DateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "DateEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "DateAddString");
            DropColumn("dbo.Events", "DateStartString");
            DropColumn("dbo.Events", "DateEndString");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "DateEndString", c => c.String(nullable: false));
            AddColumn("dbo.Events", "DateStartString", c => c.String(nullable: false));
            AddColumn("dbo.Events", "DateAddString", c => c.String(nullable: false));
            DropColumn("dbo.Events", "DateEnd");
            DropColumn("dbo.Events", "DateStart");
            DropColumn("dbo.Events", "DateAdd");
        }
    }
}
