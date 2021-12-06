﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ante_up.Data;

namespace ante_up.Data.Migrations
{
    [DbContext(typeof(AnteUpContext))]
    [Migration("20211205181756_Elo")]
    partial class Elo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Elo")
                        .HasColumnType("int");

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
                            Id = new Guid("105b8cec-6f33-4e62-8d01-61c94b67128f"),
                            Image = "fortnite.jpg",
                            Name = "Fortnite"
                        },
                        new
                        {
                            Id = new Guid("ffd1530f-c520-47dd-8609-f5fb9a39d3cb"),
                            Image = "chess.jpg",
                            Name = "Chess"
                        },
                        new
                        {
                            Id = new Guid("b5957cee-01fa-4b16-a123-b5fdbedb4d91"),
                            Image = "codmw.jpg",
                            Name = "Call of Duty MW"
                        },
                        new
                        {
                            Id = new Guid("c3dafe5b-7c32-4f8a-9941-6fe6fe7c6d82"),
                            Image = "csgo.jpg",
                            Name = "CS:GO"
                        },
                        new
                        {
                            Id = new Guid("67a22445-41c8-46a1-80d0-408d371d36e3"),
                            Image = "fifa22.jpg",
                            Name = "Fifa 22"
                        },
                        new
                        {
                            Id = new Guid("11d8d908-8bb2-4bca-a061-d20b3746e4ad"),
                            Image = "madden.jpg",
                            Name = "Madden NFL 22"
                        },
                        new
                        {
                            Id = new Guid("093976e0-56e9-42c0-96df-e0433372d306"),
                            Image = "nba2k.jpg",
                            Name = "NBA 2K22"
                        },
                        new
                        {
                            Id = new Guid("8aa0558f-e6c0-42d7-8b07-7ad85ffb41da"),
                            Image = "apex.jpg",
                            Name = "Apex Legends"
                        },
                        new
                        {
                            Id = new Guid("488d8a1d-6dae-4786-b9b0-54ac22a273f5"),
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

                    b.Property<string>("GameName")
                        .HasColumnType("longtext");

                    b.Property<string>("Skill")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("GameStats");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.GamerTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Service")
                        .HasColumnType("longtext");

                    b.Property<string>("Tag")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("GamerTag");
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

            modelBuilder.Entity("ante_up.Common.DataModels.GamerTag", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Account", null)
                        .WithMany("GamerTags")
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

                    b.Navigation("GamerTags");

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