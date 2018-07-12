namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeItemModelCategoryId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "Category_Id" });
            AddColumn("dbo.Items", "CategoryId", c => c.Byte(nullable: false));
            DropColumn("dbo.Items", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Category_Id", c => c.Int());
            DropColumn("dbo.Items", "CategoryId");
            CreateIndex("dbo.Items", "Category_Id");
            AddForeignKey("dbo.Items", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
