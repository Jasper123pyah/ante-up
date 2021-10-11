using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class WagerData
    {
        private readonly AnteUpContext anteContext;
        public WagerData(AnteUpContext context)
        {
            anteContext = context;
        }
        public void AddNewWager(Wager newWager)
        {
            if(GetAccountWager(newWager.HostId) != null)
                LeaveWager(GetAccountWager(newWager.HostId).Id, newWager.HostId);
            
            anteContext.Wager.Add(newWager);
            anteContext.SaveChanges();
        }
        
        public void LeaveWager(string wagerId, string playerId)
        {
            Wager wager = GetById(wagerId);
            Account account = new AccountData(anteContext).GetAccountById(playerId);
            
            RemoveFromTeam(wager, account);
            if (wager.HostId == account.Id)
            {
                if(wager.Team1.Players.FirstOrDefault()?.Id != null)
                    wager.HostId = wager.Team1.Players.FirstOrDefault()?.Id;
                else if (wager.Team2.Players.FirstOrDefault()?.Id != null)
                    wager.HostId = wager.Team2.Players.FirstOrDefault()?.Id;
                else DeleteWager(wager.Id);
            }
            anteContext.SaveChanges();
        }
        
        public void DeleteWager(string wagerId)
        {
            Wager wager = GetById(wagerId);
            anteContext.Team.RemoveRange(wager.Team1);
            anteContext.Team.RemoveRange(wager.Team2);
            anteContext.Wager.Remove(wager);
            anteContext.SaveChanges();
        }
        public Wager GetById(string id)
        {
            return anteContext.Wager.Include(team1 => team1.Team1)
                                    .ThenInclude(x => x.Players)
                                    .Include(team2 => team2.Team2)
                                    .ThenInclude(x => x.Players)
                                    .FirstOrDefault(wager => wager.Id == id);
        }

        public Wager GetAccountWager(string accountId)
        {
            Account account = new AccountData(anteContext).GetAccountById(accountId);
            if (account.Team == null)
                return null;
            if (anteContext.Wager.FirstOrDefault(e => e.Team1.Players.Contains(account)) != null)
                return anteContext.Wager.FirstOrDefault(e => e.Team1.Players.Contains(account));
            if (anteContext.Wager.FirstOrDefault(e => e.Team2.Players.Contains(account)) != null)
                return anteContext.Wager.FirstOrDefault(e => e.Team2.Players.Contains(account));
            return null;
            
        }

        public void RemoveFromTeam(Wager wager, Account account)
        {
            if (wager.Team1.Id == account.Team.Id)
            {
                wager.Team1.Players.Remove(account);
                account.Team = null;
            }
            else if (wager.Team2.Id == account.Team.Id)
            {
                wager.Team2.Players.Remove(account);
                account.Team = null;
            }
            anteContext.SaveChanges();
        }
        
        public List<Wager> GetWagerByGame(string gameName)
        {
            return anteContext.Wager.Where(wager => wager.Game == gameName)
                                    .Include(team1 => team1.Team1)
                                    .ThenInclude(x => x.Players)
                                    .Include(team2 => team2.Team2)
                                    .ThenInclude(x=>x.Players).ToList();
        }
    }
}