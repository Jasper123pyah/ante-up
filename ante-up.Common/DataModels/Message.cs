using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Message
    {
        [Key]
        public string Id { get; set; }
        public string Sender { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}