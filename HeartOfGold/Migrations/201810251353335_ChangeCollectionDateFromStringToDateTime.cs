namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCollectionDateFromStringToDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "CollectionDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "CollectionDate", c => c.String());
        }
    }
}
