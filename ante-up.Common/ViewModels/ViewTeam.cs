using System.Collections.Generic;

namespace ante_up.Common.ViewModels
{
    public class ViewTeam
    {
        public string Id { get; set; }
        public List<ViewAccount> Players { get; set; }
    }
}