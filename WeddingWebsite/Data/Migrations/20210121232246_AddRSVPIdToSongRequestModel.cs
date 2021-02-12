using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingWebsite.Data.Migrations
{
    public partial class AddRSVPIdToSongRequestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongRequests_RSVPs_RSVPId",
                table: "SongRequests");

            migrationBuilder.AlterColumn<int>(
                name: "RSVPId",
                table: "SongRequests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SongRequests_RSVPs_RSVPId",
                table: "SongRequests",
                column: "RSVPId",
                principalTable: "RSVPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongRequests_RSVPs_RSVPId",
                table: "SongRequests");

            migrationBuilder.AlterColumn<int>(
                name: "RSVPId",
                table: "SongRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SongRequests_RSVPs_RSVPId",
                table: "SongRequests",
                column: "RSVPId",
                principalTable: "RSVPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
