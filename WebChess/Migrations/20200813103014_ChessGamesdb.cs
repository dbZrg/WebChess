using Microsoft.EntityFrameworkCore.Migrations;

namespace WebChess.Migrations
{
    public partial class ChessGamesdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChessGame",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    owner = table.Column<int>(nullable: false),
                    playerWhite = table.Column<string>(nullable: true),
                    playerBlack = table.Column<string>(nullable: true),
                    pgn = table.Column<string>(nullable: true),
                    fens = table.Column<string>(nullable: true),
                    winner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChessGame", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChessGame");
        }
    }
}
