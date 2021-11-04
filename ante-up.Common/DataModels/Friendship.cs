using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Friendship
    {
        [Key]
        public Guid Id { get; set; }
        public Chat Chat { get; set; }
        public string AccountId1 { get; set; }
        public string AccountId2 { get; set; }

        public Friendship(){}
        public Friendship(string accountId1, string accountId2)
        {
            Chat = new Chat();
            AccountId1 = accountId1;
            AccountId2 = accountId2;
        }
    }
}