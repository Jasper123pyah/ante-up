using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Chat
    {
        [Key]
        public string Id { get; set; }

        public List<Message> Message { get; set; }
    }
}