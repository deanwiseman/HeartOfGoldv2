namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedStudents : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'06789549-1039-4a79-b325-46844072d845', N's212345678@mandela.ac.za', 0, N'AMKXifnNhu0KoxFaQrPWLKzit4Q6Y0D3iFpBVUd8jhihzdDmK4NaI0sCthQ4xZTu2A==', N'b803aa1a-779d-4634-953d-aa3c5552acd2', NULL, 0, 0, NULL, 1, 0, N's212345678@mandela.ac.za')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3617e66d-ad84-403e-aaf0-31a3f3fa8ea0', N'Student')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'06789549-1039-4a79-b325-46844072d845', N'3617e66d-ad84-403e-aaf0-31a3f3fa8ea0')

");
        }
        
        public override void Down()
        {
        }
    }
}
