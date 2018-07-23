namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateItemModelAddDonorId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Donor_Id", "dbo.Donors");
            DropIndex("dbo.Items", new[] { "Donor_Id" });
            RenameColumn(table: "dbo.Items", name: "Donor_Id", newName: "DonorId");
            AlterColumn("dbo.Items", "DonorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "DonorId");
            AddForeignKey("dbo.Items", "DonorId", "dbo.Donors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "DonorId", "dbo.Donors");
            DropIndex("dbo.Items", new[] { "DonorId" });
            AlterColumn("dbo.Items", "DonorId", c => c.Int());
            RenameColumn(table: "dbo.Items", name: "DonorId", newName: "Donor_Id");
            CreateIndex("dbo.Items", "Donor_Id");
            AddForeignKey("dbo.Items", "Donor_Id", "dbo.Donors", "Id");
        }
    }
}
