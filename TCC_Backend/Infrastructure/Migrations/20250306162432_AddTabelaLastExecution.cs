using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelaLastExecution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "usuario",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "usuario");
        }
    }
}
