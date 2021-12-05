using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;

namespace ante_up.Common.ApiModels
{
    public class ApiAccountStats
    {
        public string AccountName { get; set; }
        public DateTime Joined { get; set; }
        public List<GamerTag> GamerTags { get; set; }
        public int Elo { get; set; }
        public int Earnings { get; set; }
        public int Wins { get; set; } 
        public int Losses { get; set; }
        public List<WagerResult> RecentWagers { get; set; }
        public List<ApiGameStats> GameStats { get; set; }

        public ApiAccountStats(string accountName, int elo, DateTime joined, List<GamerTag> gamerTags, List<WagerResult> wagerResults, List<GameStats> gameStats)
        {
            AccountName = accountName;
            Joined = joined;
            GamerTags = gamerTags;
            Elo = elo;
            Earnings = wagerResults.Count != 0 ? GetEarnings(wagerResults) : 0;
            Wins = wagerResults.Count != 0 ? GetWins(wagerResults) : 0;
            Losses = wagerResults.Count != 0 ? GetLosses(wagerResults) : 0;
            GameStats = gameStats.Count != 0 ? ConvertGameStats(gameStats) : new List<ApiGameStats>();
            RecentWagers = wagerResults.Count != 0 ? GetRecentWagers(wagerResults) : new List<WagerResult>();
        }

        public List<ApiGameStats> ConvertGameStats(List<GameStats> gameStats)
        {
            return gameStats.Select(gameStat => new ApiGameStats(gameStat)).ToList();
        }

        public List<WagerResult> GetRecentWagers(List<WagerResult> wagerResults)
        {
            return wagerResults.OrderBy(x => x.WagerDate).Take(3).ToList();
        }

        private int GetEarnings(List<WagerResult> wagerResultsList)
        {
            return wagerResultsList.Sum(result => result.Earnings);
        }
        private int GetWins(List<WagerResult> wagerResultsList)
        {
            return wagerResultsList.Count(result => result.Earnings > 0);
        }
        private int GetLosses(List<WagerResult> wagerResultsList)
        {
            return wagerResultsList.Count(result => result.Earnings < 0);
        }
    }
}