using ante_up.Common.Models;

namespace ante_up.Common.ViewModels
{
    public class ViewWager
    {
        public string Id { get; set; }
        public string Game { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string HostId { get; set; }
        public string HostName { get; set; }
        public int Ante { get; set; }
        public int PlayerCap { get; set; }
        public ViewTeam Team1 { get; set; }
        public ViewTeam Team2 { get; set; }
        public Chat Chat { get; set; }
    }
}