using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CliSenhas2024.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarRelacionamentoProdutoUtilizador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TProdutos_IdUtilizador",
                table: "TProdutos",
                column: "IdUtilizador");

            migrationBuilder.AddForeignKey(
                name: "FK_TProdutos_TUtilizadores_IdUtilizador",
                table: "TProdutos",
                column: "IdUtilizador",
                principalTable: "TUtilizadores",
                principalColumn: "IdUtilizador",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TProdutos_TUtilizadores_IdUtilizador",
                table: "TProdutos");

            migrationBuilder.DropIndex(
                name: "IX_TProdutos_IdUtilizador",
                table: "TProdutos");
        }
    }
}
