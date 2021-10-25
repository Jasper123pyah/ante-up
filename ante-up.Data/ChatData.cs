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

        public void SendMessage(LobbyMessage lobbyMessage)
        {
            Wager wager = new WagerData(anteContext).GetById(lobbyMessage.LobbyId);
            Message message = new()
            {
                Time = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                Sender = new AccountData(anteContext).GetAccountById(lobbyMessage.Sender).Username,
                Text = lobbyMessage.Message
            };
            wager.Chat.Message.Add(message);
            anteContext.SaveChanges();
        }

        public Chat GetWagerChat(string lobbyId)
        {
            Wager wager = new WagerData(anteContext).GetById(lobbyId);
            return wager?.Chat;
        }
    }
}