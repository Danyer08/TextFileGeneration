using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TextFileReader.Migrations
{
    public partial class Practica3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_Students_InterExchangeId",
                table: "Students",
                column: "InterExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "InterExchanges");
        }
    }
}
