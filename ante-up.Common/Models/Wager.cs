using System;

namespace ante_up.Common.Models
{
    public class Wager
    {
        public Guid Id { get; set; }
        public Game Game { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Ante { get; set; }
        public int PlayerCap { get; set; }
    }
}