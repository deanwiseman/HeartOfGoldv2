namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDowFromEventModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "StartDayOfWeek");
            DropColumn("dbo.Events", "EndDayOfWeek");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EndDayOfWeek", c => c.Int());
            AddColumn("dbo.Events", "StartDayOfWeek", c => c.Int());
        }
    }
}
