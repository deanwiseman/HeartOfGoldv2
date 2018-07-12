namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdInCategoryTableToByte : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "Category_Id" });
            DropColumn("dbo.Items", "CategoryId");
            RenameColumn(table: "dbo.Items", name: "Category_Id", newName: "CategoryId");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Items", "CategoryId", c => c.Byte(nullable: true));
            AddPrimaryKey("dbo.Categories", "Id");
            CreateIndex("dbo.Items", "CategoryId");
            AddForeignKey("dbo.Items", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Items", "CategoryId", c => c.Int());
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "Id");
            RenameColumn(table: "dbo.Items", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.Items", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Items", "Category_Id");
            AddForeignKey("dbo.Items", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
