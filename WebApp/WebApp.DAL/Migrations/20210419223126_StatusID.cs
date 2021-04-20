using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.DAL.Migrations
{
    public partial class StatusID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_AnimeStatus_StatusID",
                table: "Anime");

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "Anime",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_AnimeStatus_StatusID",
                table: "Anime",
                column: "StatusID",
                principalTable: "AnimeStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_AnimeStatus_StatusID",
                table: "Anime");

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "Anime",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_AnimeStatus_StatusID",
                table: "Anime",
                column: "StatusID",
                principalTable: "AnimeStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
