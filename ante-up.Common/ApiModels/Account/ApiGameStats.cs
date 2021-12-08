using ante_up.Common.DataModels;

namespace ante_up.Common.ApiModels
{
    public class ApiGameStats
    {
        public string GameName { get; set; }
        public string GamerTag { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Earnings { get; set; }
        public int Elo { get; set; }

        public ApiGameStats(GameStats gameStats)
        {
            GamerTag = gameStats.GamerTag;
            GameName = gameStats.GameName;
            Elo = gameStats.Elo;
        }
    }
}