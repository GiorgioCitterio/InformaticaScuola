using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsempiModel.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars1",
                columns: table => new
                {
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    LicensePlate = table.Column<string>(type: "TEXT", nullable: false),
                    Make = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars1", x => new { x.State, x.LicensePlate });
                });

            migrationBuilder.CreateTable(
                name: "RecordOfSales",
                columns: table => new
                {
                    RecordOfSaleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateSold = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    CarState = table.Column<string>(type: "TEXT", nullable: false),
                    CarLicensePlate = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordOfSales", x => x.RecordOfSaleId);
                    table.ForeignKey(
                        name: "FK_RecordOfSales_Cars1_CarState_CarLicensePlate",
                        columns: x => new { x.CarState, x.CarLicensePlate },
                        principalTable: "Cars1",
                        principalColumns: new[] { "State", "LicensePlate" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordOfSales_CarState_CarLicensePlate",
                table: "RecordOfSales",
                columns: new[] { "CarState", "CarLicensePlate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordOfSales");

            migrationBuilder.DropTable(
                name: "Cars1");
        }
    }
}
