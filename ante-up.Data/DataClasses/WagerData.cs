using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Common.Interfaces.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data.DataClasses
{
    public class WagerData : IWagerData
    {
        private readonly IAnteUpContext _anteContext;

        public WagerData(IAnteUpContext context)
        {
            _anteContext = context;
        }

        public string AddWager(Wager wager)
        {
            _anteContext.Wager.Add(wager);
            _anteContext.SaveChanges();
            return GetByHostId(wager.HostId).Id.ToString();
        }

        public void ChangeHost(Wager wager, string hostId)
        {
            wager.HostId = hostId;
            _anteContext.SaveChanges();
        }

        public void JoinTeam(Wager wager, Account account, int teamNumber)
        {
            switch (teamNumber)
            {
                case 1:
                    wager.Team1.Players.Add(account);
                    account.SetTeam(wager.Team1);
                    break;
                case 2:
                    wager.Team2.Players.Add(account);
                    account.SetTeam(wager.Team2);
                    break;
            }

            _anteContext.SaveChanges();
        }

        public void DeleteWager(Wager wager)
        {
            _anteContext.Team.RemoveRange(wager.Team1);
            _anteContext.Team.RemoveRange(wager.Team2);
            _anteContext.Chat.RemoveRange(wager.Chat);
            _anteContext.Wager.Remove(wager);

            _anteContext.SaveChanges();
        }

        public Wager? GetById(string id)
        {
            return _anteContext.Wager.Include(team1 => team1.Team1)
                .ThenInclude(x => x.Players)
                .Include(team2 => team2.Team2)
                .ThenInclude(x => x.Players)
                .Include(x => x.Chat)
                .ThenInclude(x => x.Messages)
                .FirstOrDefault(wager => wager.Id.ToString() == id);
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

        public Wager? GetAccountWager(Account account)
        {
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
                .ThenInclude(x => x.Players).ToList();
        }

        public Wager GetWagerByTeam(Team team)
        {
            return _anteContext.Wager.Include(team1 => team1.Team1)
                .ThenInclude(x => x.Players)
                .Include(team2 => team2.Team2)
                .ThenInclude(x => x.Players).FirstOrDefault(x => x.Team1.Id == team.Id || x.Team2.Id == team.Id)!;
        }
    }
}