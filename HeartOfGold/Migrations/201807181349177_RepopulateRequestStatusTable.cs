namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepopulateRequestStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RequestStatus (Id, Name) VALUES ('1', 'Open')");
            Sql("INSERT INTO RequestStatus (Id, Name) VALUES ('2', 'Successful')");
            Sql("INSERT INTO RequestStatus (Id, Name) VALUES ('3', 'Unsuccesful')");
        }
        
        public override void Down()
        {
        }
    }
}
