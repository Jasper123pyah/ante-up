using System.Collections.Generic;
using ante_up.Common.DataModels;

namespace ante_up.Common.Interfaces.Data.Classes
{
    public interface IWagerData
    {
        string AddWager(Wager wager);

        void ChangeHost(Wager wager, string hostId);

        void JoinTeam(Wager wager, Account account, int teamNumber);
        void DeleteWager(Wager wager);
        Wager GetById(string id);
        Wager GetAccountWager(Account account);

        void RemoveFromTeam(Wager wager, Account account);

        List<Wager> GetWagerByGame(string gameName);
        Wager GetWagerByTeam(Team team);
    }
}