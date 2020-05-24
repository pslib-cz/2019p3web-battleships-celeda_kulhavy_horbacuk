using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<ShipGame> ShipGames { get; set; }
        public DbSet<ShipPiece> ShipPieces { get; set; }
        public DbSet<ShipUserPlaced> ShipUsersPlaced { get; set; }
        public DbSet<NavyBattlePiece> NavyBattlePieces { get; set; }
        public DbSet<User> IdentityUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 1, Name = "Torpédoborec" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 2, Name = "Ponorka" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 3, Name = "Křižník" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 4, Name = "Bitevní loď" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 5, Name = "Letadlová loď" });
            var hasher = new PasswordHasher<User>();

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = "TOMAS123",
                UserName = "tomas.kulhavy@pslib.cz",
                NormalizedUserName = "TOMAS.KULHAVY@PSLIB.CZ",
                Email = "tomas.kulhavy@pslib.cz",
                NormalizedEmail = "TOMAS.KULHAVY@PSLIB.CZ",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = string.Empty,
                PasswordHash = hasher.HashPassword(null, "Admin.1234")
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = "MARTIN123",
                UserName = "martin.celeda@pslib.cz",
                NormalizedUserName = "MARTIN.CELEDA@PSLIB.CZ",
                Email = "martin.celeda@pslib.cz",
                NormalizedEmail = "MARTIN.CELEDA@PSLIB.CZ",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = string.Empty,
                PasswordHash = hasher.HashPassword(null, "Admin.1234")
            });

            Game firstGame = new Game
            {
                GameId = new Guid("23e8e6dc-11f3-4899-b977-445bd8cfbcb1"),
                MaxPlayers = 2,
                OwnerId = "TOMAS123",
                PlayerOnTurnId = "MARTIN123",
                GameState = GameState.Setup
            };

            Game secondGame = new Game
            {
                GameId = new Guid("ee7c70ca-357b-4874-8cd9-81c1fc39977f"),
                MaxPlayers = 2,
                OwnerId = "MARTIN123",
                PlayerOnTurnId = "TOMAS123",
                GameState = GameState.Setup
            };

            modelBuilder.Entity<Game>().HasData(firstGame);
            modelBuilder.Entity<Game>().HasData(secondGame);

            UserGame userGameTomas = new UserGame
            {
                Id = 1,
                GameId = firstGame.GameId,
                UserId = "TOMAS123",
                PlayerState = PlayerState.PlacingShip
            };

            UserGame userGameMartin = new UserGame
            {
                Id = 2,
                GameId = firstGame.GameId,
                UserId = "MARTIN123",
                PlayerState = PlayerState.PlacingShip
            };

            UserGame userGameFirst = new UserGame
            {
                Id = 3,
                GameId = secondGame.GameId,
                UserId = "TOMAS123",
                PlayerState = PlayerState.PlacingShip
            };

            UserGame userGameSecond = new UserGame
            {
                Id = 4,
                GameId = secondGame.GameId,
                UserId = "MARTIN123",
                PlayerState = PlayerState.PlacingShip
            };

            modelBuilder.Entity<UserGame>().HasData(userGameTomas);
            modelBuilder.Entity<UserGame>().HasData(userGameMartin);
            modelBuilder.Entity<UserGame>().HasData(userGameFirst);
            modelBuilder.Entity<UserGame>().HasData(userGameSecond);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.PlayerOnTurn)
                .WithMany(u => u.GamesOnTurn)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.GamesOnTurn)
                .WithOne(g => g.PlayerOnTurn);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Owner)
                .WithMany(u => u.CreatedGames)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedGames)
                .WithOne(g => g.Owner)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.UserGames)
                .WithOne(ug => ug.Game)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserGame>()
                .HasMany(g => g.NavyBattlePieces)
                .WithOne(ug => ug.UserGame)
                .OnDelete(DeleteBehavior.Cascade);

            //složený klíč by to v programu jen komplikoval, i když v DB by to řešilo některé nepovolené kombinace...
            //modelBuilder.Entity<UserGame>()
            //    .HasKey(ug => new { ug.UserId, ug.GameId });

            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.Games)
                .HasForeignKey(ug => ug.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.Game)
                .WithMany(g => g.UserGames)
                .HasForeignKey(ug => ug.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            //toto ve skutečnosti nechceme - nešly by vložit dvě lodě stejného typu do jedné hry
            //modelBuilder.Entity<ShipGame>()
            //    .HasKey(sg => new { sg.ShipId, sg.GameId });

            modelBuilder.Entity<ShipGame>()
                .HasOne(sg => sg.Ship)
                .WithMany(s => s.ShipGames)
                .HasForeignKey(su => su.ShipId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ShipGame>()
                .HasOne(sg => sg.Game)
                .WithMany(ug => ug.ShipsForGame)
                .HasForeignKey(su => su.GameId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ShipUserPlaced>()
                .HasOne(su => su.UserGame)
                .WithMany(u => u.ShipsToPlace)
                .HasForeignKey(su => su.UserGameId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ShipUserPlaced>()
                .HasOne(su => su.Ship)
                .WithMany(s => s.PlacedShips)
                .HasForeignKey(su => su.ShipId)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ShipUserPlaced>()
            //    .HasKey(su => new { su.ShipId, su.UserId });
        }
    }
}
