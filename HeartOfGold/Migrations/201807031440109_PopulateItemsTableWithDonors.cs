namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateItemsTableWithDonors : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Items SET Donor_Id = 1 WHERE Id = 1");
            Sql("UPDATE Items SET Donor_Id = 2 WHERE Id = 4");
            Sql("UPDATE Items SET Donor_Id = 3 WHERE Id = 2");
            Sql("UPDATE Items SET Donor_Id = 4 WHERE Id = 3");

        }
        
        public override void Down()
        {
        }
    }
}
