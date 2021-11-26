using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;

namespace ante_up.Common.AdminModels
{
    public class AdminTeam
    {
        public string Id { get; set; }
        public List<string> Playernames { get; set; }
        public AdminTeam(Team team)
        {
            Id = team.Id.ToString();
            Playernames = team.Players.Select(x => x.Username).ToList();
        }
    }
}