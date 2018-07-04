namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "IsActive");
        }
    }
}
