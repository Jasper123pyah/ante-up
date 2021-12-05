using System;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(x => x.Id);
            modelBuilder.Entity<FriendRequest>().HasKey(x => x.Id);
            modelBuilder.Entity<Game>().HasData(
                new Game("Fortnite", "fortnite.jpg"),
                new Game("Chess", "chess.jpg"),
                new Game("Call of Duty MW", "codmw.jpg"),
                new Game("CS:GO", "csgo.jpg"),
                new Game("Fifa 22", "fifa22.jpg"),
                new Game("Madden NFL 22", "madden.jpg"),
                new Game("NBA 2K22", "nba2k.jpg"),
                new Game("Apex Legends", "apex.jpg"),
                new Game("League of Legends", "leagueoflegends.jpg"));
        }

        public AnteUpContext(DbContextOptions options) : base(options)
        {
        }
    }
}