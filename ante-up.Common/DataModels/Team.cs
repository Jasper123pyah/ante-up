using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Team
    {
        [Key]
        public string Id { get; set; }
        public List<Account> Players { get; set; }
    }
}