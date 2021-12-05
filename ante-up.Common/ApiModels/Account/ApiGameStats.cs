using ante_up.Common.DataModels;

namespace ante_up.Common.ApiModels
{
    public class ApiGameStats
    {
        public string GameName { get; set; }
        public int WinRate { get; set; }
        public int Earnings { get; set; }
        public string Skill { get; set; }

        public ApiGameStats(GameStats gameStats)
        {
            GameName = gameStats.GameName;
            Skill = gameStats.Skill;
        }
    }
}