using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telefone",
                table: "pessoa",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cpf",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "telefone",
                table: "pessoa");
        }
    }
}
