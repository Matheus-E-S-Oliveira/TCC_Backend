using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoEstruturaDasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_avalicao_BaseEntitys_Id",
                table: "avalicao");

            migrationBuilder.DropForeignKey(
                name: "FK_historico_BaseEntitys_Id",
                table: "historico");

            migrationBuilder.DropForeignKey(
                name: "FK_servico_BaseEntitys_Id",
                table: "servico");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_BaseEntitys_Id",
                table: "usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_servicos_avaliacoes_BaseEntitys_Id",
                table: "usuario_servicos_avaliacoes");

            migrationBuilder.DropTable(
                name: "BaseEntitys");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "usuario_servicos_avaliacoes",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "usuario_servicos_avaliacoes",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP(6)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "usuario",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "usuario",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP(6)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "servico",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "servico",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP(6)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "historico",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "historico",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP(6)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "avalicao",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "avalicao",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP(6)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Auditorias",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Auditorias",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "usuario_servicos_avaliacoes");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "usuario_servicos_avaliacoes");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "servico");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "servico");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "historico");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "historico");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "avalicao");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "avalicao");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Auditorias");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Auditorias");

            migrationBuilder.CreateTable(
                name: "BaseEntitys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntitys", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_avalicao_BaseEntitys_Id",
                table: "avalicao",
                column: "Id",
                principalTable: "BaseEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_historico_BaseEntitys_Id",
                table: "historico",
                column: "Id",
                principalTable: "BaseEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_servico_BaseEntitys_Id",
                table: "servico",
                column: "Id",
                principalTable: "BaseEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_BaseEntitys_Id",
                table: "usuario",
                column: "Id",
                principalTable: "BaseEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_servicos_avaliacoes_BaseEntitys_Id",
                table: "usuario_servicos_avaliacoes",
                column: "Id",
                principalTable: "BaseEntitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
