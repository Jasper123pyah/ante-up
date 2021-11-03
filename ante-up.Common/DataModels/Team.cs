using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        public List<Account> Players { get;  }
        
        public Team()
        {
            Players = new List<Account>();
        }

        public string GetId()
        {
            return Id.ToString();
        }
    }
}