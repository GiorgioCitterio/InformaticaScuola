using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Università.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorsoLaurea",
                columns: table => new
                {
                    CorsoLaureaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoLaurea = table.Column<string>(type: "TEXT", nullable: false),
                    Facoltà = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsoLaurea", x => x.CorsoLaureaId);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    CodDocente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", nullable: false),
                    Dipartimento = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.CodDocente);
                });

            migrationBuilder.CreateTable(
                name: "Studente",
                columns: table => new
                {
                    Matricola = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", nullable: false),
                    CorsoLaureaId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnnoDiNascita = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studente", x => x.Matricola);
                    table.ForeignKey(
                        name: "FK_Studente_CorsoLaurea_CorsoLaureaId",
                        column: x => x.CorsoLaureaId,
                        principalTable: "CorsoLaurea",
                        principalColumn: "CorsoLaureaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Corso",
                columns: table => new
                {
                    CodiceCorso = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CodDocente = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corso", x => x.CodiceCorso);
                    table.ForeignKey(
                        name: "FK_Corso_Docente_CodDocente",
                        column: x => x.CodDocente,
                        principalTable: "Docente",
                        principalColumn: "CodDocente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frequenta",
                columns: table => new
                {
                    Matricola = table.Column<int>(type: "INTEGER", nullable: false),
                    CodCorso = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequenta", x => new { x.Matricola, x.CodCorso });
                    table.ForeignKey(
                        name: "FK_Frequenta_Corso_CodCorso",
                        column: x => x.CodCorso,
                        principalTable: "Corso",
                        principalColumn: "CodiceCorso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frequenta_Studente_Matricola",
                        column: x => x.Matricola,
                        principalTable: "Studente",
                        principalColumn: "Matricola",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corso_CodDocente",
                table: "Corso",
                column: "CodDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Frequenta_CodCorso",
                table: "Frequenta",
                column: "CodCorso");

            migrationBuilder.CreateIndex(
                name: "IX_Studente_CorsoLaureaId",
                table: "Studente",
                column: "CorsoLaureaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frequenta");

            migrationBuilder.DropTable(
                name: "Corso");

            migrationBuilder.DropTable(
                name: "Studente");

            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "CorsoLaurea");
        }
    }
}
