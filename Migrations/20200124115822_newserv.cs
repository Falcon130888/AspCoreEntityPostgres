using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AspCoreEntityPostgres.Migrations
{
    public partial class newserv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Otdels",
                columns: table => new
                {
                    IdOtdel = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameOtdel = table.Column<string>(nullable: true),
                    LeadOtdel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otdels", x => x.IdOtdel);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    IdStatus = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    IdTask = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(nullable: false),
                    NameTask = table.Column<string>(nullable: true),
                    DateBegin = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    TypeTask = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.IdTask);
                });

            migrationBuilder.CreateTable(
                name: "Dolzhs",
                columns: table => new
                {
                    IdDolzh = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameDolzh = table.Column<string>(nullable: true),
                    IdOtdel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dolzhs", x => x.IdDolzh);
                    table.ForeignKey(
                        name: "FK_Dolzhs_Otdels_IdOtdel",
                        column: x => x.IdOtdel,
                        principalTable: "Otdels",
                        principalColumn: "IdOtdel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserFIO = table.Column<string>(nullable: true),
                    UserAdLogin = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true),
                    UserLogin = table.Column<string>(nullable: true),
                    UserConf = table.Column<int>(nullable: false),
                    IdOtdel = table.Column<int>(nullable: false),
                    IdDolzh = table.Column<int>(nullable: false),
                    IdRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Dolzhs_IdDolzh",
                        column: x => x.IdDolzh,
                        principalTable: "Dolzhs",
                        principalColumn: "IdDolzh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Otdels_IdOtdel",
                        column: x => x.IdOtdel,
                        principalTable: "Otdels",
                        principalColumn: "IdOtdel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memos",
                columns: table => new
                {
                    IdMemo = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Thema = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IdStatus = table.Column<int>(nullable: false),
                    IdUserTo = table.Column<int>(nullable: false),
                    IdUserExecutor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memos", x => x.IdMemo);
                    table.ForeignKey(
                        name: "FK_Memos_Statuses_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "Statuses",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memos_Users_IdUserExecutor",
                        column: x => x.IdUserExecutor,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Memos_Users_IdUserTo",
                        column: x => x.IdUserTo,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CopyMemos",
                columns: table => new
                {
                    IdCopyMemo = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMemo = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopyMemos", x => x.IdCopyMemo);
                    table.ForeignKey(
                        name: "FK_CopyMemos_Memos_IdMemo",
                        column: x => x.IdMemo,
                        principalTable: "Memos",
                        principalColumn: "IdMemo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CopyMemos_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemoFiles",
                columns: table => new
                {
                    IdMemoFile = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMemo = table.Column<int>(nullable: false),
                    Format = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoFiles", x => x.IdMemoFile);
                    table.ForeignKey(
                        name: "FK_MemoFiles_Memos_IdMemo",
                        column: x => x.IdMemo,
                        principalTable: "Memos",
                        principalColumn: "IdMemo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CopyMemos_IdMemo",
                table: "CopyMemos",
                column: "IdMemo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CopyMemos_IdUser",
                table: "CopyMemos",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Dolzhs_IdOtdel",
                table: "Dolzhs",
                column: "IdOtdel");

            migrationBuilder.CreateIndex(
                name: "IX_MemoFiles_IdMemo",
                table: "MemoFiles",
                column: "IdMemo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Memos_IdStatus",
                table: "Memos",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Memos_IdUserExecutor",
                table: "Memos",
                column: "IdUserExecutor");

            migrationBuilder.CreateIndex(
                name: "IX_Memos_IdUserTo",
                table: "Memos",
                column: "IdUserTo");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdDolzh",
                table: "Users",
                column: "IdDolzh");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdOtdel",
                table: "Users",
                column: "IdOtdel");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CopyMemos");

            migrationBuilder.DropTable(
                name: "MemoFiles");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Memos");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Dolzhs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Otdels");
        }
    }
}
