using Microsoft.EntityFrameworkCore.Migrations;

namespace WebChess.Migrations
{
    public partial class ChessGameMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "owner",
                table: "ChessGame");

            migrationBuilder.AddColumn<string>(
                name: "gameType",
                table: "ChessGame",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gameType",
                table: "ChessGame");

            migrationBuilder.AddColumn<int>(
                name: "owner",
                table: "ChessGame",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
