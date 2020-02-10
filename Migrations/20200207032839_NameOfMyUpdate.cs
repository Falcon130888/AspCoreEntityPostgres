using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AspCoreEntityPostgres.Migrations
{
    public partial class NameOfMyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "IdLeadOtdel",
                table: "Otdels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdUser",
                table: "Users",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Otdels_Users_IdLeadOtdel",
                table: "Otdels",
                column: "IdLeadOtdel",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeadOtdel",
                table: "Otdels");
        }
    }
}
