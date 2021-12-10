using ante_up.Common.ApiModels;
using ante_up.Common.ApiModels.Responses;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Logic.JWT;

namespace ante_up.Logic.Services
{
    public class AccountLogic
    {
        private readonly IAccountData _accountData;

        public AccountLogic(IAccountData accountData)
        {
            _accountData = accountData;
        }

        public Account GetAccountById(string accountId)
        {
            Account account = _accountData.GetAccountById(accountId);
            if (account == null)
                throw new ApiException(404, "Account not found.");
            return account;
        }

        public Account GetAccountByUserName(string userName)
        {
            Account account = GetAccountById(_accountData.GetAccountIdByUsername(userName));
            if (account == null)
                throw new ApiException(404, "Account not found.");
            return account;
        }

        private Account GetAccountByEmail(string email)
        {
            Account account =  GetAccountById(_accountData.GetAccountIdByEmail(email));
            if (account == null)
                throw new ApiException(404, "Account not found.");
            return account;
        }
        public void SaveConnectionId(string accountId, string connectionId)
        {
            Account account = GetAccountById(accountId);
            _accountData.SaveConnectionId(connectionId, account);   
        }

        public void RemoveConnectionId(string accountId, string connectionId)
        {
            Account account = GetAccountById(accountId);
            _accountData.RemoveConnectionId(connectionId, account);
        }
        public ApiAccountInfo GetAccountInfo(string accountId)
        {
            Account account = GetAccountById(accountId);

            ApiAccountInfo accountInfo = new()
            {
                Id = account.Id.ToString(),
                Username = account.Username,
                Balance = account.Balance,
                Email = account.Email
            };

            return accountInfo;
        }

        public ApiLogin LoginCheck(string accountEmail, string password)
        {
            Account account = GetAccountByEmail(accountEmail);
            
            if (!BCrypt.Net.BCrypt.Verify(password, account.Password))
                throw new ApiException(401, "Incorrect password.");
            if (account.IsAdmin)
                return new ApiLogin()
                {
                    Username = account.Username,
                    Token = JWTLogic.GetToken(
                        JWTLogic.GetAdminJWTContainerModel(account.Username, account.Id.ToString()))
                };
            
            ApiLogin login = new()
            {
                Username = account.Username, 
                Token = JWTLogic.GetToken(JWTLogic.GetJWTContainerModel(account.Username, account.Id.ToString()))
            };

            return login;
        }

        public ApiLogin Register(ApiAccount account)
        {
            if (_accountData.GetAccountIdByEmail(account.Email) != null)
                throw new ApiException(409, "Email is already taken.");
            if (_accountData.GetAccountIdByUsername(account.Username) != null)
                throw new ApiException(409, "Username is already taken.");

            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            _accountData.Register(new Account(account.Email, account.Username, account.Password));
           
            
            ApiLogin login = new()
            {
                Username = account.Username, 
                Token = JWTLogic.GetToken(JWTLogic.GetJWTContainerModel(account.Username,  _accountData.GetAccountIdByEmail(account.Email)))
            };

            return login;
        }
        
    }
}