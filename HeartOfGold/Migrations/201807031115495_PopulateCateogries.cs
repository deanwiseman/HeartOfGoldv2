namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCateogries : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES ('Clothing')");
            Sql("INSERT INTO Categories (Name) VALUES ('Textbook')");
            Sql("INSERT INTO Categories (Name) VALUES ('Stationery')");
            Sql("INSERT INTO Categories (Name) VALUES ('Food')");
            Sql("INSERT INTO Categories (Name) VALUES ('Other')");
        }
        
        public override void Down()
        {
        }
    }
}
