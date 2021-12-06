namespace ante_up.Common.ApiModels
{
    public class ApiGame
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Wagers { get; set; }

        public ApiGame(string name, string image, int wagers)
        {
            Name = name;
            Image = image;
            Wagers = wagers;
        }
    }
}