namespace CribbApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class neighborhoods : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Neighborhood",
                c => new
                    {
                        NeighborhoodId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.NeighborhoodId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Neighborhood");
        }
    }
}
