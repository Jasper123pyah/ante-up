using ante_up.Common.DataModels;

namespace ante_up.Common.AdminModels
{
    public class AdminWager
    {
        public string Id { get; set; }
        public string Game { get; set; }
        public string Title { get; set; }
        public string Description { get; set;  }
        public string HostId { get; set; }
        public string HostName { get;set;  }
        public int Ante { get; set; }
        public int PlayerCap { get;set;  }
        public AdminTeam Team1 { get;set;  }
        public AdminTeam Team2 { get; set; }
        public Chat Chat { get; set; }

        public AdminWager(Wager wager)
        {
            Id = wager.Id.ToString();
            Game = wager.Game;
            Title = wager.Title;
            Description = wager.Description;
            HostId = wager.HostId;
            HostName = wager.HostName;
            Ante = wager.Ante;
            PlayerCap = wager.PlayerCap;
            Team1 = wager.Team1 != null ? new AdminTeam(wager.Team1) : null;
            Team2 = wager.Team2 != null ? new AdminTeam(wager.Team2) : null;
            Chat = wager.Chat;
        }
    }
}