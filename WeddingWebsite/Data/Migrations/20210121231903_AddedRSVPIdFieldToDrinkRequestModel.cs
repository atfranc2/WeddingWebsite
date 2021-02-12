using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingWebsite.Data.Migrations
{
    public partial class AddedRSVPIdFieldToDrinkRequestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkRequests_RSVPs_RSVPId",
                table: "DrinkRequests");

            migrationBuilder.AlterColumn<int>(
                name: "RSVPId",
                table: "DrinkRequests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkRequests_RSVPs_RSVPId",
                table: "DrinkRequests",
                column: "RSVPId",
                principalTable: "RSVPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkRequests_RSVPs_RSVPId",
                table: "DrinkRequests");

            migrationBuilder.AlterColumn<int>(
                name: "RSVPId",
                table: "DrinkRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkRequests_RSVPs_RSVPId",
                table: "DrinkRequests",
                column: "RSVPId",
                principalTable: "RSVPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
