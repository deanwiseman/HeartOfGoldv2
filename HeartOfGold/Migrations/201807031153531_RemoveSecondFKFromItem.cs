namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSecondFKFromItem : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "CategoryId", c => c.Byte(nullable: false));
        }
    }
}
