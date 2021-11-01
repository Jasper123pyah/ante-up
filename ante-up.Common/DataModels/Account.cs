using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ante_up.Common.DataModels
{
    public class Account
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
        public Team Team { get; set; }
        public List<Friendship> Friendships { get; set; }
        public List<ConnectionId> ConnectionIds { get; set; }
        public List<FriendRequest> FriendRequests { get; set; }
        public PlayerStats Stats { get; set; }
    }
}