namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDowToEventModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "StartDayOfWeek", c => c.Int());
            AddColumn("dbo.Events", "EndDayOfWeek", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EndDayOfWeek");
            DropColumn("dbo.Events", "StartDayOfWeek");
        }
    }
}
