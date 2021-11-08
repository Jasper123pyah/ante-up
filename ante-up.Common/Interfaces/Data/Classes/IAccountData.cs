using System.Collections.Generic;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;

namespace ante_up.Common.Interfaces.Data.Classes
{
    public interface IAccountData
    {
        void DeleteAccount(Account account);
        void RemoveConnectionId(string connectionId, Account account);

        void SaveConnectionId(string connectionId, Account account);

        void Register(Account account);

        string GetAccountIdByEmail(string accountEmail);

        string GetAccountIdByUsername(string username);

        Account GetAccountById(string id);
        List<Account> GetAllAccounts();
    }
}