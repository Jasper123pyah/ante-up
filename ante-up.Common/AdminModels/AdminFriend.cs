using ante_up.Common.DataModels;

namespace ante_up.Common.AdminModels
{
    public class AdminFriend
    {
        private string Id { get; set; }
        private string FriendName { get; set; }
        private Chat Chat { get; set; }

        public AdminFriend(string id, string friendName, Chat chat)
        {
            Id = id;
            FriendName = friendName;
            Chat = chat;
        }
    }
}