namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDonorsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Donors (FirstName, LastName, Email) VALUES ('Dean', 'Wiseman', 's212273582@mandela.ac.za')");
            Sql("INSERT INTO Donors (FirstName, LastName, Email) VALUES ('Jeremy', 'Johnson', 's241103492@mandela.ac.za')");
            Sql("INSERT INTO Donors (FirstName, LastName, Email) VALUES ('Ashley', 'Butler', 's20115492@mandela.ac.za')");
            Sql("INSERT INTO Donors (FirstName, LastName, Email) VALUES ('Cheryl', 'Schroder', 'c.schroder@mandela.ac.za')");
            Sql("INSERT INTO Donors (FirstName, LastName, Email) VALUES ('Nick', 'McCarthy', 'nnmccarthy@gmail.com')");

        }
        
        public override void Down()
        {
        }
    }
}
