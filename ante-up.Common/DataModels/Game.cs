using System;

namespace ante_up.Common.DataModels
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; }
        public string Image { get; }

        public Game(string name, string image)
        {
            Name = name;
            Image = image;
        }
    }
}