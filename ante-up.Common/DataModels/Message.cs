using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        public string SenderName { get; }
        public string Text { get;  }
        public DateTime Time { get;  }

        public Message(string senderName, string text)
        {
            SenderName = senderName;
            Text = text;
            Time = DateTime.Now;
        }
    }
}