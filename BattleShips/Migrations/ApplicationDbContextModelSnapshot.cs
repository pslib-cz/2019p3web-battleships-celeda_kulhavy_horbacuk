﻿// <auto-generated />
using System;
using BattleShips.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BattleShips.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("BattleShips.Model.Game", b =>
                {
                    b.Property<Guid>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("GameState")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OwnerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerOnTurnId")
                        .HasColumnType("TEXT");

                    b.HasKey("GameId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PlayerOnTurnId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameId = new Guid("23e8e6dc-11f3-4899-b977-445bd8cfbcb1"),
                            GameState = 0,
                            MaxPlayers = 2,
                            OwnerId = "TOMAS123",
                            PlayerOnTurnId = "MARTIN123"
                        },
                        new
                        {
                            GameId = new Guid("ee7c70ca-357b-4874-8cd9-81c1fc39977f"),
                            GameState = 0,
                            MaxPlayers = 2,
                            OwnerId = "MARTIN123",
                            PlayerOnTurnId = "TOMAS123"
                        });
                });

            modelBuilder.Entity("BattleShips.Model.NavyBattlePiece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Hidden")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PieceState")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PosX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PosY")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShipId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserGameId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ShipId");

                    b.HasIndex("UserGameId");

                    b.ToTable("NavyBattlePieces");
                });

            modelBuilder.Entity("BattleShips.Model.Ship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ShipUserPlacedId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ShipUserPlacedId");

                    b.ToTable("Ships");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 0,
                            Name = "Torpédoborec"
                        },
                        new
                        {
                            Id = 2,
                            Count = 0,
                            Name = "Ponorka"
                        },
                        new
                        {
                            Id = 3,
                            Count = 0,
                            Name = "Křižník"
                        },
                        new
                        {
                            Id = 4,
                            Count = 0,
                            Name = "Bitevní loď"
                        },
                        new
                        {
                            Id = 5,
                            Count = 0,
                            Name = "Letadlová loď"
                        });
                });

            modelBuilder.Entity("BattleShips.Model.ShipGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("GameId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ShipId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("UserGameId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("ShipId");

                    b.ToTable("ShipGames");
                });

            modelBuilder.Entity("BattleShips.Model.ShipPiece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMargin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PosX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PosY")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShipId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ShipId");

                    b.ToTable("ShipPieces");
                });

            modelBuilder.Entity("BattleShips.Model.ShipUserPlaced", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShipId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserGameId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ShipId");

                    b.HasIndex("UserGameId");

                    b.ToTable("ShipUsersPlaced");
                });

            modelBuilder.Entity("BattleShips.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "TOMAS123",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fe116012-5abb-4868-95ff-e6f61f0482fc",
                            Email = "tomas.kulhavy@pslib.cz",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "TOMAS.KULHAVY@PSLIB.CZ",
                            NormalizedUserName = "TOMAS.KULHAVY@PSLIB.CZ",
                            PasswordHash = "AQAAAAEAACcQAAAAEKDMiVd1aVtcmOfXuCsrgbaY9Hsi2vRYDu+KtcIVO+meC2xaQtfUpBPHCWWb7rA3ug==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "tomas.kulhavy@pslib.cz"
                        },
                        new
                        {
                            Id = "MARTIN123",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fd198e39-0232-452d-abd9-1050fa883d15",
                            Email = "martin.celeda@pslib.cz",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MARTIN.CELEDA@PSLIB.CZ",
                            NormalizedUserName = "MARTIN.CELEDA@PSLIB.CZ",
                            PasswordHash = "AQAAAAEAACcQAAAAEPAjw4oXPJGQIhuFB94TjoKZTfHAuJAOU30nHcqbTT3r7jvM0QWSHK963kohbb2rIQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "martin.celeda@pslib.cz"
                        });
                });

            modelBuilder.Entity("BattleShips.Model.UserGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("GameId")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayerState")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ShipId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("ShipId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameId = new Guid("23e8e6dc-11f3-4899-b977-445bd8cfbcb1"),
                            PlayerState = 0,
                            UserId = "TOMAS123"
                        },
                        new
                        {
                            Id = 2,
                            GameId = new Guid("23e8e6dc-11f3-4899-b977-445bd8cfbcb1"),
                            PlayerState = 0,
                            UserId = "MARTIN123"
                        },
                        new
                        {
                            Id = 3,
                            GameId = new Guid("ee7c70ca-357b-4874-8cd9-81c1fc39977f"),
                            PlayerState = 0,
                            UserId = "TOMAS123"
                        },
                        new
                        {
                            Id = 4,
                            GameId = new Guid("ee7c70ca-357b-4874-8cd9-81c1fc39977f"),
                            PlayerState = 0,
                            UserId = "MARTIN123"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BattleShips.Model.Game", b =>
                {
                    b.HasOne("BattleShips.Model.User", "Owner")
                        .WithMany("CreatedGames")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("BattleShips.Model.User", "PlayerOnTurn")
                        .WithMany("GamesOnTurn")
                        .HasForeignKey("PlayerOnTurnId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("BattleShips.Model.NavyBattlePiece", b =>
                {
                    b.HasOne("BattleShips.Model.Ship", "Ship")
                        .WithMany("NavyBattlePieces")
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BattleShips.Model.UserGame", "UserGame")
                        .WithMany("NavyBattlePieces")
                        .HasForeignKey("UserGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BattleShips.Model.Ship", b =>
                {
                    b.HasOne("BattleShips.Model.ShipUserPlaced", null)
                        .WithMany("Ships")
                        .HasForeignKey("ShipUserPlacedId");
                });

            modelBuilder.Entity("BattleShips.Model.ShipGame", b =>
                {
                    b.HasOne("BattleShips.Model.Game", "Game")
                        .WithMany("ShipsForGame")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BattleShips.Model.Ship", "Ship")
                        .WithMany("ShipGames")
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("BattleShips.Model.ShipPiece", b =>
                {
                    b.HasOne("BattleShips.Model.Ship", "Ship")
                        .WithMany("ShipPieces")
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BattleShips.Model.ShipUserPlaced", b =>
                {
                    b.HasOne("BattleShips.Model.Ship", "Ship")
                        .WithMany("PlacedShips")
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BattleShips.Model.UserGame", "UserGame")
                        .WithMany("ShipsToPlace")
                        .HasForeignKey("UserGameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("BattleShips.Model.UserGame", b =>
                {
                    b.HasOne("BattleShips.Model.Game", "Game")
                        .WithMany("UserGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BattleShips.Model.Ship", null)
                        .WithMany("UserGames")
                        .HasForeignKey("ShipId");

                    b.HasOne("BattleShips.Model.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BattleShips.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BattleShips.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BattleShips.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BattleShips.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
