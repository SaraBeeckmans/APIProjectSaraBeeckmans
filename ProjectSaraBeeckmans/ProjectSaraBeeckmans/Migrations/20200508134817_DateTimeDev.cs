using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSaraBeeckmans.Migrations
{
    public partial class DateTimeDev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AankoopDatum",
                table: "Toesellen",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AankoopDatum",
                table: "Toesellen",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
