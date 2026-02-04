using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "PokemonCards",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.InsertData(
                table: "Binders",
                columns: new[] { "BinderId", "Name" },
                values: new object[,]
                {
                    { 1, "Obtained" },
                    { 2, "Wishlist" }
                });

            migrationBuilder.InsertData(
                table: "PokemonCards",
                columns: new[] { "PokemonCardId", "BinderId", "Name", "Number", "Set" },
                values: new object[,]
                {
                    { 1, 2, "Sylveon GX", "SV76/SV94", "Hidden Fates" },
                    { 2, 1, "N's Zorua", "SVP189", "Journey Together" },
                    { 3, 1, "Yamper on Bed", "099/094", "Phantasmal Flames" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PokemonCards",
                keyColumn: "PokemonCardId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PokemonCards",
                keyColumn: "PokemonCardId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PokemonCards",
                keyColumn: "PokemonCardId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Binders",
                keyColumn: "BinderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Binders",
                keyColumn: "BinderId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "PokemonCards",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
