using System.Collections.Generic;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;

namespace ante_up.Logic
{
    public class GameLogic
    {
        private readonly IGameData _gameData;

        public GameLogic(IGameData gameData)
        {
            _gameData = gameData;
        }

        private void AddInitialGames()
        {
            if (_gameData.GetGameByName("Fortnite") != null) return;
            
            _gameData.AddGame(new Game("Fortnite", "fortnite.jpg"));
            _gameData.AddGame(new Game("Chess", "chess.jpg"));
            _gameData.AddGame(new Game("CoD Modern Warfare", "codmw.jpg"));
            _gameData.AddGame(new Game("CS:GO", "csgo.jpg"));
            _gameData.AddGame(new Game("Fifa 22","fifa22.jpg"));
            _gameData.AddGame(new Game("Madden NFL 22", "madden.jpg"));
            _gameData.AddGame(new Game("NBA 2K22","nba2k.jpg"));
            _gameData.AddGame(new Game("Apex Legends", "apex.jpg"));
            _gameData.AddGame(new Game("League of Legends", "leagueoflegends.jpg"));
        }
        public List<Game> GetAllGames()
        {
            AddInitialGames();
            return _gameData.GetAllGames();
        }
        public List<string> GetAllGameNames()
        {
            return _gameData.GetAllGameNames();
        }
    }
}