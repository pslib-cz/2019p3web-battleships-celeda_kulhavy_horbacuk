﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<ShipGame> ShipGames { get; set; }
        public DbSet<ShipPiece> ShipPieces { get; set; }
        public DbSet<ShipUserPlaced> ShipUsersPlaced { get; set; }
        public DbSet<ShipUserNotPlaced> ShipUsersNotPlaced { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<NavyBattlePiece> NavyBattlePieces { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserGame>()
                .HasKey(ug => new { ug.UserId, ug.GameId });
            
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

            modelBuilder.Entity<ShipGame>()
                .HasKey(sg => new { sg.ShipId, sg.GameId });

            modelBuilder.Entity<ShipGame>()
                .HasOne(sg => sg.Ship)
                .WithMany(s => s.UserGames) //dodělat
                .HasForeignKey(sg => sg.ShipId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ShipGame>()
                .HasOne(sg => sg.UserGame)
                .WithMany(g => g.ShipGames)
                .HasForeignKey(sg => sg.GameId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ShipUserPlaced>()
                .HasKey(su => new { su.ShipId, su.UserId });

            modelBuilder.Entity<ShipUserPlaced>()
                .HasOne(su => su.Ship)
                .WithMany(s => s.Users) //dodělat
                .HasForeignKey(su => su.ShipId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ShipUserPlaced>()
                .HasOne(su => su.User)
                .WithMany(u => u.ShipUserPlaceds)
                .HasForeignKey(su => su.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ShipUserNotPlaced>()
               .HasKey(su => new { su.ShipId, su.UserId });

            modelBuilder.Entity<ShipUserNotPlaced>()
                .HasOne(su => su.Ship)
                .WithMany(s => s.Users) //dodělat
                .HasForeignKey(su => su.ShipId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ShipUserNotPlaced>()
                .HasOne(su => su.User)
                .WithMany(u => u.ShipUserNotPlaced)
                .HasForeignKey(su => su.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
