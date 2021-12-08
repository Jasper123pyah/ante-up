using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class GameStats
    {
        [Key] 
        public Guid Id { get; set; }
        public string GameName { get; set; }
        public string GamerTag { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Earnings { get; set; }
        public int Elo { get; set; }
        
        public GameStats(string gameName)
        {
            GameName = gameName;
            Elo = 1500;
        }
    }
}