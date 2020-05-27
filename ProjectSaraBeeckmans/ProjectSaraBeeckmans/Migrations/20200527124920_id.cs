using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSaraBeeckmans.Migrations
{
    public partial class id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameIndex(
                name: "IX_Toesellen_Supplierid",
                table: "Toesellen",
                newName: "IX_Toesellen_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Toesellen_Bedrijfid",
                table: "Toesellen",
                newName: "IX_Toesellen_BedrijfId");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Toesellen",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BedrijfId",
                table: "Toesellen",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Toesellen_Bedrijven_BedrijfId",
                table: "Toesellen",
                column: "BedrijfId",
                principalTable: "Bedrijven",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Toesellen_Suppliers_SupplierId",
                table: "Toesellen",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameIndex(
                name: "IX_Toesellen_SupplierId",
                table: "Toesellen",
                newName: "IX_Toesellen_Supplierid");

            migrationBuilder.RenameIndex(
                name: "IX_Toesellen_BedrijfId",
                table: "Toesellen",
                newName: "IX_Toesellen_Bedrijfid");

            migrationBuilder.AlterColumn<int>(
                name: "Supplierid",
                table: "Toesellen",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Bedrijfid",
                table: "Toesellen",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
