namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDummyDataToInventory : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Items (Name, Description, Quantity, IsActive, Category_Id, Donor_Id) " +
                "VALUES ('IT Management 121', 'IT Management 121 Book', 1, 1, 2, 1)");

            Sql("INSERT INTO Items (Name, Description, Quantity, IsActive, Category_Id, Donor_Id) " +
                "VALUES ('Scientific Calculator', 'Casio Scientific Calculator', 10, 1, 3, 2)");

            Sql("INSERT INTO Items (Name, Description, Quantity, IsActive, Category_Id, Donor_Id) " +
                "VALUES ('Winter Beanie', 'Winter wool beanie', 8, 1, 1, 3)");

            Sql("INSERT INTO Items (Name, Description, Quantity, IsActive, Category_Id, Donor_Id) " +
                "VALUES ('A4 Hard Cover', 'Hard Cover A4 Book 220 Page', 30, 1, 3, 5)");

            Sql("INSERT INTO Items (Name, Description, Quantity, IsActive, Category_Id, Donor_Id) " +
                "VALUES ('Meal Voucher', 'Meal Voucher for cafeteria', 20, 1, 5, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
