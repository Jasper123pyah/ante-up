using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Message
    {
        [Key] public Guid Id { get; set; }
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        public Message()
        {
        }

        public Message(string senderName, string text)
        {
            SenderName = senderName;
            Text = text;
            Time = DateTime.Now;
        }
    }
}