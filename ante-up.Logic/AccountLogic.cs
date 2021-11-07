using System.Collections.Generic;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Logic.JWT;

namespace ante_up.Logic
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
            return _accountData.GetAccountById(accountId);
        }

        public Account GetAccountByUserName(string userName)
        {
            return GetAccountById(_accountData.GetAccountIdByUsername(userName));
        }

        private Account GetAccountByEmail(string email)
        {
            return GetAccountById(_accountData.GetAccountIdByEmail(email));
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
            if (account == null)
                return null;

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

            if (account == null)
                throw new ApiException(404, "There is no account with this email.");
            if (!BCrypt.Net.BCrypt.Verify(password, account.Password))
                throw new ApiException(401, "Incorrect password.");
            if (account.Id.ToString() == "")
                return new ApiLogin()
                {
                    Username = account.Username,
                    Token = JWTLogic.GetToken(
                        JWTLogic.GetAdminJWTContainerModel(account.Username, account.Id.ToString()))
                };
            
            ApiLogin login = new()
            {
                Username = account.Username, Token = JWTLogic.GetToken(JWTLogic.GetJWTContainerModel(account.Username, account.Id.ToString()))
            };

            return login;
        }

        public void Register(ApiAccount account)
        {
            if (_accountData.GetAccountIdByEmail(account.Email) != null)
                throw new ApiException(409, "Email is already taken.");
            if (_accountData.GetAccountIdByUsername(account.Username) != null)
                throw new ApiException(409, "Username is already taken.");

            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            _accountData.Register(new Account(account.Email, account.Username, account.Password));
        }

        public List<Account> GetAllAccounts(string token)
        {
            if (JWTLogic.CheckAdminToken(token))
                return _accountData.GetAllAccounts();
            throw new ApiException(401, "Token is valid.");
        }
        
        public void RemoveAccount(string accountId)
        {
            Account account = GetAccountById(accountId);
            _accountData.DeleteAccount(account);
        }
    }
}