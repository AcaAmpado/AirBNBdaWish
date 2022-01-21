using Microsoft.EntityFrameworkCore.Migrations;

namespace AirBNBdaWish.Data.Migrations
{
    public partial class updateUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUtilizador",
                table: "Gestor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UtilizadorId",
                table: "Gestor",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUtilizador",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UtilizadorId",
                table: "Funcionario",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUtilizador",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UtilizadorId",
                table: "Cliente",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gestor_UtilizadorId",
                table: "Gestor",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_UtilizadorId",
                table: "Funcionario",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UtilizadorId",
                table: "Cliente",
                column: "UtilizadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_AspNetUsers_UtilizadorId",
                table: "Cliente",
                column: "UtilizadorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_AspNetUsers_UtilizadorId",
                table: "Funcionario",
                column: "UtilizadorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gestor_AspNetUsers_UtilizadorId",
                table: "Gestor",
                column: "UtilizadorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_AspNetUsers_UtilizadorId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_AspNetUsers_UtilizadorId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Gestor_AspNetUsers_UtilizadorId",
                table: "Gestor");

            migrationBuilder.DropIndex(
                name: "IX_Gestor_UtilizadorId",
                table: "Gestor");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_UtilizadorId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_UtilizadorId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Gestor");

            migrationBuilder.DropColumn(
                name: "UtilizadorId",
                table: "Gestor");

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "UtilizadorId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UtilizadorId",
                table: "Cliente");
        }
    }
}
