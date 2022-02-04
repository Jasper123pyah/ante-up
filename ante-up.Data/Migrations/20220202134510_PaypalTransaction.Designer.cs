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
    [Migration("20220202134510_PaypalTransaction")]
    partial class PaypalTransaction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("address_line_1")
                        .HasColumnType("longtext");

                    b.Property<string>("admin_area_1")
                        .HasColumnType("longtext");

                    b.Property<string>("admin_area_2")
                        .HasColumnType("longtext");

                    b.Property<string>("country_code")
                        .HasColumnType("longtext");

                    b.Property<string>("postal_code")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Name", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("full_name")
                        .HasColumnType("longtext");

                    b.Property<string>("given_name")
                        .HasColumnType("longtext");

                    b.Property<string>("surname")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Name");
                });

            modelBuilder.Entity("Payer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("addressId")
                        .HasColumnType("char(36)");

                    b.Property<string>("email_address")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("nameId")
                        .HasColumnType("char(36)");

                    b.Property<string>("payer_id")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("addressId");

                    b.HasIndex("nameId");

                    b.ToTable("Payer");
                });

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

            modelBuilder.Entity("ante_up.Common.DataModels.Blacklisted", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AccountId")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("WagerId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("WagerId");

                    b.ToTable("Blacklisted");
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

                    b.Property<string>("BannerImage")
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("WaitingTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Game");
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

            modelBuilder.Entity("ante_up.Common.DataModels.LobbySize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("GameId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.Property<int>("TotalPlayers")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("LobbySize");
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

            modelBuilder.Entity("ante_up.Common.DataModels.PaypalAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("PaypalId")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("PaypalTransactionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("PaypalTransactionId");

                    b.ToTable("PaypalAction");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.PaypalTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<string>("CaptureId")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Ip")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("PayerId")
                        .HasColumnType("char(36)");

                    b.Property<string>("PaypalId")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<float>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PayerId");

                    b.ToTable("PaypalTransaction");
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

            modelBuilder.Entity("Payer", b =>
                {
                    b.HasOne("Address", "address")
                        .WithMany()
                        .HasForeignKey("addressId");

                    b.HasOne("Name", "name")
                        .WithMany()
                        .HasForeignKey("nameId");

                    b.Navigation("address");

                    b.Navigation("name");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Account", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Blacklisted", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Wager", null)
                        .WithMany("BlackList")
                        .HasForeignKey("WagerId");
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

            modelBuilder.Entity("ante_up.Common.DataModels.LobbySize", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Game", null)
                        .WithMany("LobbySizes")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Message", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Chat", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatId");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.PaypalAction", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.PaypalTransaction", null)
                        .WithMany("Actions")
                        .HasForeignKey("PaypalTransactionId");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.PaypalTransaction", b =>
                {
                    b.HasOne("ante_up.Common.DataModels.Account", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId");

                    b.HasOne("Payer", "Payer")
                        .WithMany()
                        .HasForeignKey("PayerId");

                    b.Navigation("Payer");
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

                    b.Navigation("Transactions");

                    b.Navigation("WagerResults");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Game", b =>
                {
                    b.Navigation("LobbySizes");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.PaypalTransaction", b =>
                {
                    b.Navigation("Actions");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Team", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("ante_up.Common.DataModels.Wager", b =>
                {
                    b.Navigation("BlackList");
                });
#pragma warning restore 612, 618
        }
    }
}