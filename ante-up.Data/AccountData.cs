using System;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.Models;

namespace ante_up.Data
{
    public class AccountData
    {
        private readonly AnteUpContext anteContext;
        public AccountData(AnteUpContext context)
        {
            anteContext = context;
        }
        public bool Register(ApiAccount account)
        {
            anteContext.Account.Add(new Account()
            {
                Balance = account.Balance,
                Email = account.Email,
                Username = account.Username,
                Password = account.Password
            });
            anteContext.SaveChanges();

            return GetAccount(account.Email) != null;
        }
        public Account GetAccount(string accountEmail)
        {
            return anteContext.Account.FirstOrDefault(e => e.Email == accountEmail);
        }
    }
}