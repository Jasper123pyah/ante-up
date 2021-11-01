using ante_up.Common.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class AnteUpContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Wager> Wager { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<ConnectionId> ConnectionId { get; set; }
        public AnteUpContext(DbContextOptions options) : base(options){}

    }
}