using ante_up.Common.DataModels;
using ante_up.Common.HubModels;

namespace ante_up.Common.Interfaces.Data.Classes
{
    public interface IChatData
    {
        void SendWagerMessage(Wager wager, Message message);
        void SendFriendMessage(Chat chat, Message message);
        Chat GetWagerChat(Wager wager);
    }
}