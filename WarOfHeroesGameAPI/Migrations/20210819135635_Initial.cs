using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfHeroesGameAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_Ability_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ability",
                columns: new[] { "Id", "Amount", "Type" },
                values: new object[,]
                {
                    { 1, 5, "Attack" },
                    { 2, 15, "Attack" },
                    { 3, 2, "Attack" },
                    { 4, 30, "Attack" },
                    { 5, 30, "Attack" },
                    { 6, 30, "Attack" },
                    { 7, 30, "Attack" }
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "AbilityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A basic hero with a basic description.", "Taron" },
                    { 5, 1, "A basic hero with a basic description.", "Warsa" },
                    { 6, 1, "A basic hero with a basic description.", "Edam" },
                    { 7, 1, "A basic hero with a basic description.", "esf" },
                    { 2, 2, "A basic hero with a basic description.", "Groth Nightmore" },
                    { 3, 3, "A basic hero with a basic description.", "Sin Deruv" },
                    { 4, 4, "A basic hero with a basic description.", "Tegril" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_AbilityId",
                table: "Heroes",
                column: "AbilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Ability");
        }
    }
}
