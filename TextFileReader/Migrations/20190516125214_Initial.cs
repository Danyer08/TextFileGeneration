using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TextFileReader.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransmissionDate = table.Column<DateTime>(nullable: false),
                    EmployeeQuantity = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    RNC = table.Column<string>(nullable: true),
                    Roster = table.Column<decimal>(nullable: false),
                    ProccesingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleArchivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identification = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(nullable: false),
                    EmployeeCode = table.Column<string>(nullable: true),
                    ArchivoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleArchivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleArchivos_Archivos_ArchivoId",
                        column: x => x.ArchivoId,
                        principalTable: "Archivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleArchivos_ArchivoId",
                table: "DetalleArchivos",
                column: "ArchivoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleArchivos");

            migrationBuilder.DropTable(
                name: "Archivos");
        }
    }
}
