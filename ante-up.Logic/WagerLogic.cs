using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.Models;
using ante_up.Common.ViewModels;
using ante_up.Data;

namespace ante_up.Logic
{
    public class WagerLogic
    {
        private readonly WagerData wagerData;
        private readonly AccountData accountData;
        public WagerLogic(AnteUpContext context)
        {
            wagerData = new WagerData(context);
            accountData = new AccountData(context);
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

        public ViewWager GetWagerById(string id)
        {
            return ConvertWager(wagerData.GetById(id));
        }
        public List<ViewWager> GetWagersInGame(string gameName)
        {
            return wagerData.GetWagerByGame(gameName).Select(wager => ConvertWager(wager)).ToList();
        }
        
        private ViewWager ConvertWager(Wager wager)
        {
            ViewWager viewWager = new()
            {
                Id = wager.Id,
                Game = wager.Game,
                Title = wager.Title,
                Description = wager.Description,
                HostId = wager.HostId,
                HostName = wager.HostName,
                Ante = wager.Ante,
                PlayerCap = wager.PlayerCap,
                Team1 = new ViewTeam()
                {
                    Id = wager.Team1.Id,
                    Players = ConvertAccounts(wager.Team1.Players)
                },
                Team2 = new ViewTeam()
                {
                    Id = wager.Team2.Id,
                    Players = ConvertAccounts(wager.Team2.Players)
                }
            };
            return viewWager;
        }

        private List<ViewAccount> ConvertAccounts(List<Account> accounts)
        {
            return accounts.Select(account => new ViewAccount()
            {
                Id = account.Id, Username = account.Username, TeamId = account.Team.Id
            }).ToList();
        }
        
        public string AddNewWager(ApiWager newWager)
        {
            string id = Guid.NewGuid().ToString();
            Wager wager = new()
            {
                Id = id,
                Game = newWager.Game,
                Title = newWager.Title,
                Description = newWager.Description,
                Ante = newWager.Ante,
                PlayerCap = GetPlayerCap(newWager.LobbySize),
                HostId =  newWager.CreatorId,
                HostName = accountData.GetAccountById(newWager.CreatorId).Username,
                Team1 = new Team() 
                { 
                    Id = Guid.NewGuid().ToString(),
                    Players = new List<Account>()
                    {
                        accountData.GetAccountById(newWager.CreatorId)
                    } 
                },
                Team2 = new Team(){Id = Guid.NewGuid().ToString(),Players = new List<Account>()}
            };
            wagerData.AddNewWager(wager);
            
            return id;
        }
    }
}