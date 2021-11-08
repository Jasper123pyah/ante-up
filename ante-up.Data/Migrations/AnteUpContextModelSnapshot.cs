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

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("StatsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StatsId");

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
                            Id = new Guid("136903f2-3000-4629-aab6-93ceb585844a"),
                            Image = "fortnite.jpg",
                            Name = "Fortnite"
                        },
                        new
                        {
                            Id = new Guid("0a12c1ce-aedf-404b-b3d1-07d83216d961"),
                            Image = "chess.jpg",
                            Name = "Chess"
                        },
                        new
                        {
                            Id = new Guid("7c111d25-95f9-4e67-824b-ceb101660315"),
                            Image = "codmw.jpg",
                            Name = "Call of Duty MW"
                        },
                        new
                        {
                            Id = new Guid("c51d6676-4cef-4438-b960-247493ff500d"),
                            Image = "csgo.jpg",
                            Name = "CS:GO"
                        },
                        new
                        {
                            Id = new Guid("d9b84f28-61b3-40e0-be1d-8b3626a41867"),
                            Image = "fifa22.jpg",
                            Name = "Fifa 22"
                        },
                        new
                        {
                            Id = new Guid("1beacc45-76ad-4a28-b945-591f7e33fcf2"),
                            Image = "madden.jpg",
                            Name = "Madden NFL 22"
                        },
                        new
                        {
                            Id = new Guid("b7816780-a87a-4d8a-898d-e953a60cb40b"),
                            Image = "nba2k.jpg",
                            Name = "NBA 2K22"
                        },
                        new
                        {
                            Id = new Guid("22ca7058-60ad-4534-8d25-4b6094265517"),
                            Image = "apex.jpg",
                            Name = "Apex Legends"
                        },
                        new
                        {
                            Id = new Guid("62bb9825-744a-4aba-b0e1-c9d14306413b"),
                            Image = "leagueoflegends.jpg",
                            Name = "League of Legends"
                        });
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

            modelBuilder.Entity("ante_up.Common.DataModels.PlayerStats", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("PlayerStats");
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

            modelBuilder.Entity("ante_up.Common.DataModels.Account", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.PlayerStats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId");

                    b.HasOne("ante_up.Common.DataModels.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Stats");

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

            modelBuilder.Entity("ante_up.Common.DataModels.Account", b =>
                {
                    b.Navigation("ConnectionIds");

                    b.Navigation("FriendRequests");
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
