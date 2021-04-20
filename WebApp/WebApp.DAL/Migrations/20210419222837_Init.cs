using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimeStatus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgressionStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    StatusID = table.Column<int>(nullable: true),
                    AgeRestriction = table.Column<int>(nullable: false),
                    EpisodesAmount = table.Column<int>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Studio = table.Column<string>(nullable: false),
                    DubTeam = table.Column<string>(nullable: true),
                    LinkToWatch = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Anime_AnimeStatus_StatusID",
                        column: x => x.StatusID,
                        principalTable: "AnimeStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_StatusID",
                table: "Anime",
                column: "StatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anime");

            migrationBuilder.DropTable(
                name: "AnimeStatus");
        }
    }
}
