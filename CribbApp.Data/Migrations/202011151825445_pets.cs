namespace CribbApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pet",
                c => new
                    {
                        PetId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        HouseId = c.Int(nullable: false),
                        Name = c.String(),
                        PetAge = c.Int(),
                        Personality = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PetId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pet");
        }
    }
}
