using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.AdminModels;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Logic.JWT;

namespace ante_up.Logic
{
    public class AdminLogic
    {
        private readonly IAccountData _accountData;
        private readonly IFriendData _friendData;

        public AdminLogic(IAccountData accountData, IFriendData friendData)
        {
            _accountData = accountData;
            _friendData = friendData;
        }

        public List<AdminAccount> GetAllAdminAccounts(string token)
        {
            if (JWTLogic.CheckAdminToken(token))
                return GetAllAccounts().Select(account => CreateAdminAccountModel(account)).ToList();

            throw new ApiException(401, "Invalid Token.");
        }
        private AdminAccount CreateAdminAccountModel(Account account)
        {
            return new AdminAccount(account.Id.ToString(), account.Email, account.Username, account.Balance,
                _friendData.GetFriends(account.Id.ToString()), account.Stats, account.Team);
        }

        private List<Account> GetAllAccounts()
        {
            return _accountData.GetAllAccounts();
        }

        public void RemoveAccount(string accountId)
        {
            Account account = _accountData.GetAccountById(accountId);
            _accountData.DeleteAccount(account);
        }
    }
}