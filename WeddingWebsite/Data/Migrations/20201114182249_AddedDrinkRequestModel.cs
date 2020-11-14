using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingWebsite.Data.Migrations
{
    public partial class AddedDrinkRequestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrinkRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<int>(nullable: false),
                    SpecialtyDrinkModelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrinkRequests_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkRequests_DrinkSpecials_SpecialtyDrinkModelID",
                        column: x => x.SpecialtyDrinkModelID,
                        principalTable: "DrinkSpecials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrinkRequests_GuestId",
                table: "DrinkRequests",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkRequests_SpecialtyDrinkModelID",
                table: "DrinkRequests",
                column: "SpecialtyDrinkModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrinkRequests");
        }
    }
}
