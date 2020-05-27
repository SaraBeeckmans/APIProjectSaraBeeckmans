using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSaraBeeckmans.Migrations
{
    public partial class id2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toesellen_Bedrijven_BedrijfId",
                table: "Toesellen");

            migrationBuilder.DropForeignKey(
                name: "FK_Toesellen_Suppliers_SupplierId",
                table: "Toesellen");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Toesellen",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BedrijfId",
                table: "Toesellen",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Toesellen_Bedrijven_BedrijfId",
                table: "Toesellen",
                column: "BedrijfId",
                principalTable: "Bedrijven",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toesellen_Suppliers_SupplierId",
                table: "Toesellen",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toesellen_Bedrijven_BedrijfId",
                table: "Toesellen");

            migrationBuilder.DropForeignKey(
                name: "FK_Toesellen_Suppliers_SupplierId",
                table: "Toesellen");

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
    }
}
