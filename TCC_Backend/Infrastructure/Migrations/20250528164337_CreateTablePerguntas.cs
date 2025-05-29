using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablePerguntas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pergunta");

            migrationBuilder.CreateTable(
                name: "perguntas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdServico = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_perguntas_servico_IdServico",
                        column: x => x.IdServico,
                        principalTable: "servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_perguntas_IdServico",
                table: "perguntas",
                column: "IdServico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perguntas");

            migrationBuilder.CreateTable(
                name: "Pergunta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdServico = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pergunta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pergunta_servico_IdServico",
                        column: x => x.IdServico,
                        principalTable: "servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pergunta_IdServico",
                table: "Pergunta",
                column: "IdServico");
        }
    }
}
