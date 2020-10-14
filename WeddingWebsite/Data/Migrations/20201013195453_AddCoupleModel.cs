using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingWebsite.Data.Migrations
{
    public partial class AddCoupleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Couples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestOneId = table.Column<int>(nullable: false),
                    GuestTwoId = table.Column<int>(nullable: false),
                    CoupleTag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Couples_Guests_GuestOneId",
                        column: x => x.GuestOneId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Couples_Guests_GuestTwoId",
                        column: x => x.GuestTwoId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Couples_GuestOneId",
                table: "Couples",
                column: "GuestOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Couples_GuestTwoId",
                table: "Couples",
                column: "GuestTwoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Couples");
        }
    }
}
