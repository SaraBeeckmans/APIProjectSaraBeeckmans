using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSaraBeeckmans.Migrations
{
    public partial class newMysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bedrijven",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BedrijfNaam = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Adres = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedrijven", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: false),
                    Opmerking = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Toesellen",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SerieNummer = table.Column<string>(nullable: false),
                    AankoopDatum = table.Column<string>(nullable: true),
                    Garantie = table.Column<string>(nullable: true),
                    Prijs = table.Column<double>(nullable: false),
                    Bedrijfid = table.Column<int>(nullable: true),
                    Supplierid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toesellen", x => x.id);
                    table.ForeignKey(
                        name: "FK_Toesellen_Bedrijven_Bedrijfid",
                        column: x => x.Bedrijfid,
                        principalTable: "Bedrijven",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Toesellen_Suppliers_Supplierid",
                        column: x => x.Supplierid,
                        principalTable: "Suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toesellen_Bedrijfid",
                table: "Toesellen",
                column: "Bedrijfid");

            migrationBuilder.CreateIndex(
                name: "IX_Toesellen_Supplierid",
                table: "Toesellen",
                column: "Supplierid");
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
