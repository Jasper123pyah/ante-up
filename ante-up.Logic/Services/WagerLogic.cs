using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.ApiModels.Responses;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Common.ViewModels;
using ante_up.Logic.JWT;

namespace ante_up.Logic.Services
{
    public class WagerLogic
    {
        private readonly IWagerData _wagerData;
        private readonly IAccountData _accountData;

        public WagerLogic(IWagerData wagerData, IAccountData accountData)
        {
            _wagerData = wagerData;
            _accountData = accountData;
        }

        public Wager GetWagerById(string wagerId)
        {
            return _wagerData.GetById(wagerId);
        }

        private int GetPlayerCap(string lobbySize)
        {
            return lobbySize switch
            {
                "1v1" => 2,
                "2v2" => 4,
                "3v3" => 6,
                "4v4" => 8,
                "5v5" => 10,
                "6v6" => 12,
                _ => 0
            };
        }

        public List<ViewWager> GetRecommendedWagers()
        {
            // get account most played game 
            // get fullest wagers in that game
            // no most played game? fulled wagers anywhere
            return new List<ViewWager>();
        }

        public ViewWager CreateViewWager(string wagerId)
        {
            Wager wager = _wagerData.GetById(wagerId);
            if (wager != null)
            {
                wager.Chat.SortByTime();

                ViewWager viewWager = ConvertWager(wager);
                return viewWager;
            }
            else
            {
                throw new ApiException(404, "Wager not found.");
            }
        }

        public List<ViewWager> GetWagersInGame(string gameName)
        {
            List<Wager> wagers = _wagerData.GetWagerByGame(gameName).ToList();
            if (wagers == null)
                throw new ApiException(404, "No wagers.");
            return wagers.Select(wager => ConvertWager(wager)).ToList();
        }

        private static ViewWager ConvertWager(Wager wager)
        {
            ViewWager viewWager = new()
            {
                Id = wager.Id.ToString(),
                Game = wager.Game,
                Title = wager.Title,
                Description = wager.Description,
                HostId = wager.HostId,
                HostName = wager.HostName,
                Ante = wager.Ante,
                PlayerCap = wager.PlayerCap,
                Team1 = new ViewTeam()
                {
                    Id = wager.Team1.Id.ToString(),
                    Players = ConvertAccounts(wager.Team1.Players, wager.Game)
                },
                Team2 = new ViewTeam()
                {
                    Id = wager.Team2.Id.ToString(),
                    Players = ConvertAccounts(wager.Team2.Players, wager.Game)
                },
                Chat = wager.Chat
            };
            return viewWager;
        }

        private static List<ViewAccount> ConvertAccounts(IEnumerable<Account> accounts, string game)
        {
            return accounts.Select(account => new ViewAccount()
            {
                Username = account.Username,
                TeamId = account.Team.Id.ToString(),
                GameStats = new ApiGameStats(account.GetGameStats(game))
            }).ToList();
        }

        public int LeaveWager(string wagerId, string accountId)
        {
            Account account = _accountData.GetAccountById(accountId)!;
            Wager wager = _wagerData.GetById(wagerId);

            _wagerData.RemoveFromTeam(wager, account);
            if (wager != null && wager.HostId == account.Id.ToString())
            {
                if (wager.Team1.Players.FirstOrDefault()?.Id != null)
                    _wagerData.ChangeHost(wager, wager.Team1.Players.FirstOrDefault()?.Id.ToString());
                else if (wager.Team2.Players.FirstOrDefault()?.Id != null)
                    _wagerData.ChangeHost(wager, wager.Team2.Players.FirstOrDefault()?.Id.ToString());
                else
                {
                    _wagerData.DeleteWager(wager);
                    return 0;
                }
            }

            return wager.Team1.Players.Count + wager.Team2.Players.Count;
        }

        public void JoinTeam(string accountId, string wagerId, int teamNumber)
        {
            Account account = _accountData.GetAccountById(accountId);
            Wager wager = _wagerData.GetById(wagerId);
            Wager currentWager = _wagerData.GetAccountWager(account);

            if (currentWager != null && currentWager != wager)
                LeaveWager(currentWager.Id.ToString(), accountId);

            _wagerData.JoinTeam(wager, account, teamNumber);
        }

        public string AddNewWager(ApiWager newWager, string token)
        {
            string creatorId = JWTLogic.GetId(token);
            if (creatorId == null)
                throw new ApiException(401, "Invalid Token.");
            Account account = _accountData.GetAccountById(creatorId);
            if (account == null)
                throw new ApiException(404, "Account not found.");

            Wager wager = new(
                newWager.Game,
                newWager.Title,
                newWager.Description,
                creatorId,
                account.Username,
                newWager.Ante,
                GetPlayerCap(newWager.LobbySize));

            Wager currentWager = _wagerData.GetAccountWager(account);
            if (currentWager != null)
                LeaveWager(currentWager.Id.ToString(), account.Id.ToString());

            wager.Team1.Players.Add(account);
            account.SetTeam(wager.Team1);

            return _wagerData.AddWager(wager);
        }
    }
}