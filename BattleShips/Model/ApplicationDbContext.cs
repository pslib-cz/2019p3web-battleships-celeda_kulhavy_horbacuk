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
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedGames)
                .WithOne(g => g.Owner);

            //složený klíč by to v programu jen komplikoval, i když v DB by to řešilo některé nepovolené kombinace...
            //modelBuilder.Entity<UserGame>()
            //    .HasKey(ug => new { ug.UserId, ug.GameId });

            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.Games)
                .HasForeignKey(ug => ug.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.Game)
                .WithMany(g => g.UserGames)
                .HasForeignKey(ug => ug.GameId)
                .OnDelete(DeleteBehavior.NoAction);

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
