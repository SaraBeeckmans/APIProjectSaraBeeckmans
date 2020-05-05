using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSaraBeeckmans.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bedrijven",
                columns: table => new
                {
                    BedrijfId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BedrijfNaam = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Adres = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedrijven", x => x.BedrijfId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(nullable: false),
                    Opmerking = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Toesellen",
                columns: table => new
                {
                    ToestelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SerieNummer = table.Column<string>(nullable: false),
                    AankoopDatum = table.Column<DateTime>(nullable: false),
                    Garantie = table.Column<string>(nullable: true),
                    Prijs = table.Column<double>(nullable: false),
                    BedrijfId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toesellen", x => x.ToestelId);
                    table.ForeignKey(
                        name: "FK_Toesellen_Bedrijven_BedrijfId",
                        column: x => x.BedrijfId,
                        principalTable: "Bedrijven",
                        principalColumn: "BedrijfId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Toesellen_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toesellen_BedrijfId",
                table: "Toesellen",
                column: "BedrijfId");

            migrationBuilder.CreateIndex(
                name: "IX_Toesellen_SupplierId",
                table: "Toesellen",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Toesellen");

            migrationBuilder.DropTable(
                name: "Bedrijven");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
