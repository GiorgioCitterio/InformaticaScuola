using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsercizioAuto.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assicurazione",
                columns: table => new
                {
                    AssicurazioneId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sede = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assicurazione", x => x.AssicurazioneId);
                });

            migrationBuilder.CreateTable(
                name: "Proprietario",
                columns: table => new
                {
                    ProprietarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cognome = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CittàDiResidenza = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietario", x => x.ProprietarioId);
                });

            migrationBuilder.CreateTable(
                name: "Auto",
                columns: table => new
                {
                    Targa = table.Column<string>(type: "TEXT", nullable: false),
                    Cilindrata = table.Column<double>(type: "REAL", nullable: false),
                    Potenza = table.Column<double>(type: "REAL", nullable: false),
                    ProprietarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssicurazioneId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auto", x => x.Targa);
                    table.ForeignKey(
                        name: "FK_Auto_Assicurazione_AssicurazioneId",
                        column: x => x.AssicurazioneId,
                        principalTable: "Assicurazione",
                        principalColumn: "AssicurazioneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auto_Proprietario_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietario",
                        principalColumn: "ProprietarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auto_AssicurazioneId",
                table: "Auto",
                column: "AssicurazioneId");

            migrationBuilder.CreateIndex(
                name: "IX_Auto_ProprietarioId",
                table: "Auto",
                column: "ProprietarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auto");

            migrationBuilder.DropTable(
                name: "Assicurazione");

            migrationBuilder.DropTable(
                name: "Proprietario");
        }
    }
}
