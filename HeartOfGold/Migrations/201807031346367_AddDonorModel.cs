namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDonorModel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Donor");
        }
        
        public override void Down()
        {
        }
    }
}
