using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShips.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipGames_Games_UserGameId",
                table: "ShipGames");

            migrationBuilder.DropIndex(
                name: "IX_ShipGames_UserGameId",
                table: "ShipGames");

            migrationBuilder.CreateIndex(
                name: "IX_ShipGames_GameId",
                table: "ShipGames",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipGames_Games_GameId",
                table: "ShipGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipGames_Games_GameId",
                table: "ShipGames");

            migrationBuilder.DropIndex(
                name: "IX_ShipGames_GameId",
                table: "ShipGames");

            migrationBuilder.CreateIndex(
                name: "IX_ShipGames_UserGameId",
                table: "ShipGames",
                column: "UserGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipGames_Games_UserGameId",
                table: "ShipGames",
                column: "UserGameId",
                principalTable: "Games",
                principalColumn: "GameId");
        }
    }
}
