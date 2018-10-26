namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllocatedDonationItemToRequestModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "AllocatedDonationItem", c => c.String());
            DropColumn("dbo.Requests", "IsRepeat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "IsRepeat", c => c.Boolean(nullable: false));
            DropColumn("dbo.Requests", "AllocatedDonationItem");
        }
    }
}
