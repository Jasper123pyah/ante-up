using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class PlayerStats
    {
        [Key]
        public Guid Id { get; set; }
    }
}