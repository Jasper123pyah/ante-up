using System.Collections.Generic;
using ante_up.Common.DataModels;

namespace ante_up.Common.Interfaces.Data.Classes
{
    public interface IFriendData
    {
        List<Friendship> GetFriends(string accountId);

        List<string> GetFriendRequestNames(string accountId);

        Friendship GetFriendShip(string accountId, string friendId);

        void CreateFriendRequest(Account account, string requesterId, string requesterName);
        void CreateFriendship(Friendship friendship);

        void RemoveFriendRequests(Account account1, Account account2);
    }
}