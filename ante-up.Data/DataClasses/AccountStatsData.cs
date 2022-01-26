using System;
using System.Linq;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Common.Interfaces.Data.Context;

namespace ante_up.Data.DataClasses
{
    public class AccountStatsData : IAccountStatsData
    {
        private readonly IAnteUpContext _anteContext;

        public AccountStatsData(IAnteUpContext context)
        {
            _anteContext = context;
        }

        public void AddGamerTag(Account account, string game, string tag)
        {
            if (account.HasGameStats(game))
                account.GetGameStats(game).GamerTag = tag;
            else
            {
                GameStats gameStats = new GameStats(game)
                {
                    GamerTag = tag
                };
                account.GameStats.Add(gameStats);
            }
            _anteContext.SaveChanges();
        }
    }
}