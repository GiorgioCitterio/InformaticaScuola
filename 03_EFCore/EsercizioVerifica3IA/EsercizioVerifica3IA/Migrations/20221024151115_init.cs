using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsercizioVerifica3IA.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scuderia",
                columns: table => new
                {
                    ScuderiaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeScuderia = table.Column<string>(type: "TEXT", nullable: false),
                    Nazionalità = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scuderia", x => x.ScuderiaId);
                });

            migrationBuilder.CreateTable(
                name: "Pilota",
                columns: table => new
                {
                    PilotaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", nullable: false),
                    ScuderiaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilota", x => x.PilotaId);
                    table.ForeignKey(
                        name: "FK_Pilota_Scuderia_ScuderiaId",
                        column: x => x.ScuderiaId,
                        principalTable: "Scuderia",
                        principalColumn: "ScuderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PuntiPiloti",
                columns: table => new
                {
                    PuntiPilotiId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PilotaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Punti = table.Column<int>(type: "INTEGER", nullable: false),
                    PosizioneInGara = table.Column<int>(type: "INTEGER", nullable: false),
                    DataGara = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntiPiloti", x => x.PuntiPilotiId);
                    table.ForeignKey(
                        name: "FK_PuntiPiloti_Pilota_PilotaId",
                        column: x => x.PilotaId,
                        principalTable: "Pilota",
                        principalColumn: "PilotaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pilota_ScuderiaId",
                table: "Pilota",
                column: "ScuderiaId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntiPiloti_PilotaId",
                table: "PuntiPiloti",
                column: "PilotaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PuntiPiloti");

            migrationBuilder.DropTable(
                name: "Pilota");

            migrationBuilder.DropTable(
                name: "Scuderia");
        }
    }
}
