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
        public ChatData(AnteUpContext context)
        {
            _anteContext = context;
        }

        public void SendLobbyMessage(LobbyMessage lobbyMessage)
        {
            Wager wager = new WagerData(_anteContext).GetById(lobbyMessage.LobbyId);
            Message message = new()
            {
                Time = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                Sender = new AccountData(_anteContext).GetAccountById(lobbyMessage.Sender)?.Username,
                Text = lobbyMessage.Message
            };
            wager.Chat.Message.Add(message);
            _anteContext.SaveChanges();
        }
        public Chat GetFriendChat(string friendName, string accountId)
        {
            AccountData accountData = new(_anteContext);
            Account account = accountData.GetAccountById(accountId)!;
            string friendId = accountData.GetAccountByUsername(friendName)!.Id;
            
            return account.Friendships.FirstOrDefault(x => x.AccountId1 == friendId || x.AccountId2 == friendId)
                ?.Chat!;
        }
        public void SendFriendMessage(string receiver, string senderId, string message)
        {
            string receiverId = new AccountData(_anteContext).GetAccountByUsername(receiver)?.Id!;
            Chat chat = GetFriendChat(receiverId, senderId);
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
            Wager wager = new WagerData(_anteContext).GetById(lobbyId);
            return wager.Chat;
        }
    }
}