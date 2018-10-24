namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCollectionDateToRequestModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "CollectionDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "CollectionDate");
        }
    }
}
