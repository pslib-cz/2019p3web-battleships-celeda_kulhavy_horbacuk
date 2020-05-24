using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShips.Migrations
{
    public partial class AllInOneMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<Guid>(nullable: false),
                    MaxPlayers = table.Column<int>(nullable: false),
                    PlayerOnTurnId = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    GameState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_AspNetUsers_PlayerOnTurnId",
                        column: x => x.PlayerOnTurnId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    PlayerState = table.Column<int>(nullable: false),
                    ShipId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                    table.ForeignKey(
                        name: "FK_UserGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShipGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShipId = table.Column<int>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false),
                    UserGameId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                });

            migrationBuilder.CreateTable(
                name: "NavyBattlePieces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PosX = table.Column<int>(nullable: false),
                    PosY = table.Column<int>(nullable: false),
                    UserGameId = table.Column<int>(nullable: false),
                    ShipId = table.Column<int>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    PieceState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavyBattlePieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavyBattlePieces_UserGames_UserGameId",
                        column: x => x.UserGameId,
                        principalTable: "UserGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipPieces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PosX = table.Column<int>(nullable: false),
                    PosY = table.Column<int>(nullable: false),
                    IsMargin = table.Column<bool>(nullable: false),
                    ShipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipPieces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipUsersPlaced",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShipId = table.Column<int>(nullable: false),
                    UserGameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipUsersPlaced", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipUsersPlaced_UserGames_UserGameId",
                        column: x => x.UserGameId,
                        principalTable: "UserGames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Count = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShipUserPlacedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_ShipUsersPlaced_ShipUserPlacedId",
                        column: x => x.ShipUserPlacedId,
                        principalTable: "ShipUsersPlaced",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "TOMAS123", 0, "399c8dca-6d06-4caf-b0f8-b148981aa02c", "tomas.kulhavy@pslib.cz", true, false, null, "TOMAS.KULHAVY@PSLIB.CZ", "TOMAS.KULHAVY@PSLIB.CZ", "AQAAAAEAACcQAAAAELrtxc2ZElC0SgVkTGaGwShMO8W0kUkrhEHzLZQw3yVr027Gu8/Ks/ESp4Jjsejw0Q==", null, false, "", false, "tomas.kulhavy@pslib.cz" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "MARTIN123", 0, "0898432e-9949-472d-b767-5d3fea32b152", "martin.celeda@pslib.cz", true, false, null, "MARTIN.CELEDA@PSLIB.CZ", "MARTIN.CELEDA@PSLIB.CZ", "AQAAAAEAACcQAAAAELh322TIFc7+p3ylujOGLIKpgRYKCbwrSSYgGjAunIbBTb1w4PJDpT3YJV+/mda1Tw==", null, false, "", false, "martin.celeda@pslib.cz" });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Count", "Name", "ShipUserPlacedId" },
                values: new object[] { 1, 0, "Torpédoborec", null });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Count", "Name", "ShipUserPlacedId" },
                values: new object[] { 2, 0, "Ponorka", null });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Count", "Name", "ShipUserPlacedId" },
                values: new object[] { 3, 0, "Křižník", null });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Count", "Name", "ShipUserPlacedId" },
                values: new object[] { 4, 0, "Bitevní loď", null });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Count", "Name", "ShipUserPlacedId" },
                values: new object[] { 5, 0, "Letadlová loď", null });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "GameState", "MaxPlayers", "OwnerId", "PlayerOnTurnId" },
                values: new object[] { new Guid("23e8e6dc-11f3-4899-b977-445bd8cfbcb1"), 0, 2, "TOMAS123", "MARTIN123" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "GameState", "MaxPlayers", "OwnerId", "PlayerOnTurnId" },
                values: new object[] { new Guid("ee7c70ca-357b-4874-8cd9-81c1fc39977f"), 0, 2, "MARTIN123", "TOMAS123" });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "Id", "GameId", "PlayerState", "ShipId", "UserId" },
                values: new object[] { 1, new Guid("23e8e6dc-11f3-4899-b977-445bd8cfbcb1"), 0, null, "TOMAS123" });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "Id", "GameId", "PlayerState", "ShipId", "UserId" },
                values: new object[] { 2, new Guid("23e8e6dc-11f3-4899-b977-445bd8cfbcb1"), 0, null, "MARTIN123" });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "Id", "GameId", "PlayerState", "ShipId", "UserId" },
                values: new object[] { 3, new Guid("ee7c70ca-357b-4874-8cd9-81c1fc39977f"), 0, null, "TOMAS123" });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "Id", "GameId", "PlayerState", "ShipId", "UserId" },
                values: new object[] { 4, new Guid("ee7c70ca-357b-4874-8cd9-81c1fc39977f"), 0, null, "MARTIN123" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_OwnerId",
                table: "Games",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerOnTurnId",
                table: "Games",
                column: "PlayerOnTurnId");

            migrationBuilder.CreateIndex(
                name: "IX_NavyBattlePieces_ShipId",
                table: "NavyBattlePieces",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_NavyBattlePieces_UserGameId",
                table: "NavyBattlePieces",
                column: "UserGameId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipGames_GameId",
                table: "ShipGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipGames_ShipId",
                table: "ShipGames",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipPieces_ShipId",
                table: "ShipPieces",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipUserPlacedId",
                table: "Ships",
                column: "ShipUserPlacedId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipUsersPlaced_ShipId",
                table: "ShipUsersPlaced",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipUsersPlaced_UserGameId",
                table: "ShipUsersPlaced",
                column: "UserGameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_GameId",
                table: "UserGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_ShipId",
                table: "UserGames",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_UserId",
                table: "UserGames",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGames_Ships_ShipId",
                table: "UserGames",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipGames_Ships_ShipId",
                table: "ShipGames",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NavyBattlePieces_Ships_ShipId",
                table: "NavyBattlePieces",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipPieces_Ships_ShipId",
                table: "ShipPieces",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipUsersPlaced_Ships_ShipId",
                table: "ShipUsersPlaced",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_OwnerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_PlayerOnTurnId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_AspNetUsers_UserId",
                table: "UserGames");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipUsersPlaced_Ships_ShipId",
                table: "ShipUsersPlaced");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_Ships_ShipId",
                table: "UserGames");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "NavyBattlePieces");

            migrationBuilder.DropTable(
                name: "ShipGames");

            migrationBuilder.DropTable(
                name: "ShipPieces");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "ShipUsersPlaced");

            migrationBuilder.DropTable(
                name: "UserGames");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
