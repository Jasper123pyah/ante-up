using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.HubModels;
using ante_up.Common.Models;

namespace ante_up.Data
{
    public class ChatData
    {
        private readonly AnteUpContext anteContext;
        public ChatData(AnteUpContext context)
        {
            anteContext = context;
        }

        public LobbyMessage SendMessage(LobbyMessage lobbyMessage)
        {
            Wager wager = new WagerData(anteContext).GetById(lobbyMessage.LobbyId);
            Message dataMessage = new Message()
            {
                Id = Guid.NewGuid().ToString(),
                Sender = new AccountData(anteContext).GetAccountById(lobbyMessage.Sender).Username,
                Text = lobbyMessage.Message
            };
            wager.Chat.Message.Add(dataMessage);
            anteContext.SaveChanges();

            LobbyMessage returnMessage = new()
            {
                LobbyId = wager.Id,
                Message = dataMessage.Text,
                Sender = dataMessage.Sender
            };
            return returnMessage;
        }

    }
}