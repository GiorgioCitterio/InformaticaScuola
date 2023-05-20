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
                    PiattoId = table.Column<int>(type: "int", nullable: false),
                    NomePiatto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Costo = table.Column<int>(type: "int", nullable: false),
                    RistoranteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piattos", x => x.PiattoId);
                    table.ForeignKey(
                        name: "FK_Piattos_Ristorantes_PiattoId",
                        column: x => x.PiattoId,
                        principalTable: "Ristorantes",
                        principalColumn: "RistoranteId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piattos");

            migrationBuilder.DropTable(
                name: "Ristorantes");
        }
    }
}
