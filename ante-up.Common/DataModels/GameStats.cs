using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class GameStats
    {
        [Key] 
        public Guid Id { get; set; }
        public string GameName { get; set; }
        public string Skill { get; set; }
        
        public GameStats(string gameName, string skill)
        {
            GameName = gameName;
            Skill = skill;
        }
    }
}