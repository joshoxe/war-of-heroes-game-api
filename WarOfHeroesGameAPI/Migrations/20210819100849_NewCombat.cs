using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfHeroesGameAPI.Migrations
{
    public partial class NewCombat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttackDamage",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "UltimateAttackDamage",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "UltimateAttackName",
                table: "Heroes");

            migrationBuilder.AddColumn<int>(
                name: "AbilityId",
                table: "Heroes",
                type: "int",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A basic hero with a basic description.");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_AbilityId",
                table: "Heroes",
                column: "AbilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Ability_AbilityId",
                table: "Heroes",
                column: "AbilityId",
                principalTable: "Ability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Ability_AbilityId",
                table: "Heroes");

            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_AbilityId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "AbilityId",
                table: "Heroes");

            migrationBuilder.AddColumn<int>(
                name: "AttackDamage",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UltimateAttackDamage",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UltimateAttackName",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AttackDamage", "Description", "UltimateAttackDamage", "UltimateAttackName" },
                values: new object[] { 3, "A basic hero with a basic description. His friendly manner will lure enemies into a false sense of security, stopping their attacks", 15, "Hammer Smash" });

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AttackDamage", "UltimateAttackDamage", "UltimateAttackName" },
                values: new object[] { 5, 10, "Headbutt" });

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AttackDamage", "UltimateAttackDamage", "UltimateAttackName" },
                values: new object[] { 3, 25, "Back Stab" });

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AttackDamage", "UltimateAttackDamage", "UltimateAttackName" },
                values: new object[] { 7, 30, "Lightning Strike" });

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AttackDamage", "UltimateAttackDamage", "UltimateAttackName" },
                values: new object[] { 10, 40, "War Cry" });

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AttackDamage", "UltimateAttackDamage", "UltimateAttackName" },
                values: new object[] { 5, 18, "Poison Strike" });
        }
    }
}
