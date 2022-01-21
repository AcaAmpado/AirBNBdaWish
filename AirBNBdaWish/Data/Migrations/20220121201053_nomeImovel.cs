using Microsoft.EntityFrameworkCore.Migrations;

namespace AirBNBdaWish.Data.Migrations
{
    public partial class nomeImovel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Imovel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Imovel");
        }
    }
}
