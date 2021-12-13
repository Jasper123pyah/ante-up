using ante_up.Common.DataModels;

namespace ante_up.Common.Interfaces.Data.Classes
{
    public interface IBalanceData
    {
        void UpdateAccountBalance(Account account, int amount);
    }
}