using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Security.Certificates;

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
            anteContext.Wager.Add(newWager);
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

        public void JoinTeam(string wagerId, string playerId, int teamNumber)
        {
            Account account = anteContext.Account.Include(x => x.Team)
                                                .ThenInclude(x => x.Players)
                                                .FirstOrDefault(x => x.Id == playerId);
            Wager wager = GetById(wagerId);
            
            Console.WriteLine(account.Team);
            if (account.Team != null)
                RemoveFromTeam(wager, account);

            if (teamNumber == 1)
            {
                wager.Team1.Players.Add(account);
                account.Team = wager.Team1;
                anteContext.SaveChanges();
            }
            else if (teamNumber == 2)
            {
                wager.Team2.Players.Add(account);
                account.Team = wager.Team2;
                anteContext.SaveChanges();
            }
        }

        public void RemoveFromTeam(Wager wager, Account account)
        {
            if (wager.Team1.Id == account.Team.Id)
            {
                wager.Team1.Players.Remove(account);
                account.Team = new Team(){Id = ""};
            }
            else if (wager.Team2.Id == account.Team.Id)
            {
                wager.Team2.Players.Remove(account);
                account.Team = new Team();
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