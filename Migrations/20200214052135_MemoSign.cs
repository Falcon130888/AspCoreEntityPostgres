using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AspCoreEntityPostgres.Migrations
{
    public partial class MemoSign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemoSignatories",
                columns: table => new
                {
                    IdMemoSignatory = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sign = table.Column<int>(nullable: false),
                    IdMemo = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    IdUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoSignatories", x => x.IdMemoSignatory);
                    table.ForeignKey(
                        name: "FK_MemoSignatories_Memos_IdMemo",
                        column: x => x.IdMemo,
                        principalTable: "Memos",
                        principalColumn: "IdMemo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemoSignatories_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemoSignatories_IdMemo",
                table: "MemoSignatories",
                column: "IdMemo");

            migrationBuilder.CreateIndex(
                name: "IX_MemoSignatories_IdUser",
                table: "MemoSignatories",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemoSignatories");
        }
    }
}
