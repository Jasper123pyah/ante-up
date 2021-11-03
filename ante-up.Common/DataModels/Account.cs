using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ante_up.Common.DataModels
{
    public class Account
    {
        [Key]
        public Guid Id { get; }
        public string Email { get;}
        public string Username { get;}
        public string Password { get;}
        public int Balance { get;}
        public Team Team { get; private set; }
        public List<ConnectionId> ConnectionIds { get;}
        public List<FriendRequest> FriendRequests { get;}
        public PlayerStats Stats { get;}

        public Account(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = password;
            Balance = 0;
            ConnectionIds = new List<ConnectionId>();
            FriendRequests = new List<FriendRequest>();
        }

        public string GetId()
        {
            return Id.ToString();
        }

        public IEnumerable<string> GetConnectionIds()
        {
            return ConnectionIds.Select(connId => connId.Connection).ToList();;
        }

        public void AddConnectionId(string connectionId)
        {
            ConnectionIds.Add(new ConnectionId(connectionId));
        }

        public void RemoveTeam()
        {
            Team = null;
        }

        public void SetTeam(Team team)
        {
            Team = team;
        }
    }
}