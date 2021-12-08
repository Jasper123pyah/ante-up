﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ante_up.Data;

namespace ante_up.Data.Migrations
{
    [DbContext(typeof(AnteUpContext))]
    partial class AnteUpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("ante_up.Common.DataModels.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.ConnectionId", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Connection")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("ConnectionId");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.FriendRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<string>("RequesterId")
                        .HasColumnType("longtext");

                    b.Property<string>("RequesterName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("FriendRequest");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Friendship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AccountId1")
                        .HasColumnType("longtext");

                    b.Property<string>("AccountId2")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ChatId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Friendship");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Game");

                    b.HasData(
                        new
                        {
                            Id = new Guid("289833a2-9614-4ab3-8a50-a18ff21a099a"),
                            Image = "fortnite.jpg",
                            Name = "Fortnite"
                        },
                        new
                        {
                            Id = new Guid("ac2a81d9-e219-4f48-9577-0b3abd729392"),
                            Image = "chess.jpg",
                            Name = "Chess"
                        },
                        new
                        {
                            Id = new Guid("2c0ac839-edb0-4dc0-ab29-069b71bbeccb"),
                            Image = "codmw.jpg",
                            Name = "Call of Duty MW"
                        },
                        new
                        {
                            Id = new Guid("d667e826-f83b-4f6f-9ccc-38f7a04dac5c"),
                            Image = "csgo.jpg",
                            Name = "CS:GO"
                        },
                        new
                        {
                            Id = new Guid("3a7a7f40-43f3-4bc2-a638-84331664ecbd"),
                            Image = "fifa22.jpg",
                            Name = "Fifa 22"
                        },
                        new
                        {
                            Id = new Guid("879c1a50-ea99-4d20-bbac-a34d230ea98f"),
                            Image = "madden.jpg",
                            Name = "Madden NFL 22"
                        },
                        new
                        {
                            Id = new Guid("a3436386-f23f-46f6-8759-27459dfe9b7f"),
                            Image = "nba2k.jpg",
                            Name = "NBA 2K22"
                        },
                        new
                        {
                            Id = new Guid("3a4421ed-77ae-4743-8300-6d9e70b8aec8"),
                            Image = "apex.jpg",
                            Name = "Apex Legends"
                        },
                        new
                        {
                            Id = new Guid("ad32db4b-7e53-4857-a98a-774063f94420"),
                            Image = "leagueoflegends.jpg",
                            Name = "League of Legends"
                        });
                });

            modelBuilder.Entity("ante_up.Common.DataModels.GameStats", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Earnings")
                        .HasColumnType("int");

                    b.Property<int>("Elo")
                        .HasColumnType("int");

                    b.Property<string>("GameName")
                        .HasColumnType("longtext");

                    b.Property<string>("GamerTag")
                        .HasColumnType("longtext");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("GameStats");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ChatId")
                        .HasColumnType("char(36)");

                    b.Property<string>("SenderName")
                        .HasColumnType("longtext");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Wager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Ante")
                        .HasColumnType("int");

                    b.Property<Guid?>("ChatId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Game")
                        .HasColumnType("longtext");

                    b.Property<string>("HostId")
                        .HasColumnType("longtext");

                    b.Property<string>("HostName")
                        .HasColumnType("longtext");

                    b.Property<int>("PlayerCap")
                        .HasColumnType("int");

                    b.Property<Guid?>("Team1Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Team2Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.ToTable("Wager");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.WagerResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Earnings")
                        .HasColumnType("int");

                    b.Property<string>("GameName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("WagerDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("WagerResult");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Account", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.ConnectionId", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Account", null)
                        .WithMany("ConnectionIds")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.FriendRequest", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Account", null)
                        .WithMany("FriendRequests")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Friendship", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.GameStats", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Account", null)
                        .WithMany("GameStats")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Message", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Chat", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatId");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Wager", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId");

                    b.HasOne("ante_up.Common.DataModels.Team", "Team1")
                        .WithMany()
                        .HasForeignKey("Team1Id");

                    b.HasOne("ante_up.Common.DataModels.Team", "Team2")
                        .WithMany()
                        .HasForeignKey("Team2Id");

                    b.Navigation("Chat");

                    b.Navigation("Team1");

                    b.Navigation("Team2");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.WagerResult", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Account", null)
                        .WithMany("WagerResults")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Account", b =>
                {
                    b.Navigation("ConnectionIds");

                    b.Navigation("FriendRequests");

                    b.Navigation("GameStats");

                    b.Navigation("WagerResults");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
