using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarTabelaDeServicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_avalicao_servico_IdServico",
                table: "avalicao");

            migrationBuilder.DropForeignKey(
                name: "FK_historico_servico_IdServico",
                table: "historico");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_servicos_avaliacoes_servico_ServicoId",
                table: "usuario_servicos_avaliacoes");

            migrationBuilder.RenameColumn(
                name: "NumeroDeAvalicoes",
                table: "servico",
                newName: "NumeroDeAvaliacoes");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "servico",
                type: "LongText",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Localizacao",
                table: "servico",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UrlSite",
                table: "servico",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pergunta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdServico = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_avalicao_servico_IdServico",
                table: "avalicao",
                column: "IdServico",
                principalTable: "servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_historico_servico_IdServico",
                table: "historico",
                column: "IdServico",
                principalTable: "servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_servicos_avaliacoes_servico_ServicoId",
                table: "usuario_servicos_avaliacoes",
                column: "ServicoId",
                principalTable: "servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_avalicao_servico_IdServico",
                table: "avalicao");

            migrationBuilder.DropForeignKey(
                name: "FK_historico_servico_IdServico",
                table: "historico");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_servicos_avaliacoes_servico_ServicoId",
                table: "usuario_servicos_avaliacoes");

            migrationBuilder.DropTable(
                name: "Pergunta");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "servico");

            migrationBuilder.DropColumn(
                name: "Localizacao",
                table: "servico");

            migrationBuilder.DropColumn(
                name: "UrlSite",
                table: "servico");

            migrationBuilder.RenameColumn(
                name: "NumeroDeAvaliacoes",
                table: "servico",
                newName: "NumeroDeAvalicoes");

            migrationBuilder.AddForeignKey(
                name: "FK_avalicao_servico_IdServico",
                table: "avalicao",
                column: "IdServico",
                principalTable: "servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_historico_servico_IdServico",
                table: "historico",
                column: "IdServico",
                principalTable: "servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_servicos_avaliacoes_servico_ServicoId",
                table: "usuario_servicos_avaliacoes",
                column: "ServicoId",
                principalTable: "servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
