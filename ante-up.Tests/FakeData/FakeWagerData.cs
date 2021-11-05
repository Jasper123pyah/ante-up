using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;

namespace ante_up.Tests.FakeData
{
    public class FakeWagerData : IWagerData
    {
        public List<Wager> Wagers = new();
        public string AddWager(Wager wager)
        {
            Wagers.Add(wager);
            return GetById(wager.Id.ToString()).Id.ToString();
        }

        public void ChangeHost(Wager wager, string hostId)
        {
            GetById(wager.Id.ToString()).HostId = hostId;
        }

        public void JoinTeam(Wager wager, Account account, int teamNumber)
        {
            switch (teamNumber)
            {
                case 1:
                    GetById(wager.Id.ToString()).Team1.Players.Add(account);
                    break;
                case 2:
                    GetById(wager.Id.ToString()).Team2.Players.Add(account);
                    break;
            }
        }

        public void DeleteWager(Wager wager)
        {
            Wagers.Remove(wager);
        }

        public Wager GetById(string id)
        {
            return Wagers.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public Wager GetAccountWager(Account account)
        {
            if (account.Team == null)
                return null;
            if (Wagers.FirstOrDefault(e => e.Team1.Players.Contains(account)) != null)
                return Wagers.FirstOrDefault(e => e.Team1.Players.Contains(account));
            if (Wagers.FirstOrDefault(e => e.Team2.Players.Contains(account)) != null)
                return Wagers.FirstOrDefault(e => e.Team2.Players.Contains(account));
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
        }

        public IEnumerable<Wager> GetWagerByGame(string gameName)
        {
            return Wagers.Where(wager => wager.Game == gameName).ToList();
        }
    }
}