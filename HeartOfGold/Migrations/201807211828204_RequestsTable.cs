namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentNumber = c.String(nullable: false, maxLength: 9),
                        Description = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        RequestStatusId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RequestStatus", t => t.RequestStatusId, cascadeDelete: true)
                .Index(t => t.RequestStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "RequestStatusId", "dbo.RequestStatus");
            DropIndex("dbo.Requests", new[] { "RequestStatusId" });
            DropTable("dbo.Requests");
        }
    }
}
