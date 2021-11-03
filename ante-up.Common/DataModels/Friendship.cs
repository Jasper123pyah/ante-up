using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Friendship
    {
        [Key]
        public Guid Id { get; set; }
        public Chat Chat { get;  }
        public string AccountId1 { get;  }
        public string AccountId2 { get;  }

        public Friendship(string accountId1, string accountId2)
        {
            Chat = new Chat();
            AccountId1 = accountId1;
            AccountId2 = accountId2;
        }
    }
}