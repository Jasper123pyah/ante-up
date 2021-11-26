using System.Collections.Generic;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Logic.JWT;

namespace ante_up.Logic
{
    public class FriendLogic
    {
        private readonly IAccountData _accountData;
        private readonly IFriendData _friendData;
        public FriendLogic(IAccountData accountData, IFriendData friendData)
        {
            _accountData = accountData;
            _friendData = friendData;
        }

        private void CreateFriendship(Account account1, Account account2)
        {
            Friendship friendShip = new(account1.Id.ToString(), account2.Id.ToString());
            _friendData.CreateFriendship(friendShip);
        }
        public List<string> GetFriendNames(string accountId)
        {
            if (accountId == null)
                throw new ApiException(401, "Invalid Token.");
            
            List<string> userNames = new();
            List<Friendship> friendships = _friendData.GetFriends(accountId);
            
            foreach (Friendship friendship in friendships)
            {
                if (friendship.AccountId1 == accountId)
                    userNames.Add(_accountData.GetAccountById(friendship.AccountId2)?.Username);
                else
                    userNames.Add(_accountData.GetAccountById(friendship.AccountId1)?.Username);
            }

            return userNames;
        }

        public List<string> GetFriendRequestNames(string token)
        {
            string accountId = JWTLogic.GetId(token);

            return _friendData.GetFriendRequestNames(accountId);
        }
        public string FriendRequest(string friendName, string accountId)
        {
            Account friend = _accountData.GetAccountById(_accountData.GetAccountIdByUsername(friendName));
            Account account = _accountData.GetAccountById(accountId);
            if (friend?.Id == null)
                return FriendRequestResponses.NotFound.GetDescription();
            if (_friendData.GetFriendRequestNames(friend.Id.ToString())!.Contains(account.Username))
                return FriendRequestResponses.AlreadyAdded.GetDescription();
            if (GetFriendNames(accountId).Contains(friendName))
                return FriendRequestResponses.AlreadyFriends.GetDescription();
            if (friendName == account?.Username)
                return FriendRequestResponses.AddedSelf.GetDescription();

            _friendData.CreateFriendRequest(friend, accountId, account?.Username!);
            return FriendRequestResponses.Success.GetDescription();
        }
        public void FriendRequestResponse(string token, bool accepted, string friendName)
        {
            string accountId = JWTLogic.GetId(token);

            Account account = _accountData.GetAccountById(accountId);
            Account friend = _accountData.GetAccountById(_accountData.GetAccountIdByUsername(friendName));
            if (accepted)
                CreateFriendship(account, friend);   
            
            _friendData.RemoveFriendRequests(account, friend);
        }
    }
}