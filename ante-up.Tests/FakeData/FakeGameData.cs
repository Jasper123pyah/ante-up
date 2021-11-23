using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;

namespace ante_up.Tests.FakeData
{
    public class FakeGameData : IGameData
    {
        private List<Game> Games = new(){new Game("Fortnite", "fortnite.jpg")};
        public List<Game> GetAllGames()
        {
            return Games;
        }

        public List<string> GetAllGameNames()
        {
            return Games.Select(game => game.Name).ToList();
        }

        public Game? GetGameByName(string gameName)
        {
            return Games.FirstOrDefault(x => x.Name == gameName);
        }

        public void AddGame(Game game)
        {
            Games.Add(game);
        }

        public void DeleteGame(Game game)
        {
            Games.Remove(game);
        }
    }
}