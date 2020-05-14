using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSaraBeeckmans.Migrations
{
    public partial class aanpassing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toesellen_Bedrijven_BedrijfId",
                table: "Toesellen");

            migrationBuilder.DropForeignKey(
                name: "FK_Toesellen_Suppliers_SupplierId",
                table: "Toesellen");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Toesellen",
                newName: "Supplierid");

            migrationBuilder.RenameColumn(
                name: "BedrijfId",
                table: "Toesellen",
                newName: "Bedrijfid");

            migrationBuilder.RenameColumn(
                name: "ToestelId",
                table: "Toesellen",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Toesellen_SupplierId",
                table: "Toesellen",
                newName: "IX_Toesellen_Supplierid");

            migrationBuilder.RenameIndex(
                name: "IX_Toesellen_BedrijfId",
                table: "Toesellen",
                newName: "IX_Toesellen_Bedrijfid");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Suppliers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CategorieId",
                table: "Categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "BedrijfId",
                table: "Bedrijven",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Toesellen_Bedrijven_Bedrijfid",
                table: "Toesellen",
                column: "Bedrijfid",
                principalTable: "Bedrijven",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toesellen_Suppliers_Supplierid",
                table: "Toesellen",
                column: "Supplierid",
                principalTable: "Suppliers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toesellen_Bedrijven_Bedrijfid",
                table: "Toesellen");

            migrationBuilder.DropForeignKey(
                name: "FK_Toesellen_Suppliers_Supplierid",
                table: "Toesellen");

            migrationBuilder.RenameColumn(
                name: "Supplierid",
                table: "Toesellen",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "Bedrijfid",
                table: "Toesellen",
                newName: "BedrijfId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Toesellen",
                newName: "ToestelId");

            migrationBuilder.RenameIndex(
                name: "IX_Toesellen_Supplierid",
                table: "Toesellen",
                newName: "IX_Toesellen_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Toesellen_Bedrijfid",
                table: "Toesellen",
                newName: "IX_Toesellen_BedrijfId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Suppliers",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "CategorieId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Bedrijven",
                newName: "BedrijfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toesellen_Bedrijven_BedrijfId",
                table: "Toesellen",
                column: "BedrijfId",
                principalTable: "Bedrijven",
                principalColumn: "BedrijfId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toesellen_Suppliers_SupplierId",
                table: "Toesellen",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
