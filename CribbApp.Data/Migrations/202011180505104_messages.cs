namespace CribbApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        SenderHouseId = c.Int(nullable: false),
                        MessageContent = c.String(),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        ReceiverHouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.MessageReply",
                c => new
                    {
                        MessageReplyId = c.Int(nullable: false, identity: true),
                        Message_MessageId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageReplyId)
                .ForeignKey("dbo.Message", t => t.Message_MessageId)
                .Index(t => t.Message_MessageId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ReplyContent = c.String(),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ReplyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageReply", "Message_MessageId", "dbo.Message");
            DropIndex("dbo.MessageReply", new[] { "Message_MessageId" });
            DropTable("dbo.Reply");
            DropTable("dbo.MessageReply");
            DropTable("dbo.Message");
        }
    }
}
