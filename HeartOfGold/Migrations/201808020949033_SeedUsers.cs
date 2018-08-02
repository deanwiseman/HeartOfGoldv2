namespace HeartOfGold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4a05745a-d808-4617-8549-cb9339c44403', N'guest@mandela.ac.za', 0, N'AKexHuwfhERinc42z726AiAi9GdGzN8E5yUxwG2nOPmN/p+0VFM0OOyfPmm/fBqcgg==', N'77d2d4c0-4c2a-4591-8232-1182bc5a772b', NULL, 0, 0, NULL, 1, 0, N'guest@mandela.ac.za')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'eb3b1f36-4655-4386-bd2c-53cb0f68f1a0', N'administrator@mandela.ac.za', 0, N'AN0ynUCiLjH47ZaoyTwHZ+5tCfpwLNSoXUUMYylprLECSZw/mV9yjDeAOk07uQRjDQ==', N'dfcad21f-e3a7-46b6-b764-f4798456398d', NULL, 0, 0, NULL, 1, 0, N'administrator@mandela.ac.za')
                        INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'eee258f7-2ace-4cee-b6ae-7a763db18cb2', N'Administrator')
                            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eb3b1f36-4655-4386-bd2c-53cb0f68f1a0', N'eee258f7-2ace-4cee-b6ae-7a763db18cb2')
");
        }
        
        public override void Down()
        {
        }
    }
}
