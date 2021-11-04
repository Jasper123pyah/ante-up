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
                Id = id,
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
                throw new ApiException(404, "Account not found.");
            if (!BCrypt.Net.BCrypt.Verify(password, account.Password))
                throw new ApiException(401, "Wrong password.");
            else
            {
                login.Token = new JWTLogic().GetToken(account.Username, account.Id.ToString());
                login.Username = account.Username;
            }
                 
            return login ;
        }
        public void Register(ApiAccount account)
        {
            if (accountData.GetAccountIdByEmail(account.Email) != null)
                throw new ApiException(409, "Email is already taken.");
            if (accountData.GetAccountIdByUsername(account.Username) != null)
                throw new ApiException(409, "Username is already taken.") ; ;

            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            if(_anteUpContext != null)
                accountData.Register(account);
        }
    }
}