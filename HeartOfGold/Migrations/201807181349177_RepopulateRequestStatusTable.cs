namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepopulateRequestStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RequestStatus (Name) VALUES ('Pending')");
            Sql("INSERT INTO RequestStatus (Name) VALUES ('Accepted')");
            Sql("INSERT INTO RequestStatus (Name) VALUES ('Declined')");
        }
        
        public override void Down()
        {
        }
    }
}
