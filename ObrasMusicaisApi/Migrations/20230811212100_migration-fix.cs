using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObrasMusicaisApi.Migrations
{
    public partial class migrationfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titulares_Titulares_TitularModelId",
                table: "Titulares");

            migrationBuilder.DropIndex(
                name: "IX_Titulares_TitularModelId",
                table: "Titulares");

            migrationBuilder.DropColumn(
                name: "TitularModelId",
                table: "Titulares");

            migrationBuilder.AddColumn<Guid>(
                name: "TitularModelId",
                table: "Obras",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Obras_TitularModelId",
                table: "Obras",
                column: "TitularModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Titulares_TitularModelId",
                table: "Obras",
                column: "TitularModelId",
                principalTable: "Titulares",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Titulares_TitularModelId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_TitularModelId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "TitularModelId",
                table: "Obras");

            migrationBuilder.AddColumn<Guid>(
                name: "TitularModelId",
                table: "Titulares",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Titulares_TitularModelId",
                table: "Titulares",
                column: "TitularModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Titulares_Titulares_TitularModelId",
                table: "Titulares",
                column: "TitularModelId",
                principalTable: "Titulares",
                principalColumn: "Id");
        }
    }
}
