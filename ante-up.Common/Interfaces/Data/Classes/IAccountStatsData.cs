using ante_up.Common.DataModels;

namespace ante_up.Common.Interfaces.Data.Classes
{
    public interface IAccountStatsData
    {
        void AddGamerTag(Account account, string game, string tag);
    }
}