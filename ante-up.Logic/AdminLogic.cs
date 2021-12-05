using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.AdminModels;
using ante_up.Common.ApiModels;
using ante_up.Common.ApiModels.Responses;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Logic.JWT;

namespace ante_up.Logic
{
    public class AdminLogic
    {
        private readonly IAccountData _accountData;
        private readonly IFriendData _friendData;
        private readonly IWagerData _wagerData;
        public AdminLogic(IAccountData accountData, IFriendData friendData, IWagerData wagerData)
        {
            _accountData = accountData;
            _friendData = friendData;
            _wagerData = wagerData;
        }

        public List<AdminAccount> GetAllAdminAccounts(string token)
        {
            if (JWTLogic.CheckAdminToken(token))
                return GetAllAccounts().Select(account => CreateAdminAccountModel(account)).ToList();

            throw new ApiException(403, "Not an admin.");
        }

        private AdminAccount CreateAdminAccountModel(Account account)
        {
            return new(account.Id.ToString(), account.Email, account.Username, account.Balance,
                ConvertFriendships(account.Id.ToString()),account.WagerResults, account.GameStats, _wagerData.GetAccountWager(account));
        }

        private List<AdminFriend> ConvertFriendships(string accountId)
        {
            List<Friendship> friends = _friendData.GetFriends(accountId);

            return friends.Select(friendship => new AdminFriend(friendship.Id.ToString(), _friendData.GetFriendName(accountId, friendship), friendship.Chat)).ToList();
        }

        private IEnumerable<Account> GetAllAccounts()
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