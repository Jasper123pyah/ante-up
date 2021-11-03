using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class FriendData
    {
        private readonly AnteUpContext _anteContext;
        private readonly AccountData _accountData;

        public FriendData(AnteUpContext context)
        {
            _anteContext = context;
            _accountData = new AccountData(context);
        }

        public List<string> GetFriends(string accountId) // returns list of usernames of friends of account
        {
            List<string?> userNames = new();
            List<Friendship> friendships = _anteContext.Friendship.Where(x => x.AccountId1 == accountId
                                                                              || x.AccountId2 == accountId).ToList();
            foreach (Friendship friendship in friendships)
            {
                if (friendship.AccountId1 == accountId)
                    userNames.Add(_accountData.GetAccountById(friendship.AccountId2)?.Username);
                else
                    userNames.Add(_accountData.GetAccountById(friendship.AccountId1)?.Username);
            }

            return userNames;
        }

        public List<string>? GetFriendRequests(string accountId)
        {
            return _accountData.GetAccountById(accountId)?.FriendRequests.Select(x => x.RequesterName).ToList();
        }

        public Friendship GetFriendShip(string accountId, string? friendId)
        {
            return _anteContext.Friendship.Include(x => x.Chat)
                .ThenInclude(x => x.Messages)
                .FirstOrDefault(x =>
                    x.AccountId1 == accountId || x.AccountId1 == friendId &&
                    x.AccountId2 == accountId || x.AccountId2 == friendId)!;
        }

        public void CreateFriendRequest(Account account, string requesterId, string requesterName)
        {
            account.FriendRequests.Add(new FriendRequest(requesterId, requesterName));
            _anteContext.SaveChanges();
        }
        public void CreateFriendShip(Account account1, Account account2)
        {
            Friendship friendShip = new(account1.GetId(), account2.GetId());
            _anteContext.Friendship.Add(friendShip);
            _anteContext.SaveChanges();
        }

        public void RemoveFriendRequests(Account account1, Account account2)
        {
            FriendRequest? account1Request = account1.FriendRequests.FirstOrDefault(x => x.RequesterId == account2.GetId());
            FriendRequest? account2Request = account2.FriendRequests.FirstOrDefault(x => x.RequesterId == account1.GetId());
            if (account1Request != null)
                _anteContext.FriendRequest.Remove(account1Request);
            if (account2Request != null)
                _anteContext.FriendRequest.Remove(account2Request);

            _anteContext.SaveChanges();
        }
        
    }
}