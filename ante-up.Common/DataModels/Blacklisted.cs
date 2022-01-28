using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Blacklisted
    {
        [Key]
        public Guid Id { get; set; }
        public string AccountId { get; set; }
        
        public Blacklisted(){}

        public Blacklisted(string accountId)
        {
            AccountId = accountId;
        }
    }
}