namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDonorTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Donors", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Donors", "Email", c => c.String(nullable: false));

            Sql("INSERT INTO Donors (FirstName, LastName, Email) VALUES ('Dumisani', 'Tom', 'dumisani.tom@gmail.com')");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "Email", c => c.String());
            AlterColumn("dbo.Donors", "LastName", c => c.String());
            AlterColumn("dbo.Donors", "FirstName", c => c.String());
        }
    }
}
