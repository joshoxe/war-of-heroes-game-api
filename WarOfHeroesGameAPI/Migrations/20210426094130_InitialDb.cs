using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfHeroesGameAPI.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttackDamage = table.Column<int>(type: "int", nullable: false),
                    UltimateAttackName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimateAttackDamage = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "AttackDamage", "Description", "Name", "UltimateAttackDamage", "UltimateAttackName" },
                values: new object[,]
                {
                    { 1, 3, "A basic hero with a basic description. His friendly manner will lure enemies into a false sense of security, stopping their attacks", "Taron", 15, "Hammer Smash" },
                    { 2, 5, "A basic hero with a basic description.", "Groth Nightmore", 10, "Headbutt" },
                    { 3, 3, "A basic hero with a basic description.", "Sin Deruv", 25, "Back Stab" },
                    { 4, 7, "A basic hero with a basic description.", "Tegril", 30, "Lightning Strike" },
                    { 5, 10, "A basic hero with a basic description.", "Warsa", 40, "War Cry" },
                    { 6, 5, "A basic hero with a basic description.", "Edam", 18, "Poison Strike" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
