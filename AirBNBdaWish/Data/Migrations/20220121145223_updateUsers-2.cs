using Microsoft.EntityFrameworkCore.Migrations;

namespace AirBNBdaWish.Data.Migrations
{
    public partial class updateUsers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Gestor");

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUtilizador",
                table: "Gestor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUtilizador",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUtilizador",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
