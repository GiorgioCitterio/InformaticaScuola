using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreImpiegatiDipartimento.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dipartimenti",
                columns: table => new
                {
                    DipartimentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDip = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dipartimenti", x => x.DipartimentoId);
                });

            migrationBuilder.CreateTable(
                name: "Impiegati",
                columns: table => new
                {
                    ImpiegatoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cognome = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Stipendio = table.Column<double>(type: "REAL", nullable: false),
                    DipartimentoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impiegati", x => x.ImpiegatoId);
                    table.ForeignKey(
                        name: "FK_Impiegati_Dipartimenti_DipartimentoId",
                        column: x => x.DipartimentoId,
                        principalTable: "Dipartimenti",
                        principalColumn: "DipartimentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Impiegati_DipartimentoId",
                table: "Impiegati",
                column: "DipartimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Impiegati");

            migrationBuilder.DropTable(
                name: "Dipartimenti");
        }
    }
}
