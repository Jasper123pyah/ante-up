using ante_up.Common.DataModels;
using ante_up.Data;

namespace ante_up.Logic
{
    public class FriendLogic
    {
        private readonly AccountData _accountData;
        private readonly FriendData _friendData;
        
        public FriendLogic(AnteUpContext context)
        {
            _accountData = new AccountData(context);
            _friendData = new FriendData(context);
        }
        public string FriendRequest(string friendName, string accountId)
        {
            Account friend = _accountData.GetAccountById(_accountData.GetAccountIdByUsername(friendName));
            Account account = _accountData.GetAccountById(accountId);
            if (friend?.Id == null)
                return FriendRequestResponses.NotFound.GetDescription();
            if (_friendData.GetFriendRequests(friend.Id.ToString())!.Contains(accountId))
                return FriendRequestResponses.AlreadyAdded.GetDescription();
            if (_friendData.GetFriends(accountId).Contains(friendName))
                return FriendRequestResponses.AlreadyFriends.GetDescription();
            if (friendName == account?.Username)
                return FriendRequestResponses.AddedSelf.GetDescription();
            else
            {
                _friendData.CreateFriendRequest(friend, accountId, account?.Username!);

                return FriendRequestResponses.Success.GetDescription();
            }
        }
        public void FriendRequestResponse(string accountId, bool accepted, string friendName)
        {
            Account account = _accountData.GetAccountById(accountId)!;
            Account friend = _accountData.GetAccountById(_accountData.GetAccountIdByUsername(friendName))!;
            if (accepted)
                _friendData.CreateFriendShip(account, friend);   
            
            _friendData.RemoveFriendRequests(account, friend);
        }
    }
}