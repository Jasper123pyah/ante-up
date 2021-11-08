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
        public Team Team { get; private set; }
        public List<Friendship> Friendships { get; set; }
        public PlayerStats Stats { get;set;}

        public AdminAccount(string id, string email, string username, int balance, List<Friendship> friendships,  PlayerStats stats, Team team)
        {
            Id = id;
            Email = email;
            Username = username;
            Balance = balance;
            Friendships = friendships;
            Stats = stats;
            Team = team;
        }
    }
}