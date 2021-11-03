using System;
using System.Collections.Generic;

namespace ante_up.Common.DataModels
{
    public class Wager
    {
        public Guid Id { get; set; }
        public string Game { get;  }
        public string Title { get;  }
        public string Description { get;  }
        public string HostId { get; set; }
        public string HostName { get;  }
        public int Ante { get;  }
        public int PlayerCap { get;  }
        public Team Team1 { get;  }
        public Team Team2 { get;  }
        public Chat Chat { get;  }

        public Wager(string game, string title, string description, string hostId, string hostName, int ante, int playerCap)
        {
            Game = game;
            Title = title;
            Description = description;
            HostId = hostId;
            HostName = hostName;
            Ante = ante;
            PlayerCap = playerCap;
            Team1 = new Team();
            Team2 = new Team();
            Chat = new Chat();
        }

        public string GetId()
        {
            return Id.ToString();
        }
    }
}