using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data;
using ante_up.Common.Interfaces.Data.Classes;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class FriendData : IFriendData
    {
        private readonly IAnteUpContext _anteContext;
        private readonly AccountData _accountData;

        public FriendData(IAnteUpContext context)
        {
            _anteContext = context;
            _accountData = new AccountData(context);
        }

        public List<Friendship> GetFriends(string accountId) // returns list of usernames of friends of account
        {
            return _anteContext.Friendship.Where(x => x.AccountId1 == accountId
                                                            || x.AccountId2 == accountId).ToList();
        }

        public List<string>? GetFriendRequestNames(string accountId)
        {
            return _accountData.GetAccountById(accountId)?.FriendRequests.Select(x => x.RequesterName).ToList();
        }

        public Friendship GetFriendShip(string accountId, string? friendId)
        {
            return _anteContext.Friendship.Include(x => x.Chat)
                .ThenInclude(x => x.Messages)
                .FirstOrDefault(x =>
                    x.AccountId1 == accountId && x.AccountId2 == friendId ||
                    x.AccountId2 == accountId && x.AccountId1 == friendId)!;
        }

        public void CreateFriendRequest(Account account, string requesterId, string requesterName)
        {
            account.FriendRequests.Add(new FriendRequest(requesterId, requesterName));
            _anteContext.SaveChanges();
        }
        public void CreateFriendship(Friendship friendship)
        {
            _anteContext.Friendship.Add(friendship);
            _anteContext.SaveChanges();
        }

        public void RemoveFriendRequests(Account account1, Account account2)
        {
            FriendRequest? account1Request = account1.FriendRequests.FirstOrDefault(x => x.RequesterId == account2.Id.ToString());
            FriendRequest? account2Request = account2.FriendRequests.FirstOrDefault(x => x.RequesterId == account1.Id.ToString());
            if (account1Request != null)
                _anteContext.FriendRequest.Remove(account1Request);
            if (account2Request != null)
                _anteContext.FriendRequest.Remove(account2Request);

            _anteContext.SaveChanges();
        }
    }
}