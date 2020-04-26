using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShips.Migrations
{
    public partial class Board : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameBoardId",
                table: "NavyBattlePieces",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameBoards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBoards", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NavyBattlePieces_GameBoardId",
                table: "NavyBattlePieces",
                column: "GameBoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_NavyBattlePieces_GameBoards_GameBoardId",
                table: "NavyBattlePieces",
                column: "GameBoardId",
                principalTable: "GameBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NavyBattlePieces_GameBoards_GameBoardId",
                table: "NavyBattlePieces");

            migrationBuilder.DropTable(
                name: "GameBoards");

            migrationBuilder.DropIndex(
                name: "IX_NavyBattlePieces_GameBoardId",
                table: "NavyBattlePieces");

            migrationBuilder.DropColumn(
                name: "GameBoardId",
                table: "NavyBattlePieces");
        }
    }
}
