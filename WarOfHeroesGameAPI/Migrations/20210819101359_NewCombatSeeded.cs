using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfHeroesGameAPI.Migrations
{
    public partial class NewCombatSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ability",
                columns: new[] { "Id", "Amount", "Type" },
                values: new object[,]
                {
                    { 1, 5, "Attack" },
                    { 2, 15, "Attack" },
                    { 3, 2, "Attack" },
                    { 4, 30, "Attack" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ability",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ability",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ability",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ability",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
