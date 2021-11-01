using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class AccountData
    {
        private readonly AnteUpContext _anteContext;
        public AccountData(AnteUpContext context)
        {
            _anteContext = context;
        }
        public List<string> GetFriends(string accountId) // returns list of usernames of friends
        {
            Account account = GetAccountById(accountId)!;
            List<string?> userNames = new();
            foreach (Friendship friendship in account.Friendships)
            {
                if (friendship.AccountId1 == accountId)
                    userNames.Add(GetAccountById(friendship.AccountId2)?.Username);
                else
                    userNames.Add(GetAccountById(friendship.AccountId1)?.Username);
            }

            return userNames;
        }

        public List<string> GetConnectionIds(string accountId)
        {
            Account account = GetAccountById(accountId)!;
            return account.ConnectionIds.Select(connId => connId.Connection).ToList();
        }
        public List<string> GetFriendRequests(string accountId)
        {
            return GetAccountById(accountId)?.FriendRequests.Select(requester => GetAccountById(requester.RequesterId)?.Username).ToList()!;
        }
        

        public string FriendRequest(string friendName, string accountId)
        {
            Account? friend = GetAccountByUsername(friendName);
            if (friend?.Id == null)
                return "Person not found";
            if (GetFriendRequests(friend.Id)!.Contains(accountId))
                return "Person already added";
            if (GetFriends(accountId).Contains(friendName))
                return "Already friends";
            if (friendName == GetAccountById(accountId)?.Username)
                return "Can't add yourself as friend";
            else
            {
                friend.FriendRequests.Add(new FriendRequest{Id = Guid.NewGuid().ToString(), RequesterId = accountId});
                _anteContext.SaveChanges();
            
                return friend.Id;
            }
        }

        public void RemoveConnectionId(string connectionId, string accountId)
        {
            Account? account = GetAccountById(accountId);
            ConnectionId connection = account.ConnectionIds.FirstOrDefault(x => x.Connection == connectionId);
            _anteContext.ConnectionId.Remove(connection);
            _anteContext.SaveChanges();
        }
        public void SaveConnectionId(string connectionId, string accountId)
        {
            Account? account = GetAccountById(accountId);
            account?.ConnectionIds.Add(new ConnectionId(){Id = Guid.NewGuid().ToString(), Connection = connectionId});
            _anteContext.SaveChanges();
        }
        public void Register(ApiAccount account)
        {
            _anteContext.Account.Add(new Account
            {
                Id = Guid.NewGuid().ToString(),
                Balance = 0,
                Email = account.Email,
                Username = account.Username,
                Password = account.Password,
                Friendships = new List<Friendship>(),
                ConnectionIds = new List<ConnectionId>()
            });
            _anteContext.SaveChanges();
        }
        public Account? GetAccountByEmail(string accountEmail)
        {
            return _anteContext.Account.Include(x => x.Friendships)
                                        .Include(x => x.ConnectionIds)
                                        .Include(x => x.FriendRequests)
                                        .Include(x => x.Team)
                                        .ThenInclude(x => x.Players)
                                        .FirstOrDefault(e => e.Email == accountEmail);
            
        }
        public Account? GetAccountByUsername(string username)
        {
            return _anteContext.Account.Include(x => x.Friendships)
                                        .Include(x => x.ConnectionIds)
                                        .Include(x => x.FriendRequests)
                                        .Include(x => x.Team)
                                        .ThenInclude(x => x.Players)
                                        .FirstOrDefault(e => e.Username == username);
        }
        public Account? GetAccountById(string id)
        {
            return _anteContext.Account.Include(x => x.Friendships)
                                        .Include(x => x.ConnectionIds)
                                        .Include(x => x.FriendRequests)
                                        .Include(x => x.Team)
                                        .ThenInclude(x => x.Players)
                                        .FirstOrDefault(e => e.Id == id);
        }
    }
}