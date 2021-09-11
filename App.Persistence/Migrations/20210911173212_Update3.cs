using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Persistence.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CidadeId",
                table: "pessoa",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_CidadeId",
                table: "pessoa",
                column: "CidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoa_cidade_CidadeId",
                table: "pessoa",
                column: "CidadeId",
                principalTable: "cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pessoa_cidade_CidadeId",
                table: "pessoa");

            migrationBuilder.DropIndex(
                name: "IX_pessoa_CidadeId",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "pessoa");
        }
    }
}
