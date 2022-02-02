using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;

namespace ante_up.Tests.FakeData
{
    public class FakeGameData : IGameData
    {
        private List<Game> Games = new(){new Game("Fortnite", "fortnite.jpg", 60)};
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

        public Game GetGameById(string Id)
        {
            throw new System.NotImplementedException();
        }

        public void EditGame(Game game, List<LobbySize> oldLobbySizes)
        {
            throw new System.NotImplementedException();
        }

        public void EditGame(Game game)
        {
            throw new System.NotImplementedException();
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