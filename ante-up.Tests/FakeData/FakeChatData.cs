using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;

namespace ante_up.Tests.FakeData
{
    public class FakeChatData : IChatData
    {
        public void SendWagerMessage(Wager wager, Message message)
        {
            GetWagerChat(wager).AddMessage(message);
        }

        public void SendFriendMessage(Chat chat, Message message)
        {
            chat.Messages.Add(message);
        }

        public Chat GetWagerChat(Wager wager)
        {
            return wager.Chat;
        }
    }
}