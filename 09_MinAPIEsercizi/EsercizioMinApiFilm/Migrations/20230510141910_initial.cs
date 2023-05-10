using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EsercizioMinApiFilm.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Registas",
                columns: table => new
                {
                    RegistaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cognome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nazionalità = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registas", x => x.RegistaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titolo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataDiProduzione = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RegistaId = table.Column<int>(type: "int", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmId);
                    table.ForeignKey(
                        name: "FK_Films_Registas_RegistaId",
                        column: x => x.RegistaId,
                        principalTable: "Registas",
                        principalColumn: "RegistaId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Registas",
                columns: new[] { "RegistaId", "Cognome", "Nazionalità", "Nome" },
                values: new object[,]
                {
                    { 1, "a", "IT", "b" },
                    { 2, "f", "IT", "g" },
                    { 3, "h", "IT", "i" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "FilmId", "DataDiProduzione", "Durata", "RegistaId", "Titolo" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 10, 16, 19, 10, 623, DateTimeKind.Local).AddTicks(3832), 180, 1, "c" },
                    { 2, new DateTime(2023, 5, 10, 14, 19, 10, 623, DateTimeKind.Utc).AddTicks(3880), 300, 2, "d" },
                    { 3, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), 700, 2, "e" },
                    { 4, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), 60, 3, "j" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_RegistaId",
                table: "Films",
                column: "RegistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Registas");
        }
    }
}
