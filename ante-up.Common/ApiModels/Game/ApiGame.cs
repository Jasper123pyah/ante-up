using System.Collections.Generic;

namespace ante_up.Common.ApiModels
{
    public class ApiGame
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string BannerImage { get; set; }
        public List<string> LobbySizes { get; set; }
        public int WaitingTime { get; set; }
        public int Wagers { get; set; }

        public ApiGame(string id, string name, string image, int wagers, string bannerImage, List<string> lobbySizes, int waitingTime)
        {
            Id = id;
            Name = name;
            Image = image;
            Wagers = wagers;
            BannerImage = bannerImage;
            LobbySizes = lobbySizes;
            WaitingTime = waitingTime;

        }
    }
}