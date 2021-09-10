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
        
        public AccountLogic(AnteUpContext context)
        {
             accountData = new AccountData(context);
        }

        public ApiLogin LoginCheck(ApiAccount account)
        {
            ApiLogin login = new();
            if (accountData.GetAccountByEmail(account.Email) == null)
                 login.Response = "1";
            if (accountData.GetAccountByEmail(account.Email).Password != account.Password)
                login.Response = "2";
            else
            {
                login.Response = accountData.GetAccountByEmail(account.Email).Id;
                login.Username = accountData.GetAccountByEmail(account.Email).Username;
            }
                
            return login ;
        }
        public string Register(ApiAccount account)
        {
            if (accountData.GetAccountByEmail(account.Email) != null)
                return "Email is already taken.";
            if (accountData.GetAccountByUsername(account.Username) != null)
                return "Username is already taken.";
            accountData.Register(account);
            return "";
        }
    }
}