using System;
using System.Collections.Generic;
using ante_up.Common.DataModels;

namespace ante_up.Common.AdminModels
{
    public class AdminAccount
    {
        public string Id { get;set; }
        public string Email { get;set;}
        public string Username { get;set;}
        public int Balance { get;set;}
        public AdminWager Wager { get; private set; }
        public List<AdminFriend> Friendships { get; set; }
        public List<WagerResult> WagerResults { get; set; }
        public List<GameStats> GameStats { get; set; }

        public AdminAccount(string id, string email, string username, int balance, List<AdminFriend> friendships,  List<WagerResult> wagerResults, List<GameStats> gameStats, Wager wager)
        {
            Id = id;
            Email = email;
            Username = username;
            Balance = balance;
            Friendships = friendships;
            WagerResults = wagerResults;
            GameStats = gameStats;
            Wager = wager != null ? new AdminWager(wager) : null;
        }
    }
}