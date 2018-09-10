namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepopulateRequestStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RequestStatus (Name) VALUES ('Open')");
            Sql("INSERT INTO RequestStatus (Name) VALUES ('Successful')");
            Sql("INSERT INTO RequestStatus (Name) VALUES ('Unsuccesful')");
        }
        
        public override void Down()
        {
        }
    }
}
