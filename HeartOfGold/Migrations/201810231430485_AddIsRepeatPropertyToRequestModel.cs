namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsRepeatPropertyToRequestModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "IsRepeat", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "IsRepeat");
        }
    }
}
