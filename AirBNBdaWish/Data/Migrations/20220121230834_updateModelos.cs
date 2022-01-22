using Microsoft.EntityFrameworkCore.Migrations;

namespace AirBNBdaWish.Data.Migrations
{
    public partial class updateModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoCliente_Gestor_GestorId",
                table: "AvaliacaoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoCliente_Reserva_ReservaId",
                table: "AvaliacaoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoImovel_Reserva_ReservaId",
                table: "AvaliacaoImovel");

            migrationBuilder.DropForeignKey(
                name: "FK_Imovel_Funcionario_FuncionarioId",
                table: "Imovel");

            migrationBuilder.DropForeignKey(
                name: "FK_Imovel_Gestor_GestorId",

                table: "Imovel");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Imovel_ImovelId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdImovel",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdFuncionario",
                table: "Imovel");

            migrationBuilder.DropColumn(
                name: "IdGestor",
                table: "Imovel");

            migrationBuilder.DropColumn(
                name: "IdReserva",
                table: "AvaliacaoImovel");

            migrationBuilder.DropColumn(
                name: "IdGestor",
                table: "AvaliacaoCliente");

            migrationBuilder.DropColumn(
                name: "IdReserva",
                table: "AvaliacaoCliente");

            migrationBuilder.AlterColumn<int>(
                name: "ImovelId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GestorId",
                table: "Imovel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Imovel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReservaId",
                table: "AvaliacaoImovel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReservaId",
                table: "AvaliacaoCliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GestorId",
                table: "AvaliacaoCliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoCliente_Gestor_GestorId",
                table: "AvaliacaoCliente",
                column: "GestorId",
                principalTable: "Gestor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoCliente_Reserva_ReservaId",
                table: "AvaliacaoCliente",
                column: "ReservaId",
                principalTable: "Reserva",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoImovel_Reserva_ReservaId",
                table: "AvaliacaoImovel",
                column: "ReservaId",
                principalTable: "Reserva",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imovel_Funcionario_FuncionarioId",
                table: "Imovel",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imovel_Gestor_GestorId",
                table: "Imovel",
                column: "GestorId",
                principalTable: "Gestor",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Imovel_ImovelId",
                table: "Reserva",
                column: "ImovelId",
                principalTable: "Imovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoCliente_Gestor_GestorId",
                table: "AvaliacaoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoCliente_Reserva_ReservaId",
                table: "AvaliacaoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoImovel_Reserva_ReservaId",
                table: "AvaliacaoImovel");

            migrationBuilder.DropForeignKey(
                name: "FK_Imovel_Funcionario_FuncionarioId",
                table: "Imovel");

            migrationBuilder.DropForeignKey(
                name: "FK_Imovel_Gestor_GestorId",
                table: "Imovel");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Imovel_ImovelId",
                table: "Reserva");

            migrationBuilder.AlterColumn<int>(
                name: "ImovelId",
                table: "Reserva",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Reserva",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdImovel",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "GestorId",
                table: "Imovel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Imovel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdFuncionario",
                table: "Imovel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdGestor",
                table: "Imovel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReservaId",
                table: "AvaliacaoImovel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdReserva",
                table: "AvaliacaoImovel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReservaId",
                table: "AvaliacaoCliente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GestorId",
                table: "AvaliacaoCliente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdGestor",
                table: "AvaliacaoCliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdReserva",
                table: "AvaliacaoCliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoCliente_Gestor_GestorId",
                table: "AvaliacaoCliente",
                column: "GestorId",
                principalTable: "Gestor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoCliente_Reserva_ReservaId",
                table: "AvaliacaoCliente",
                column: "ReservaId",
                principalTable: "Reserva",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoImovel_Reserva_ReservaId",
                table: "AvaliacaoImovel",
                column: "ReservaId",
                principalTable: "Reserva",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imovel_Funcionario_FuncionarioId",
                table: "Imovel",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imovel_Gestor_GestorId",
                table: "Imovel",
                column: "GestorId",
                principalTable: "Gestor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Imovel_ImovelId",
                table: "Reserva",
                column: "ImovelId",
                principalTable: "Imovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
