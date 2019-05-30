using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TextFileGeneration.Migrations
{
    public partial class AddedInterExchangeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HardwareStores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileType = table.Column<int>(nullable: false),
                    Period = table.Column<DateTime>(nullable: false),
                    TransmitionDate = table.Column<DateTime>(nullable: false),
                    RNC = table.Column<string>(nullable: true),
                    TotalTransactions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareStores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterExchanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreditsQuantity = table.Column<int>(nullable: false),
                    StudentsQuantity = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    TransmissionDate = table.Column<DateTime>(nullable: false),
                    Period = table.Column<DateTime>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterExchanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardwareStoreEmployees",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    VoluntaryContribution = table.Column<double>(nullable: false),
                    OthersRemunerations = table.Column<double>(nullable: false),
                    InfotepSalay = table.Column<double>(nullable: false),
                    IsrSalary = table.Column<double>(nullable: false),
                    HardwareStoreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareStoreEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareStoreEmployees_HardwareStores_HardwareStoreId",
                        column: x => x.HardwareStoreId,
                        principalTable: "HardwareStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identification = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    CreditsQuantity = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    CurrentStudentQuarter = table.Column<int>(nullable: false),
                    InterExchangeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_InterExchanges_InterExchangeId",
                        column: x => x.InterExchangeId,
                        principalTable: "InterExchanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HardwareStoreEmployees_HardwareStoreId",
                table: "HardwareStoreEmployees",
                column: "HardwareStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_InterExchangeId",
                table: "Students",
                column: "InterExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardwareStoreEmployees");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "HardwareStores");

            migrationBuilder.DropTable(
                name: "InterExchanges");
        }
    }
}
