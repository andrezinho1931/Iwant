using Microsoft.EntityFrameworkCore.Migrations;



#nullable disable

namespace CliSenhas2024.Migrations
{
    /// <inheritdoc />
    public partial class D : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado_conta",
                table: "TUtilizadores");

            migrationBuilder.DropColumn(
                name: "Tipo_conta",
                table: "TUtilizadores");

            migrationBuilder.DropColumn(
                name: "Token_verificacao",
                table: "TUtilizadores");

            migrationBuilder.AddColumn<int>(
                name: "Perfil",
                table: "TUtilizadores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "TUtilizadores");

            migrationBuilder.AddColumn<string>(
                name: "Estado_conta",
                table: "TUtilizadores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo_conta",
                table: "TUtilizadores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token_verificacao",
                table: "TUtilizadores",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
