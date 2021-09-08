using System;

namespace ante_up.Common.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int GamerCount { get; set; }
        public string CategoryTag { get; set; }
    }
}