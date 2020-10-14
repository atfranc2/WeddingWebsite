using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingWebsite.Data.Migrations
{
    public partial class AddedFullNameToGuestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Guests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Guests");
        }
    }
}
