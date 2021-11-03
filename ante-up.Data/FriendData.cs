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

        public List<string> GetFriends(string accountId) // returns list of usernames of friends
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

        public List<string> GetFriendRequests(string accountId)
        {
            return _accountData.GetAccountById(accountId)?.FriendRequests
                .Select(requester => _accountData.GetAccountById(requester.RequesterId)?.Username).ToList()!;
        }

        public string FriendRequest(string friendName, string accountId)
        {
            Account? friend = _accountData.GetAccountById(_accountData.GetAccountIdByUsername(friendName));
            if (friend?.Id == null)
                return "Person not found";
            if (GetFriendRequests(friend.Id)!.Contains(accountId))
                return "Person already added";
            if (GetFriends(accountId).Contains(friendName))
                return "Already friends";
            if (friendName == _accountData.GetAccountById(accountId)?.Username)
                return "Can't add yourself as friend";
            else
            {
                friend.FriendRequests.Add(new FriendRequest {Id = Guid.NewGuid().ToString(), RequesterId = accountId});
                _anteContext.SaveChanges();

                return friend.Id;
            }
        }

        public Friendship GetFriendShip(string accountId, string? friendId)
        {
            return _anteContext.Friendship.Include(x => x.Chat)
                .ThenInclude(x => x.Message)
                .FirstOrDefault(x =>
                    x.AccountId1 == accountId || x.AccountId1 == friendId &&
                    x.AccountId2 == accountId || x.AccountId2 == friendId)!;
        }

        public void FriendRequestResponse(string accountId, bool accepted, string friendName)
        {
            Account account = _accountData.GetAccountById(accountId)!;
            Account friend = _accountData.GetAccountById(_accountData.GetAccountIdByUsername(friendName))!;
            if (accepted)
            {
                Friendship friendShip = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountId1 = account.Id,
                    AccountId2 = friend.Id,
                    Chat = new Chat() {Id = Guid.NewGuid().ToString(), Message = new List<Message>()}
                };
                _anteContext.Friendship.Add(friendShip);
            }

            FriendRequest? accountRequest = account.FriendRequests.FirstOrDefault(x => x.RequesterId == friend.Id);
            FriendRequest? friendRequest = friend.FriendRequests.FirstOrDefault(x => x.RequesterId == account.Id);
            if (accountRequest != null)
                _anteContext.FriendRequest.Remove(accountRequest);
            if (friendRequest != null)
                _anteContext.FriendRequest.Remove(friendRequest);

            _anteContext.SaveChanges();
        }
    }
}