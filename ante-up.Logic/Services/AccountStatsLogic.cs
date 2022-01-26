using System;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.ApiModels.Responses;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Logic.JWT;

namespace ante_up.Logic.Services
{
    public class AccountStatsLogic
    {
        private readonly IAccountData _accountData;
        private readonly IAccountStatsData _accountStatsData;
        private readonly AccountLogic _accountLogic;
        private readonly WagerLogic _wagerLogic;

        public AccountStatsLogic(IAccountData accountData, IWagerData wagerData, IAccountStatsData accountStatsData)
        {
            _accountData = accountData;
            _accountLogic = new AccountLogic(accountData);
            _wagerLogic = new WagerLogic(wagerData, accountData);
            _accountStatsData = accountStatsData;
        }

        public void AddGamerTag(string token, string game, string tag)
        {
            Account account = _accountLogic.GetAccountById(JWTLogic.GetId(token));
            _accountStatsData.AddGamerTag(account, game, tag);
        }
        public string GetGamerTagFromLobby(string token, string lobbyId)
        {
            Account account = _accountLogic.GetAccountById(JWTLogic.GetId(token));
            string gameName = _wagerLogic.GetWagerById(lobbyId).Game;

            if (account.GameStats.All(x => x.GameName != gameName))
                throw new ApiException(404, gameName);
            return account.GameStats.FirstOrDefault(x => x.GameName == gameName)?.GamerTag;
        }
        
        private void CalculateELO(ref int playerOneRating, ref int playerTwoRating)
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
            ApiAccountStats apiAccountStats = new (account.Username, account.Created,
                account.WagerResults, account.GameStats);

            return apiAccountStats;
        }
    }
}