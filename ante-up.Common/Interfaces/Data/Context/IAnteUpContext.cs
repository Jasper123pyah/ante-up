using System;
using ante_up.Common.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Common.Interfaces.Data
{
    public interface IAnteUpContext : IDbContext, IDisposable
    {
        DbSet<Account> Account { get; set; }
        DbSet<Game> Game { get; set; }
        DbSet<Wager> Wager { get; set; }
        DbSet<Chat> Chat { get; set; }
        DbSet<Team> Team { get; set; }
        DbSet<ConnectionId> ConnectionId { get; set; }
        DbSet<Friendship> Friendship { get; set; }
        DbSet<FriendRequest> FriendRequest { get; set; }
    }
}