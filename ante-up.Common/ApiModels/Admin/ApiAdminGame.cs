using System.Collections.Generic;

namespace ante_up.Common.ApiModels.Admin
{
    public class ApiAdminGame
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string BannerImage { get; set; }
        public int WaitingTime { get; set; }
        public List<string> LobbySizes { get; set; }
    }
}