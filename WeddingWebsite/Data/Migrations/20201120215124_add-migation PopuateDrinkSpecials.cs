using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingWebsite.Data.Migrations
{
    public partial class addmigationPopuateDrinkSpecials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO DrinkSpecials (DrinkName, DrinkDescription) VALUES ('Lemon Drop Champagne Punch', 'lemons, champagne, sugar, vodka, candied lemon peels')");
            migrationBuilder.Sql("INSERT INTO DrinkSpecials (DrinkName, DrinkDescription) VALUES ('Bees Knees', 'gin, lemon juice, honey syrup, topped with candied lemon peels')");
            migrationBuilder.Sql("INSERT INTO DrinkSpecials (DrinkName, DrinkDescription) VALUES ('Ginger Bourbon Smash', 'bourbon, Cointreau, lemon, thyme, cherries, basil, ginger beer')");
            migrationBuilder.Sql("INSERT INTO DrinkSpecials (DrinkName, DrinkDescription) VALUES ('Blackberry Tequila Lemon Cooler', 'blackberries, thyme, tequila, lemonade, sparkling water')");
            migrationBuilder.Sql("INSERT INTO DrinkSpecials (DrinkName, DrinkDescription) VALUES ('Sweet Bourbon Peach Lemonade', 'Lemonade with Raspberry & Peach, peach slices, bourbon, topped with peaches and thyme')");
            migrationBuilder.Sql("INSERT INTO DrinkSpecials (DrinkName, DrinkDescription) VALUES ('Blueberry gin sour', 'blueberries, simple syrup, lemon juice, egg white, gin, bitters, topped with candied lemon peels')");
            migrationBuilder.Sql("INSERT INTO DrinkSpecials (DrinkName, DrinkDescription) VALUES ('Gin Fizz', 'gin, lemon juice, maple syrup, egg white, soda water, topped with candied lemon peels')");
            migrationBuilder.Sql("INSERT INTO DrinkSpecials (DrinkName, DrinkDescription) VALUES ('Rose and Ginger Paloma', 'grapefruit juice, tequila, lime juice, rose water, ginger beer')");
            migrationBuilder.Sql("INSERT INTO DrinkSpecials (DrinkName, DrinkDescription) VALUES ('Pineapple Lime Beer Margaritas', 'tequila, pineapple juice, lime juice, agave nectar, Negra Modelo, topped with pineapple wedges')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
