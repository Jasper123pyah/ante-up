using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ante_up.Common.DataModels
{
    public class Account
    {
        [Key]
        public Guid Id { get;set; }
        public string Email { get;set;}
        public string Username { get;set;}
        public string Password { get;set;}
        public int Balance { get;set;}
        public Team Team { get; private set; }
        public List<ConnectionId> ConnectionIds { get;set;}
        public List<FriendRequest> FriendRequests { get;set;}
        public List<WagerResult> WagerResults { get; set; }
        public List<GameStats> GameStats { get; set; }
        public List<PaypalTransaction> Transactions { get; set; }
        public bool IsAdmin { get; private set; }
        public DateTime Created { get; set; }
        public Account() { }

        public Account(string email, string username, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Username = username;
            Password = BCrypt.Net.BCrypt.HashPassword(password);
            Balance = 0;
            ConnectionIds = new List<ConnectionId>();
            FriendRequests = new List<FriendRequest>();
            WagerResults = new List<WagerResult>();
            GameStats = new List<GameStats>();
            IsAdmin = false;
            Created = DateTime.Today;
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
        
        public IEnumerable<string> GetConnectionIds()
        {
            return ConnectionIds.Select(connId => connId.Connection).ToList();
        }

        public void AddConnectionId(string connectionId)
        {
            ConnectionIds.Add(new ConnectionId(connectionId));
        }

        public void AddBalance(int amount)
        {
            Balance += amount;
        }
        public void RemoveTeam()
        {
            Team = null;
        }

        public void SetTeam(Team team)
        {
            Team = team;
        }

        public bool HasGameStats(string gameName)
        {
            if (GameStats?.FirstOrDefault(x => x.GameName == gameName) == null)
                return false;
            return true;
        }
        public GameStats GetGameStats(string gameName)
        {
            if(HasGameStats(gameName))
                return GameStats.FirstOrDefault(x => x.GameName == gameName);
            
            return new GameStats(gameName);
        }
    }
}