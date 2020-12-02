using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingWebsite.Data.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'03badc35-1fb2-4886-9122-40ce155f540c', N'admin@andrewabby.net', N'ADMIN@ANDREWABBY.NET', N'admin@andrewabby.net', N'ADMIN@ANDREWABBY.NET', 1, N'AQAAAAEAACcQAAAAEBl7eUN6/e7RA7uX9IvbRBjY//Pb1yEDfm+n9J8Sa5cjrcNbDOwfFBv60B0LZ2rcag==', N'UQ7LCTSKAXUVJLZOJODYYCWEWORPZFY6', N'a77f2f23-885e-4172-be24-3b7f5abcf794', NULL, 0, 0, NULL, 1, 0)
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3c2d8c82-318a-466b-bac9-cf84e974d273', N'guest@andrewabby.net', N'GUEST@ANDREWABBY.NET', N'guest@andrewabby.net', N'GUEST@ANDREWABBY.NET', 1, N'AQAAAAEAACcQAAAAELWMpCC58RuVA5DgTxJZP4AFGby1Q46+IFIjfYyJlaab+7w8nX5jSnrU4F6P7/16hQ==', N'NQJSY6BYAMNFTNLU4JAFY2C5MZWX2XDJ', N'e2b67c2d-9b1d-436b-8d04-a34887742948', NULL, 0, 0, NULL, 1, 0)
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'64e96b65-0192-4087-b108-66cfc284574f', N'Guest', N'GUEST', N'aaad4df3-5de2-414e-aa3f-7b88473bca7c')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c26b1027-05f6-40ca-b92b-db8ad435efa8', N'Admin', N'ADMIN', N'6372e006-6116-452b-a8a0-a722fbc81d23')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'03badc35-1fb2-4886-9122-40ce155f540c', N'c26b1027-05f6-40ca-b92b-db8ad435efa8')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3c2d8c82-318a-466b-bac9-cf84e974d273', N'64e96b65-0192-4087-b108-66cfc284574f')
            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
