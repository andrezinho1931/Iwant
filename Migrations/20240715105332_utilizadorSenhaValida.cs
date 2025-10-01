using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CliSenhas2024.Migrations
{
    /// <inheritdoc />
    public partial class utilizadorSenhaValida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "TUtilizadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "TUtilizadores");
        }
    }
}
