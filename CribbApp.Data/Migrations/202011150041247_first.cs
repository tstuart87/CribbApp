namespace CribbApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.House", "StreetAddressOne", c => c.String());
            AddColumn("dbo.House", "StreetAddressTwo", c => c.String());
            AddColumn("dbo.House", "ApartmentNumber", c => c.String());
            AddColumn("dbo.House", "City", c => c.String());
            AddColumn("dbo.House", "State", c => c.Int(nullable: false));
            AddColumn("dbo.House", "ZipCode", c => c.String());
            AddColumn("dbo.House", "Country", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.House", "Country");
            DropColumn("dbo.House", "ZipCode");
            DropColumn("dbo.House", "State");
            DropColumn("dbo.House", "City");
            DropColumn("dbo.House", "ApartmentNumber");
            DropColumn("dbo.House", "StreetAddressTwo");
            DropColumn("dbo.House", "StreetAddressOne");
        }
    }
}
