using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TextFileReader.Migrations
{
    public partial class program2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CotizableSalary",
                table: "DetalleArchivos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ISRSalary",
                table: "DetalleArchivos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InfotepSalary",
                table: "DetalleArchivos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OtherRemuneration",
                table: "DetalleArchivos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VoluntaryAport",
                table: "DetalleArchivos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Archivos",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Archivos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "Archivos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CotizableSalary",
                table: "DetalleArchivos");

            migrationBuilder.DropColumn(
                name: "ISRSalary",
                table: "DetalleArchivos");

            migrationBuilder.DropColumn(
                name: "InfotepSalary",
                table: "DetalleArchivos");

            migrationBuilder.DropColumn(
                name: "OtherRemuneration",
                table: "DetalleArchivos");

            migrationBuilder.DropColumn(
                name: "VoluntaryAport",
                table: "DetalleArchivos");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Archivos");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Archivos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Archivos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
