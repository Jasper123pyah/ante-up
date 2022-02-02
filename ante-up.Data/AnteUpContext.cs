using System;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data;
using ante_up.Common.Interfaces.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class AnteUpContext : DbContext, IAnteUpContext
    {
        //dotnet ef migrations add Migration -p "../ante-up.Data"    
        //dotnet ef database update
        public DbSet<Account> Account { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Wager> Wager { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<ConnectionId> ConnectionId { get; set; }
        public DbSet<Friendship> Friendship { get; set; }
        public DbSet<FriendRequest> FriendRequest { get; set; }
        public DbSet<LobbySize> LobbySize { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(x => x.Id);
            modelBuilder.Entity<FriendRequest>().HasKey(x => x.Id);
            modelBuilder.Entity<Game>().HasData(
                new Game("Fortnite", "fortnite.jpg", 60),
                new Game("Chess", "chess.jpg",60),
                new Game("Call of Duty MW", "codmw.jpg",60),
                new Game("CS:GO", "csgo.jpg",60),
                new Game("Fifa 22", "fifa22.jpg",60),
                new Game("Madden NFL 22", "madden.jpg",60),
                new Game("NBA 2K22", "nba2k.jpg",60),
                new Game("Apex Legends", "apex.jpg",60),
                new Game("League of Legends", "leagueoflegends.jpg",60));
        }
    
        public AnteUpContext(DbContextOptions options) : base(options)
        {
        }
    }
}