using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObrasMusicaisApi.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titulares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitularModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titulares_Titulares_TitularModelId",
                        column: x => x.TitularModelId,
                        principalTable: "Titulares",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Titulares_TitularModelId",
                table: "Titulares",
                column: "TitularModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Titulares");
        }
    }
}
