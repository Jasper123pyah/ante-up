using ante_up.Common.DataModels;
using ante_up.Common.HubModels;
using ante_up.Common.Interfaces.Data.Classes;

namespace ante_up.Logic
{
    public class ChatLogic
    {
        private readonly IWagerData _wagerData;
        private readonly IChatData _chatData;
        private readonly IAccountData _accountData;
        private readonly IFriendData _friendData;

        public ChatLogic(IWagerData wagerData, IAccountData accountData, IChatData chatData, IFriendData friendData)
        {
            _chatData = chatData;
            _wagerData = wagerData;
            _accountData = accountData;
            _friendData = friendData;
        }

        public void SendWagerMessage(LobbyMessage lobbyMessage)
        {
            Wager wager = _wagerData.GetById(lobbyMessage.LobbyId);
            Message message = new(_accountData.GetAccountById(lobbyMessage.Sender)?.Username, lobbyMessage.Message);
            _chatData.SendWagerMessage(wager, message);
        }
        public Chat GetFriendChat(string friendId, string accountId)
        {
            return _friendData.GetFriendShip(accountId, friendId).Chat;
        }

        public void SendFriendMessage(string receiverName, string senderId, string text)
        {
            string receiverId = _accountData.GetAccountIdByUsername(receiverName);
            string senderName = _accountData.GetAccountById(senderId)?.Username;
            Chat chat = GetFriendChat(receiverId!, senderId);
            Message message = new (senderName, text);
            _chatData.SendFriendMessage(chat, message);
        }

        public Chat GetWagerChat(string wagerId)
        {
            Wager wager = _wagerData.GetById(wagerId);
            return _chatData.GetWagerChat(wager);
        }
    }
}