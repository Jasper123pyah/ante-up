using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class AccountData
    {
        private readonly AnteUpContext _anteContext;

        public AccountData(AnteUpContext context)
        {
            _anteContext = context;
        }

        public void DeleteAccount(string accountId)
        {
            Account ?account = _anteContext.Account.FirstOrDefault(x => x.Id == accountId);
            _anteContext.Account.Remove(account);
        }
        public List<string> GetConnectionIds(string accountId)
        {
            Account account = GetAccountById(accountId)!;
            return account.ConnectionIds.Select(connId => connId.Connection).ToList();
        }


        public void RemoveConnectionId(string connectionId, string accountId)
        {
            Account? account = GetAccountById(accountId);
            ConnectionId connection = account.ConnectionIds.FirstOrDefault(x => x.Connection == connectionId);
            _anteContext.ConnectionId.Remove(connection);
            _anteContext.SaveChanges();
        }

        public void SaveConnectionId(string connectionId, string accountId)
        {
            Account? account = GetAccountById(accountId);
            account?.ConnectionIds.Add(new ConnectionId() {Id = Guid.NewGuid().ToString(), Connection = connectionId});
            _anteContext.SaveChanges();
        }

        public void Register(ApiAccount account)
        {
            _anteContext.Account.Add(new Account
            {
                Id = Guid.NewGuid().ToString(),
                Balance = 0,
                Email = account.Email,
                Username = account.Username,
                Password = account.Password,
                ConnectionIds = new List<ConnectionId>()
            });
            _anteContext.SaveChanges();
        }

        public string? GetAccountIdByEmail(string accountEmail)
        {
            return _anteContext.Account.FirstOrDefault(e => e.Email == accountEmail)?.Id;
        }

        public string? GetAccountIdByUsername(string username)
        {
            return _anteContext.Account.FirstOrDefault(e => e.Username == username)?.Id;
        }

        public Account? GetAccountById(string? id)
        {
            return _anteContext.Account.Include(x => x.ConnectionIds)
                .Include(x => x.FriendRequests)
                .Include(x => x.Team)
                .ThenInclude(x => x.Players)
                .FirstOrDefault(e => e.Id == id);
        }
    }
}