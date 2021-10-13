using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.HubModels;
using ante_up.Common.DataModels;

namespace ante_up.Data
{
    public class ChatData
    {
        private readonly AnteUpContext anteContext;
        public ChatData(AnteUpContext context)
        {
            anteContext = context;
        }

        public Message SendMessage(LobbyMessage lobbyMessage)
        {
            Wager wager = new WagerData(anteContext).GetById(lobbyMessage.LobbyId);
            Message message = new()
            {
                Id = Guid.NewGuid().ToString(),
                Sender = new AccountData(anteContext).GetAccountById(lobbyMessage.Sender).Username,
                Text = lobbyMessage.Message
            };
            wager.Chat.Message.Add(message);
            anteContext.SaveChanges();
            
            return message;
        }
    }
}