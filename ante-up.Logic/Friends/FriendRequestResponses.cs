using System.ComponentModel;

namespace ante_up.Logic
{
    public enum FriendRequestResponses
    {          
        [Description("Succes.")]
        Success,
        [Description("Person not found.")]
        NotFound,
        [Description("Person already added.")]
        AlreadyAdded,
        [Description("Already friends.")]
        AlreadyFriends,
        [Description("Can't add yourself as friend.")]
        AddedSelf 
        
    }
}