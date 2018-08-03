namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLengthOfStudentNumberForValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "StudentNumber", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "StudentNumber", c => c.String(nullable: false, maxLength: 9));
        }
    }
}
