using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.HubModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Common.ViewModels;

namespace ante_up.Logic
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

        public ViewWager CreateViewWager(string wagerId)
        {
            Wager wager = _wagerData.GetById(wagerId);
            wager.Chat.SortByTime();

            ViewWager viewWager = ConvertWager(wager);
            return viewWager;
        }

        public List<ViewWager> GetWagersInGame(string gameName)
        {
            return _wagerData.GetWagerByGame(gameName).Select(wager => ConvertWager(wager)).ToList();
        }

        private ViewWager ConvertWager(Wager wager)
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
                    Players = ConvertAccounts(wager.Team1.Players)
                },
                Team2 = new ViewTeam()
                {
                    Id = wager.Team2.Id.ToString(),
                    Players = ConvertAccounts(wager.Team2.Players)
                },
                Chat = wager.Chat
            };
            return viewWager;
        }

        private List<ViewAccount> ConvertAccounts(List<Account> accounts)
        {
            return accounts.Select(account => new ViewAccount()
            {
                Id = account.Id.ToString(),
                Username = account.Username,
                TeamId = account.Team.Id.ToString()
            }).ToList();
        }

        public void LeaveWager(string wagerId, string accountId)
        {
            Account account = _accountData.GetAccountById(accountId)!;
            Wager wager = _wagerData.GetById(wagerId);
            
            _wagerData.RemoveFromTeam(wager, account);
            if (wager.HostId == account.Id.ToString())
            {
                if (wager.Team1.Players.FirstOrDefault()?.Id != null)
                    _wagerData.ChangeHost(wager, wager.Team1.Players.FirstOrDefault()?.Id.ToString());  
                else if (wager.Team2.Players.FirstOrDefault()?.Id != null)
                    _wagerData.ChangeHost(wager, wager.Team2.Players.FirstOrDefault()?.Id.ToString());
                else _wagerData.DeleteWager(wager);
            }
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
        public string AddNewWager(ApiWager newWager)
        {
            Account account = _accountData.GetAccountById(newWager.CreatorId);
            Wager wager = new(
                newWager.Game,
                newWager.Title,
                newWager.Description,
                newWager.CreatorId,
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