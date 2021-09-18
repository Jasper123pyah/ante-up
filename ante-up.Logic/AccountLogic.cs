using System;
using System.Linq;
using System.Security.Claims;
using ante_up.Common;
using ante_up.Common.ApiModels;
using ante_up.Common.Models;
using ante_up.Data;

namespace ante_up.Logic
{
    public class AccountLogic
    {
        private readonly AccountData accountData;
        
        public AccountLogic(AnteUpContext context = null)
        {
             accountData = new AccountData(context);
        }

        public ApiLogin LoginCheck(Account account, string password)
        {
            ApiLogin login = new(){Username = ""};
            if (account == null)
                 login.Response = "1";
            else if (!BCrypt.Net.BCrypt.Verify(password,account.Password))
                login.Response = "2";
            else
            {
                login.Response = account.Id;
                login.Username = account.Username;
            }
                 
            return login ;
        }
        public string Register(ApiAccount account)
        {
            if (accountData.GetAccountByEmail(account.Email) != null)
                return "Email is already taken.";
            if (accountData.GetAccountByUsername(account.Username) != null)
                return "Username is already taken.";

            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            accountData.Register(account);
            return "";
        }
    }
}