using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;

namespace ante_up.Common.ViewModels
{
    public class ViewAccount
    {
        public string Username { get; set; }
        public string TeamId { get; set; }
        public ApiGameStats GameStats { get; set; }
    }
}