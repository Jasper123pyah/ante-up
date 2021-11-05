using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Team
    {
        [Key] public Guid Id { get; set; }
        public List<Account> Players { get; set; }

        public Team()
        {
            Players = new List<Account>();
        }

    }
}