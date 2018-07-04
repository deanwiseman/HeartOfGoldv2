namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDonorToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Donor_Id", c => c.Int());
            CreateIndex("dbo.Items", "Donor_Id");
            AddForeignKey("dbo.Items", "Donor_Id", "dbo.Donors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Donor_Id", "dbo.Donors");
            DropIndex("dbo.Items", new[] { "Donor_Id" });
            DropColumn("dbo.Items", "Donor_Id");
        }
    }
}
