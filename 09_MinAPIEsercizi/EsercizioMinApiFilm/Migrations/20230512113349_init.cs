using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EsercizioMinApiFilm.Migrations
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
                name: "Cinemas",
                columns: table => new
                {
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Indirizzo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Città = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.CinemaId);
                })
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

            migrationBuilder.CreateTable(
                name: "Proieziones",
                columns: table => new
                {
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ora = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proieziones", x => new { x.CinemaId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_Proieziones_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "CinemaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proieziones_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "CinemaId", "Città", "Indirizzo", "Nome" },
                values: new object[,]
                {
                    { 1, "città1", "indirizzo1", "nome1" },
                    { 2, "città2", "indirizzo2", "nome2" },
                    { 3, "città3", "indirizzo3", "nome3" }
                });

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
                    { 1, new DateTime(2023, 5, 12, 13, 33, 49, 688, DateTimeKind.Local).AddTicks(8369), 180, 1, "c" },
                    { 2, new DateTime(2023, 5, 12, 11, 33, 49, 688, DateTimeKind.Utc).AddTicks(8429), 300, 2, "d" },
                    { 3, new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 700, 2, "e" },
                    { 4, new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 60, 3, "j" }
                });

            migrationBuilder.InsertData(
                table: "Proieziones",
                columns: new[] { "CinemaId", "FilmId", "Data", "Ora" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 5, 12, 13, 33, 49, 688, DateTimeKind.Local).AddTicks(8495), 4 },
                    { 1, 3, new DateTime(2023, 5, 12, 13, 33, 49, 688, DateTimeKind.Local).AddTicks(8505), 20 },
                    { 2, 2, new DateTime(2023, 5, 12, 13, 33, 49, 688, DateTimeKind.Local).AddTicks(8502), 15 },
                    { 3, 1, new DateTime(2023, 5, 12, 13, 33, 49, 688, DateTimeKind.Local).AddTicks(8509), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_RegistaId",
                table: "Films",
                column: "RegistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proieziones_FilmId",
                table: "Proieziones",
                column: "FilmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proieziones");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Registas");
        }
    }
}
