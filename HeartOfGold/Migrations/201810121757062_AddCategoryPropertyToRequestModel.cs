namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryPropertyToRequestModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "CategoryId", c => c.Byte());
            CreateIndex("dbo.Requests", "CategoryId");
            AddForeignKey("dbo.Requests", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Requests", new[] { "CategoryId" });
            DropColumn("dbo.Requests", "CategoryId");
        }
    }
}
