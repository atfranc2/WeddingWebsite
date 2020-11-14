using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingWebsite.Data.Migrations
{
    public partial class AddedRSVPModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RSVPId",
                table: "SongRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RSVPId",
                table: "DrinkRequests",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RSVPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestOneName = table.Column<string>(nullable: true),
                    GuestOneId = table.Column<int>(nullable: false),
                    GuestTwoName = table.Column<string>(nullable: true),
                    GuestTwoId = table.Column<int>(nullable: false),
                    GuestTag = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    GuestOneAccepts = table.Column<bool>(nullable: false),
                    GuestTwoAccepts = table.Column<bool>(nullable: false),
                    DayOfArrival = table.Column<DateTime>(nullable: false),
                    TimeOfArrival = table.Column<DateTime>(nullable: false),
                    MarriageAdvice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSVPs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongRequests_RSVPId",
                table: "SongRequests",
                column: "RSVPId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkRequests_RSVPId",
                table: "DrinkRequests",
                column: "RSVPId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkRequests_RSVPs_RSVPId",
                table: "DrinkRequests",
                column: "RSVPId",
                principalTable: "RSVPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongRequests_RSVPs_RSVPId",
                table: "SongRequests",
                column: "RSVPId",
                principalTable: "RSVPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkRequests_RSVPs_RSVPId",
                table: "DrinkRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SongRequests_RSVPs_RSVPId",
                table: "SongRequests");

            migrationBuilder.DropTable(
                name: "RSVPs");

            migrationBuilder.DropIndex(
                name: "IX_SongRequests_RSVPId",
                table: "SongRequests");

            migrationBuilder.DropIndex(
                name: "IX_DrinkRequests_RSVPId",
                table: "DrinkRequests");

            migrationBuilder.DropColumn(
                name: "RSVPId",
                table: "SongRequests");

            migrationBuilder.DropColumn(
                name: "RSVPId",
                table: "DrinkRequests");
        }
    }
}
