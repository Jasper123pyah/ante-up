using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Common.Interfaces.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data.DataClasses
{
    public class AccountData : IAccountData
    {
        private readonly IAnteUpContext _anteContext;

        public AccountData(IAnteUpContext context)
        {
            _anteContext = context;
        }

        public void DeleteAccount(Account account)
        {
            _anteContext.Account.Remove(account);
            _anteContext.SaveChanges();
        }

        public void RemoveConnectionId(string connectionId, Account account)
        {
            ConnectionId connection = account.ConnectionIds.FirstOrDefault(x => x.Connection == connectionId)!;
            _anteContext.ConnectionId.Remove(connection);
            _anteContext.SaveChanges();
        }

        public void SaveConnectionId(string connectionId, Account account)
        {
            account.AddConnectionId(connectionId);
            _anteContext.SaveChanges();
        }

        public void Register(Account account)
        {
            _anteContext.Account.Add(account);
            _anteContext.SaveChanges();
        }

        public string? GetAccountIdByEmail(string accountEmail)
        {
            return _anteContext.Account.FirstOrDefault(e => e.Email == accountEmail)?.Id.ToString();
        }

        public string? GetAccountIdByUsername(string username)
        {
            return _anteContext.Account.FirstOrDefault(e => e.Username == username)?.Id.ToString();
        }

        public Account? GetAccountById(string? id)
        {
            return _anteContext.Account.Include(x => x.ConnectionIds)
                .Include(x => x.Transactions)
                .ThenInclude(x => x.Actions)
                .Include(x=> x.GameStats)
                .Include(x => x.WagerResults)
                .Include(x => x.FriendRequests)
                .Include(x => x.Team)
                .ThenInclude(x => x.Players)
                .FirstOrDefault(a => a.Id.ToString() == id);
        }

        public List<Account> GetAllAccounts()
        {
            return _anteContext.Account.Include(x => x.Team).ThenInclude(x => x.Players).ToList();
        }
    }
}