using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Wager
    {
        [Key]
        public Guid Id { get; set; }
        public string Game { get; set; }
        public string Title { get; set; }
        public string Description { get; set;  }
        public string HostId { get; set; }
        public string HostName { get;set;  }
        public int Ante { get; set; }
        public int PlayerCap { get;set;  }
        public Team Team1 { get;set;  }
        public Team Team2 { get; set; }
        public Chat Chat { get; set; }

        public Wager(){}
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

    }
}