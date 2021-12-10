using ante_up.Common.ApiModels.Responses;
using ante_up.Common.DataModels;
using ante_up.Common.HubModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Logic.JWT;

namespace ante_up.Logic.Services
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
            Account sender = _accountData.GetAccountById(JWTLogic.GetId(lobbyMessage.Sender));
            Message message = new(sender.Username, lobbyMessage.Message);
            _chatData.SendWagerMessage(wager, message);
        }
        public Chat GetFriendChat(string friendId, string accountId)
        {
            Chat chat = _friendData.GetFriendShip(accountId, friendId).Chat;
            if (chat == null)
                throw new ApiException(404, "Chat not found.");
            chat.SortByTime();
            return chat;
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
            if (wager == null)
                throw new ApiException(404, "Wager not found.");
            Chat chat = _chatData.GetWagerChat(wager);
            chat.SortByTime();
            return chat;
        }
    }
}