using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandenModel.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "DEU",
                column: "Naam",
                value: "Duitsland");

            migrationBuilder.UpdateData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "LUX",
                column: "Naam",
                value: "Luxemburg");

            migrationBuilder.UpdateData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 4,
                column: "LandCode",
                value: "NLD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "DEU",
                column: "Naam",
                value: "Duitslans");

            migrationBuilder.UpdateData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "LUX",
                column: "Naam",
                value: "Luxenburg");

            migrationBuilder.UpdateData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 4,
                column: "LandCode",
                value: "BEL");
        }
    }
}
