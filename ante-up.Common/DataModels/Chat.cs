using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ante_up.Common.DataModels
{
    public class Chat
    {
        [Key]
        public Guid Id { get; set; }

        public List<Message> Messages { get; private set; }

        public Chat()
        {
            Messages = new List<Message>();
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
        public void SortByTime()
        {
            Messages = Messages.OrderBy(x => x.Time).ToList();
        }
    }
}