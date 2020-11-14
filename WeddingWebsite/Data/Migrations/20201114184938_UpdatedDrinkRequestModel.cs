using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingWebsite.Data.Migrations
{
    public partial class UpdatedDrinkRequestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkRequests_DrinkSpecials_SpecialtyDrinkModelID",
                table: "DrinkRequests");

            migrationBuilder.RenameColumn(
                name: "SpecialtyDrinkModelID",
                table: "DrinkRequests",
                newName: "SpecialtyDrinkModelId");

            migrationBuilder.RenameIndex(
                name: "IX_DrinkRequests_SpecialtyDrinkModelID",
                table: "DrinkRequests",
                newName: "IX_DrinkRequests_SpecialtyDrinkModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkRequests_DrinkSpecials_SpecialtyDrinkModelId",
                table: "DrinkRequests",
                column: "SpecialtyDrinkModelId",
                principalTable: "DrinkSpecials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkRequests_DrinkSpecials_SpecialtyDrinkModelId",
                table: "DrinkRequests");

            migrationBuilder.RenameColumn(
                name: "SpecialtyDrinkModelId",
                table: "DrinkRequests",
                newName: "SpecialtyDrinkModelID");

            migrationBuilder.RenameIndex(
                name: "IX_DrinkRequests_SpecialtyDrinkModelId",
                table: "DrinkRequests",
                newName: "IX_DrinkRequests_SpecialtyDrinkModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkRequests_DrinkSpecials_SpecialtyDrinkModelID",
                table: "DrinkRequests",
                column: "SpecialtyDrinkModelID",
                principalTable: "DrinkSpecials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
