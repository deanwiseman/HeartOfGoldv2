namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableIntRequestKeyToEventModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "RequestKey", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "RequestKey");
        }
    }
}
