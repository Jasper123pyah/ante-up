using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.HubModels;
using ante_up.Common.DataModels;

namespace ante_up.Data
{
    public class ChatData
    {
        private readonly AnteUpContext _anteContext;
        private readonly AccountData _accountData;
        private readonly FriendData _friendData;
        private readonly WagerData _wagerData;
        public ChatData(AnteUpContext context)
        {
            _anteContext = context;
            _accountData = new AccountData(context);
            _friendData = new FriendData(context);
            _wagerData = new WagerData(context);
        }

        public void SendLobbyMessage(LobbyMessage lobbyMessage)
        {
            Wager wager = _wagerData.GetById(lobbyMessage.LobbyId);
            Message message = new()
            {
                Time = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                Sender = _accountData.GetAccountById(lobbyMessage.Sender)?.Username,
                Text = lobbyMessage.Message
            };
            wager.Chat.Message.Add(message);
            _anteContext.SaveChanges();
        }
        public Chat GetFriendChat(string friendId, string accountId)
        {
            return _friendData.GetFriendShip(accountId, friendId).Chat;
        }
        public void SendFriendMessage(string receiver, string senderId, string message)
        {
            string? receiverId = _accountData.GetAccountIdByUsername(receiver);
            Chat chat = GetFriendChat(receiverId!, senderId);
            chat.Message.Add(new Message()
            {
                Time = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                Text = message,
                Sender = senderId
            });
            _anteContext.SaveChanges();
        }

        public Chat? GetWagerChat(string lobbyId)
        {
            Wager wager = _wagerData.GetById(lobbyId);
            return wager.Chat;
        }
    }
}