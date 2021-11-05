using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.HubModels;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data;
using ante_up.Common.Interfaces.Data.Classes;

namespace ante_up.Data
{
    public class ChatData : IChatData
    {
        private readonly IAnteUpContext _anteContext;

        public ChatData(IAnteUpContext context)
        {
            _anteContext = context;
        }

        public void SendWagerMessage(Wager wager, Message message)
        {
            wager.Chat.AddMessage(message);
            _anteContext.SaveChanges();
        }
        
        public void SendFriendMessage(Chat chat, Message message)
        {
            chat.AddMessage(message);
            _anteContext.SaveChanges();
        }

        public Chat GetWagerChat(Wager wager)
        {
            return wager.Chat;
        }
    }
}