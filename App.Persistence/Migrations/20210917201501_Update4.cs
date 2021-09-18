using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UF",
                table: "cidade",
                newName: "Uf");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "cidade",
                newName: "Cep");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Uf",
                table: "cidade",
                newName: "UF");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "cidade",
                newName: "CEP");
        }
    }
}
