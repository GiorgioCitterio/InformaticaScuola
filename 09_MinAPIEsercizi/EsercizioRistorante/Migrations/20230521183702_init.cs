using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EsercizioRistorante.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Chefs",
                columns: table => new
                {
                    ChefId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataDiNascita = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefs", x => x.ChefId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ristorantes",
                columns: table => new
                {
                    RistoranteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Città = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ristorantes", x => x.RistoranteId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Piattos",
                columns: table => new
                {
                    PiattoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomePiatto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Costo = table.Column<int>(type: "int", nullable: false),
                    RistoranteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piattos", x => x.PiattoId);
                    table.ForeignKey(
                        name: "FK_Piattos_Ristorantes_RistoranteId",
                        column: x => x.RistoranteId,
                        principalTable: "Ristorantes",
                        principalColumn: "RistoranteId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Portatas",
                columns: table => new
                {
                    ChefId = table.Column<int>(type: "int", nullable: false),
                    PiattoId = table.Column<int>(type: "int", nullable: false),
                    NumeroPorzioni = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portatas", x => new { x.PiattoId, x.ChefId });
                    table.ForeignKey(
                        name: "FK_Portatas_Chefs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Chefs",
                        principalColumn: "ChefId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Portatas_Piattos_PiattoId",
                        column: x => x.PiattoId,
                        principalTable: "Piattos",
                        principalColumn: "PiattoId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Chefs",
                columns: new[] { "ChefId", "DataDiNascita", "Nome" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 21, 18, 37, 2, 882, DateTimeKind.Utc).AddTicks(8972), "nome 1" },
                    { 2, new DateTime(2023, 5, 21, 18, 37, 2, 882, DateTimeKind.Utc).AddTicks(8975), "nome 2" },
                    { 3, new DateTime(2023, 5, 21, 18, 37, 2, 882, DateTimeKind.Utc).AddTicks(8976), "nome 3" }
                });

            migrationBuilder.InsertData(
                table: "Ristorantes",
                columns: new[] { "RistoranteId", "Città", "Nome" },
                values: new object[,]
                {
                    { 1, "milano", "nome 1" },
                    { 2, "roma", "nome 2" },
                    { 3, "napoli", "nome 3" }
                });

            migrationBuilder.InsertData(
                table: "Piattos",
                columns: new[] { "PiattoId", "Costo", "NomePiatto", "RistoranteId" },
                values: new object[,]
                {
                    { 1, 10, "piatto 1", 1 },
                    { 2, 20, "piatto 2", 2 },
                    { 3, 15, "piatto 3", 3 }
                });

            migrationBuilder.InsertData(
                table: "Portatas",
                columns: new[] { "ChefId", "PiattoId", "NumeroPorzioni" },
                values: new object[,]
                {
                    { 1, 1, 5 },
                    { 2, 2, 15 },
                    { 3, 3, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piattos_RistoranteId",
                table: "Piattos",
                column: "RistoranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Portatas_ChefId",
                table: "Portatas",
                column: "ChefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portatas");

            migrationBuilder.DropTable(
                name: "Chefs");

            migrationBuilder.DropTable(
                name: "Piattos");

            migrationBuilder.DropTable(
                name: "Ristorantes");
        }
    }
}
