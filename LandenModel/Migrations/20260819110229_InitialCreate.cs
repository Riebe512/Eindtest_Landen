using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LandenModel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landen",
                columns: table => new
                {
                    LandCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landen", x => x.LandCode);
                });

            migrationBuilder.CreateTable(
                name: "Talen",
                columns: table => new
                {
                    TaalCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talen", x => x.TaalCode);
                });

            migrationBuilder.CreateTable(
                name: "Steden",
                columns: table => new
                {
                    StadNr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steden", x => x.StadNr);
                    table.ForeignKey(
                        name: "FK_Steden_Landen_LandCode",
                        column: x => x.LandCode,
                        principalTable: "Landen",
                        principalColumn: "LandCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandenTaal",
                columns: table => new
                {
                    LandCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaalCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandenTaal", x => new { x.LandCode, x.TaalCode });
                    table.ForeignKey(
                        name: "FK_LandenTaal_Landen_LandCode",
                        column: x => x.LandCode,
                        principalTable: "Landen",
                        principalColumn: "LandCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandenTaal_Talen_TaalCode",
                        column: x => x.TaalCode,
                        principalTable: "Talen",
                        principalColumn: "TaalCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Landen",
                columns: new[] { "LandCode", "Naam" },
                values: new object[,]
                {
                    { "BEL", "België" },
                    { "DEU", "Duitsland" },
                    { "FRA", "Frankrijk" },
                    { "LUX", "Luxemburg" },
                    { "NLD", "Nederland" }
                });

            migrationBuilder.InsertData(
                table: "Talen",
                columns: new[] { "TaalCode", "Naam" },
                values: new object[,]
                {
                    { "de", "Duits" },
                    { "fr", "Frans" },
                    { "lb", "Luxemburgs" },
                    { "nl", "Nederlands" }
                });

            migrationBuilder.InsertData(
                table: "LandenTaal",
                columns: new[] { "LandCode", "TaalCode" },
                values: new object[,]
                {
                    { "BEL", "de" },
                    { "BEL", "fr" },
                    { "BEL", "nl" },
                    { "DEU", "de" },
                    { "FRA", "fr" },
                    { "LUX", "de" },
                    { "LUX", "fr" },
                    { "LUX", "lb" },
                    { "NLD", "nl" }
                });

            migrationBuilder.InsertData(
                table: "Steden",
                columns: new[] { "StadNr", "LandCode", "Naam" },
                values: new object[,]
                {
                    { 1, "BEL", "Brussel" },
                    { 2, "BEL", "Antwerpen" },
                    { 3, "BEL", "Luik" },
                    { 4, "NLD", "Amsterdam" },
                    { 5, "NLD", "Den Haag" },
                    { 6, "NLD", "Rotterdam" },
                    { 7, "DEU", "Berlijn" },
                    { 8, "DEU", "Hamburg" },
                    { 9, "DEU", "München" },
                    { 10, "LUX", "Luxemburg" },
                    { 11, "FRA", "Parijs" },
                    { 12, "FRA", "Marseille" },
                    { 13, "FRA", "Lyon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LandenTaal_TaalCode",
                table: "LandenTaal",
                column: "TaalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Steden_LandCode",
                table: "Steden",
                column: "LandCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandenTaal");

            migrationBuilder.DropTable(
                name: "Steden");

            migrationBuilder.DropTable(
                name: "Talen");

            migrationBuilder.DropTable(
                name: "Landen");
        }
    }
}
