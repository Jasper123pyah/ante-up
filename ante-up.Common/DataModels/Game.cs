using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Game
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string Image { get; set;}

        public Game(){}
        public Game(string name, string image)
        {
            Id = Guid.NewGuid();
            Name = name;
            Image = image;
        }
    }
}