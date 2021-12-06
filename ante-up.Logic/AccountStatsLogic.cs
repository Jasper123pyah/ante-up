using System;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Logic.JWT;

namespace ante_up.Logic
{
    public class AccountStatsLogic
    {
        private readonly IAccountData _accountData;
        private readonly AccountLogic _accountLogic;

        public AccountStatsLogic(IAccountData accountData)
        {
            _accountData = accountData;
            _accountLogic = new AccountLogic(accountData);
        }

        private int GetAccountRank(string id)
        {
            _accountData.GetAccountById(id);
            return 1;
        }   
        
        public void CalculateELO(ref int playerOneRating, ref int playerTwoRating)
        {
            double expectationToWin = 1 / (1 + Math.Pow(10, (playerTwoRating - playerOneRating) / 400.0));
            int delta = (int)(32 * (1 - expectationToWin));

            playerOneRating += delta;
            playerTwoRating -= delta;
        }
        
        public ApiAccountStats GetAccountStats(string token, string name)
        {
            string id = JWTLogic.GetId(token);
            Account account = _accountLogic.GetAccountById(_accountData.GetAccountIdByUsername(name));
            if (account.Id.ToString() == id) // user is looking at his own profile
            {
                // do something
            }
            ApiAccountStats apiAccountStats = new (account.Username, account.Created, account.GamerTags,
                account.WagerResults, account.GameStats);

            return apiAccountStats;
        }
    }
}