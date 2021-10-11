using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class AccountData
    {
        private readonly AnteUpContext anteContext;
        public AccountData(AnteUpContext context)
        {
            anteContext = context;
        }
        
        public void Register(ApiAccount account)
        {
            anteContext.Account.Add(new Account
            {
                Id = Guid.NewGuid().ToString(),
                Balance = 0,
                Email = account.Email,
                Username = account.Username,
                Password = account.Password,
                Friends = new List<Friend>()
            });
            anteContext.SaveChanges();
        }
        public Account GetAccountByEmail(string accountEmail)
        {
            return anteContext.Account.Include(x => x.Team).ThenInclude(x => x.Players).FirstOrDefault(e => e.Email == accountEmail);
            
        }
        public Account GetAccountByUsername(string username)
        {
            return anteContext.Account.Include(x => x.Team).ThenInclude(x => x.Players)
                .FirstOrDefault(e => e.Username == username);
        }
        public Account GetAccountById(string id)
        {
            return anteContext.Account.Include(x => x.Team).ThenInclude(x => x.Players).FirstOrDefault(e => e.Id == id);
        }
    }
}