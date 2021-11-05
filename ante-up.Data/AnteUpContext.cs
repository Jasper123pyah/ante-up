using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class AnteUpContext : DbContext, IAnteUpContext
    {
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
            
        }
        public AnteUpContext(DbContextOptions options) : base(options){}

    }
}