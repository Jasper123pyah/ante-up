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
    [Migration("20211203132424_PlayerstatsEdit")]
    partial class PlayerstatsEdit
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
                            Id = new Guid("0ca0de45-91db-4202-bba7-efd76fb014a0"),
                            Image = "fortnite.jpg",
                            Name = "Fortnite"
                        },
                        new
                        {
                            Id = new Guid("8e5492f2-c218-4edd-860b-f6312bef9348"),
                            Image = "chess.jpg",
                            Name = "Chess"
                        },
                        new
                        {
                            Id = new Guid("526ce6b2-3b1e-435a-9b16-cd00d511e81d"),
                            Image = "codmw.jpg",
                            Name = "Call of Duty MW"
                        },
                        new
                        {
                            Id = new Guid("dc6a69c0-74de-4b60-b54a-a164bd12849e"),
                            Image = "csgo.jpg",
                            Name = "CS:GO"
                        },
                        new
                        {
                            Id = new Guid("4b46a6a5-b631-42f5-89b4-893639026f68"),
                            Image = "fifa22.jpg",
                            Name = "Fifa 22"
                        },
                        new
                        {
                            Id = new Guid("a606d10e-e775-48a7-991a-fd49e3ab73a7"),
                            Image = "madden.jpg",
                            Name = "Madden NFL 22"
                        },
                        new
                        {
                            Id = new Guid("9296c4b6-cf5b-4630-8164-4ee2a86fb410"),
                            Image = "nba2k.jpg",
                            Name = "NBA 2K22"
                        },
                        new
                        {
                            Id = new Guid("e038e051-3341-4151-b49c-f878a8ec7b93"),
                            Image = "apex.jpg",
                            Name = "Apex Legends"
                        },
                        new
                        {
                            Id = new Guid("3472ada7-e718-4ca2-8201-d3ae28c0d91d"),
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

            modelBuilder.Entity("ante_up.Common.DataModels.WagerResults", b =>
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

                    b.ToTable("WagerResults");
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

            modelBuilder.Entity("ante_up.Common.DataModels.WagerResults", b =>
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