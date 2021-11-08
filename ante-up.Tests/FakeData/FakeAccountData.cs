using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;

namespace ante_up.Tests.FakeData
{
    public class FakeAccountData : IAccountData
    {
        private List<Account> Accounts;

        public FakeAccountData()
        {
            Accounts = new List<Account>();
        }

        public void DeleteAccount(Account account)
        {
            Accounts.Remove(account);
        }

        public void RemoveConnectionId(string connectionId, Account account)
        {
            ConnectionId connection = account.ConnectionIds.FirstOrDefault(x => x.Connection == connectionId)!;
            account.ConnectionIds.Remove(connection);
        }

        public void SaveConnectionId(string connectionId, Account account)
        {
            account.AddConnectionId(connectionId);
        }

        public void Register(Account account)
        {
            Accounts.Add(account);
        }

        public string GetAccountIdByEmail(string accountEmail)
        {
            return Accounts.FirstOrDefault(x => x.Email == accountEmail)?.Id.ToString();
        }

        public string GetAccountIdByUsername(string username)
        {
            return Accounts.FirstOrDefault(x => x.Username == username)?.Id.ToString();
        }

        public Account GetAccountById(string id)
        {
            return Accounts.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public List<Account> GetAllAccounts()
        {
            return Accounts;
        }
    }
}