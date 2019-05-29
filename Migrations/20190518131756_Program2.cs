using Microsoft.EntityFrameworkCore.Migrations;

namespace TextFileGeneration.Migrations
{
    public partial class Program2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CotizableSalary",
                table: "Employees",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ISRSalary",
                table: "Employees",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Identification",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InfotepSalary",
                table: "Employees",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OtherRemuneration",
                table: "Employees",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VoluntaryAport",
                table: "Employees",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CotizableSalary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ISRSalary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Identification",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "InfotepSalary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OtherRemuneration",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "VoluntaryAport",
                table: "Employees");
        }
    }
}
