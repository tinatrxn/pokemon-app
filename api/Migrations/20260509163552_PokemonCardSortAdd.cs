using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class PokemonCardSortAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortNumber",
                table: "PokemonCards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PokemonCards",
                keyColumn: "PokemonCardId",
                keyValue: 1,
                column: "SortNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "PokemonCards",
                keyColumn: "PokemonCardId",
                keyValue: 2,
                column: "SortNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "PokemonCards",
                keyColumn: "PokemonCardId",
                keyValue: 3,
                column: "SortNumber",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortNumber",
                table: "PokemonCards");
        }
    }
}
