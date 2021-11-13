using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Logic;

namespace ante_up.Tests.FakeData
{
    public class FakeFriendData : IFriendData
    {
        private List<Friendship> Friendships = new();
        private readonly List<FriendRequest> FriendRequests = new();
        private readonly FakeAccountData _accountData;
        public FakeFriendData()
        {
            _accountData = new FakeAccountData();
        }

        public List<Friendship> GetFriends(string accountId)
        {
            return Friendships.Where(x => x.AccountId1 == accountId
                                   || x.AccountId2 == accountId).ToList();
        }

        public List<string> GetFriendRequestNames(string accountId)
        {
            return _accountData.GetAccountById(accountId)?.FriendRequests.Select(x => x.RequesterName).ToList();
        }

        public Friendship GetFriendShip(string accountId, string friendId)
        {
            return Friendships.FirstOrDefault(x =>
                x.AccountId1 == accountId || x.AccountId1 == friendId &&
                x.AccountId2 == accountId || x.AccountId2 == friendId)!;
        }

        public void CreateFriendRequest(Account account, string requesterId, string requesterName)
        {
            account.FriendRequests.Add(new FriendRequest(requesterId, requesterName));
        }

        public void CreateFriendship(Friendship friendship)
        {
            Friendships.Add(friendship);
        }

        public void RemoveFriendRequests(Account account1, Account account2)
        {
            FriendRequest? account1Request = account1.FriendRequests.FirstOrDefault(x => x.RequesterId == account2.Id.ToString());
            FriendRequest? account2Request = account2.FriendRequests.FirstOrDefault(x => x.RequesterId == account1.Id.ToString());
            if (account1Request != null)
                FriendRequests.Remove(account1Request);
            if (account2Request != null)
                FriendRequests.Remove(account2Request);
        }

        public string GetFriendName(string accountId, Friendship friendship)
        {
            return accountId == friendship.AccountId2 ? _accountData.GetAccountById(friendship.AccountId1)?.Username! : _accountData.GetAccountById(friendship.AccountId2)?.Username!;
        }
    }
}