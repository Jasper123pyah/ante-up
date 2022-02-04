using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Common.Interfaces.Data.Context;

namespace ante_up.Data.DataClasses
{
    public class BalanceData : IBalanceData
    {
        private readonly IAnteUpContext _anteContext;

        public BalanceData(IAnteUpContext context)
        {
            _anteContext = context;
        }

        public void UpdateAccountBalance(Account account, PaypalTransaction transaction)
        {
            account.AddBalance(transaction.Credits);
            account.Transactions.Add(transaction);
            _anteContext.SaveChanges();
        }
    }
}