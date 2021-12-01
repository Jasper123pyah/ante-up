using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class PlayerStats
    {
        [Key]
        public Guid Id { get; set; }
        public string GameName { get; set; }
        public string Record { get; set; }
        public int Earnings { get; set; }
        public string Skill { get; set; } 
        
        public PlayerStats()
        {
        }

        public PlayerStats(string gameName, string record, int earnings, string skill)
        {
            GameName = gameName;
            Record = record;
            Earnings = earnings;
            Skill = skill;
        }
    }
}