using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Game
    {
        [Key] public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string BannerImage { get; set; }
        public int WaitingTime { get; set; }
        public List<LobbySize> LobbySizes { get; set; } = new();

        public Game(){}
        public Game(string name, string image, int waitingTime, string bannerImage = "")
        {
            Id = Guid.NewGuid();
            Name = name;
            Image = image;
            BannerImage = bannerImage;
            WaitingTime = waitingTime;
        }
    }
}