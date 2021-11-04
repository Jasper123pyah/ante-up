using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.HubModels;
using ante_up.Common.ViewModels;
using ante_up.Data;

namespace ante_up.Logic
{
    public class WagerLogic
    {
        private readonly WagerData _wagerData;
        private readonly AccountData _accountData;
        public WagerLogic(AnteUpContext context)
        {
            _wagerData = new WagerData(context);
            _accountData = new AccountData(context);
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
        
        public ViewWager CreateViewWager(Wager wager)
        {
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
            
            Wager currentWager = _wagerData.GetAccountWager(account.Id.ToString());
            if(currentWager != null)
                _wagerData.LeaveWager(currentWager, account.Id.ToString());
            
            wager.Team1.Players.Add(account);
            account.SetTeam(wager.Team1);
            
            return _wagerData.AddNewWager(wager);
        }

        public void LeaveWager( ApiLobby apiLobby)
        {
            Wager wager = _wagerData.GetById(apiLobby.WagerId);
            _wagerData.LeaveWager(wager, apiLobby.PlayerId);
        }
    }
}