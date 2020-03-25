using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShips.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NavyBattlePieces_UserGames_UserGameId",
                table: "NavyBattlePieces");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipGames_UserGames_GameId",
                table: "ShipGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipUsersPlaced_ShipUserPlacedShipUserId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipUsersPlaced_UserGames_UserGameId",
                table: "ShipUsersPlaced");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipUsersPlaced_AspNetUsers_UserId",
                table: "ShipUsersPlaced");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGames",
                table: "UserGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShipUsersPlaced",
                table: "ShipUsersPlaced");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ShipUserPlacedShipUserId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_ShipGames_GameId",
                table: "ShipGames");

            migrationBuilder.DropColumn(
                name: "UserGameId",
                table: "UserGames");

            migrationBuilder.DropColumn(
                name: "ShipUserId",
                table: "ShipUsersPlaced");

            migrationBuilder.DropColumn(
                name: "ShipUserPlacedShipUserId",
                table: "Ships");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserGames",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "UserGameId",
                table: "ShipUsersPlaced",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ShipUsersPlaced",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ShipUserPlacedId",
                table: "Ships",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserGameId",
                table: "ShipGames",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserGameId",
                table: "NavyBattlePieces",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGames",
                table: "UserGames",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShipUsersPlaced",
                table: "ShipUsersPlaced",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipUserPlacedId",
                table: "Ships",
                column: "ShipUserPlacedId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipGames_UserGameId",
                table: "ShipGames",
                column: "UserGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_NavyBattlePieces_UserGames_UserGameId",
                table: "NavyBattlePieces",
                column: "UserGameId",
                principalTable: "UserGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipGames_Games_UserGameId",
                table: "ShipGames",
                column: "UserGameId",
                principalTable: "Games",
                principalColumn: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipUsersPlaced_ShipUserPlacedId",
                table: "Ships",
                column: "ShipUserPlacedId",
                principalTable: "ShipUsersPlaced",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipUsersPlaced_UserGames_UserGameId",
                table: "ShipUsersPlaced",
                column: "UserGameId",
                principalTable: "UserGames",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipUsersPlaced_AspNetUsers_UserId",
                table: "ShipUsersPlaced",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NavyBattlePieces_UserGames_UserGameId",
                table: "NavyBattlePieces");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipGames_Games_UserGameId",
                table: "ShipGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipUsersPlaced_ShipUserPlacedId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipUsersPlaced_UserGames_UserGameId",
                table: "ShipUsersPlaced");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipUsersPlaced_AspNetUsers_UserId",
                table: "ShipUsersPlaced");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGames",
                table: "UserGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShipUsersPlaced",
                table: "ShipUsersPlaced");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ShipUserPlacedId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_ShipGames_UserGameId",
                table: "ShipGames");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserGames");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShipUsersPlaced");

            migrationBuilder.DropColumn(
                name: "ShipUserPlacedId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "UserGameId",
                table: "ShipGames");

            migrationBuilder.AddColumn<Guid>(
                name: "UserGameId",
                table: "UserGames",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserGameId",
                table: "ShipUsersPlaced",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ShipUserId",
                table: "ShipUsersPlaced",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ShipUserPlacedShipUserId",
                table: "Ships",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserGameId",
                table: "NavyBattlePieces",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGames",
                table: "UserGames",
                column: "UserGameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShipUsersPlaced",
                table: "ShipUsersPlaced",
                column: "ShipUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipUserPlacedShipUserId",
                table: "Ships",
                column: "ShipUserPlacedShipUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipGames_GameId",
                table: "ShipGames",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_NavyBattlePieces_UserGames_UserGameId",
                table: "NavyBattlePieces",
                column: "UserGameId",
                principalTable: "UserGames",
                principalColumn: "UserGameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipGames_UserGames_GameId",
                table: "ShipGames",
                column: "GameId",
                principalTable: "UserGames",
                principalColumn: "UserGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipUsersPlaced_ShipUserPlacedShipUserId",
                table: "Ships",
                column: "ShipUserPlacedShipUserId",
                principalTable: "ShipUsersPlaced",
                principalColumn: "ShipUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipUsersPlaced_UserGames_UserGameId",
                table: "ShipUsersPlaced",
                column: "UserGameId",
                principalTable: "UserGames",
                principalColumn: "UserGameId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipUsersPlaced_AspNetUsers_UserId",
                table: "ShipUsersPlaced",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
