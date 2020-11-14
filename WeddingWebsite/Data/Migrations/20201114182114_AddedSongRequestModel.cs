using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingWebsite.Data.Migrations
{
    public partial class AddedSongRequestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SongRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<int>(nullable: false),
                    SongTitle = table.Column<string>(nullable: true),
                    SongArtist = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongRequests_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongRequests_GuestId",
                table: "SongRequests",
                column: "GuestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongRequests");
        }
    }
}
