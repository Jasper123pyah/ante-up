using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Data;
using ante_up.Logic.JWT;

namespace ante_up.Logic
{
    public class AccountLogic
    {
        private readonly AccountData accountData;
        private readonly AnteUpContext _anteUpContext;
        public AccountLogic(AnteUpContext context = null)
        {
             accountData = new AccountData(context!);
             _anteUpContext = context;
        }

        public ApiAccountInfo GetAccountInfo(string id)
        {
            Account acc = accountData.GetAccountById(id);
            if (acc == null)
                return null;
            
            ApiAccountInfo accountInfo = new()
            {
                Username = acc.Username,
                Balance = acc.Balance,
                Email = acc.Email
            };

            return accountInfo;
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
                login.Token = new JWTLogic().GetToken(account.Username, account.GetId());
                login.Response = account.GetId();
                login.Username = account.Username;
            }
                 
            return login ;
        }
        public string Register(ApiAccount account)
        {
            if (accountData.GetAccountIdByEmail(account.Email) != null)
                return "Email is already taken.";
            if (accountData.GetAccountIdByUsername(account.Username) != null)
                return "Username is already taken.";

            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            if(_anteUpContext != null)
                accountData.Register(account);
            return "";
        }
    }
}