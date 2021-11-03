using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class WagerData
    {
        private readonly AnteUpContext _anteContext;
        private readonly AccountData _accountData;
        public WagerData(AnteUpContext context)
        {
            _anteContext = context;
            _accountData = new AccountData(context);
        }
        
        public string AddNewWager(Wager newWager)
        {
            _anteContext.Wager.Add(newWager);
            _anteContext.SaveChanges();

            return GetByHostId(newWager.HostId).GetId();
        }
        
        public void LeaveWager(Wager wager, string accountId)
        {
            Account account = _accountData.GetAccountById(accountId)!;
            
            RemoveFromTeam(wager, account);
            if (wager.HostId == account.GetId())
            {
                if(wager.Team1.Players.FirstOrDefault()?.Id != null)
                    wager.HostId = wager.Team1.Players.FirstOrDefault()?.GetId();
                else if (wager.Team2.Players.FirstOrDefault()?.Id != null)
                    wager.HostId = wager.Team2.Players.FirstOrDefault()?.GetId();
                else DeleteWager(wager);
            }
            _anteContext.SaveChanges();
        }
        public void JoinTeam(string wagerId, string accountId, int teamNumber)
        {
            Account account = _accountData.GetAccountById(accountId);
            Wager wager = GetById(wagerId);
            Wager currentWager = GetAccountWager(accountId);
            
            if (currentWager != null && currentWager != wager)
                LeaveWager(currentWager, accountId);

            if (teamNumber == 1)
            {
                wager.Team1.Players.Add(account);
                account.SetTeam(wager.Team1);
                _anteContext.SaveChanges();
            } 
            if (teamNumber == 2)
            {
                wager.Team2.Players.Add(account);
                account.SetTeam(wager.Team2);
                _anteContext.SaveChanges();
            }
        }
        private void DeleteWager(Wager wager)
        {
            _anteContext.Team.RemoveRange(wager.Team1);
            _anteContext.Team.RemoveRange(wager.Team2);
            _anteContext.Chat.RemoveRange(wager.Chat);
            _anteContext.Wager.Remove(wager);
            
            _anteContext.SaveChanges();
        }
        public Wager GetById(string id)
        {
            return _anteContext.Wager.Include(team1 => team1.Team1)
                .ThenInclude(x => x.Players)
                .Include(team2 => team2.Team2)
                .ThenInclude(x => x.Players)
                .Include(x => x.Chat)
                .ThenInclude(x => x.Messages)
                .FirstOrDefault(wager => wager.GetId() == id)!;
        }
        private Wager GetByHostId(string hostId)
        {
            return _anteContext.Wager.Include(team1 => team1.Team1)
                .ThenInclude(x => x.Players)
                .Include(team2 => team2.Team2)
                .ThenInclude(x => x.Players)
                .Include(x => x.Chat)
                .ThenInclude(x => x.Messages)
                .FirstOrDefault(wager => wager.HostId == hostId)!;
        }

        public Wager? GetAccountWager(string accountId)
        {
            Account account = _accountData.GetAccountById(accountId)!;
            if (account.Team == null)
                return null;
            if (_anteContext.Wager.FirstOrDefault(e => e.Team1.Players.Contains(account)) != null)
                return _anteContext.Wager.FirstOrDefault(e => e.Team1.Players.Contains(account));
            if (_anteContext.Wager.FirstOrDefault(e => e.Team2.Players.Contains(account)) != null)
                return _anteContext.Wager.FirstOrDefault(e => e.Team2.Players.Contains(account));
            return null;
            
        }

        public void RemoveFromTeam(Wager wager, Account account)
        {
            if (wager.Team1.Id == account.Team.Id)
            {
                wager.Team1.Players.Remove(account);
                account.RemoveTeam();
            }
            else if (wager.Team2.Id == account.Team.Id)
            {
                wager.Team2.Players.Remove(account);
                account.RemoveTeam();
            }
            _anteContext.SaveChanges();
        }
        
        public List<Wager> GetWagerByGame(string gameName)
        {
            return _anteContext.Wager.Where(wager => wager.Game == gameName)
                                    .Include(team1 => team1.Team1)
                                    .ThenInclude(x => x.Players)
                                    .Include(team2 => team2.Team2)
                                    .ThenInclude(x=>x.Players).ToList();
        }
    }
}