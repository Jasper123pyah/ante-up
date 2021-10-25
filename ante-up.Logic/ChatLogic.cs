using System.Linq;
using ante_up.Common.DataModels;
using ante_up.Data;

namespace ante_up.Logic
{
    public class ChatLogic
    {
        public Chat SortChat(Chat chat)
        {
            chat.Message = chat.Message.OrderBy(x => x.Time).ToList();
            return chat;
        }
    }
}