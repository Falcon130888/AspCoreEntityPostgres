using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AspCoreEntityPostgres.Migrations
{
    public partial class memocopy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "MemoCopies",
                columns: table => new
                {
                    IdMemoCopy = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMemo = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoCopies", x => x.IdMemoCopy);
                    table.ForeignKey(
                        name: "FK_MemoCopies_Memos_IdMemo",
                        column: x => x.IdMemo,
                        principalTable: "Memos",
                        principalColumn: "IdMemo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemoCopies_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemoCopies_IdMemo",
                table: "MemoCopies",
                column: "IdMemo");

            migrationBuilder.CreateIndex(
                name: "IX_MemoCopies_IdUser",
                table: "MemoCopies",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemoCopies");
        }
    }
}
