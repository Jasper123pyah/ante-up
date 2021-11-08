using System;
using System.Collections.Generic;
using ante_up.Common.ApiModels;
using ante_up.Common.ApiModels.Admin;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Logic.JWT;

namespace ante_up.Logic
{
    public class GameLogic
    {
        private readonly IGameData _gameData;

        public GameLogic(IGameData gameData)
        {
            _gameData = gameData;
        }



        public void CreateGame(ApiAdminGame adminGame, string token)
        {
            if (JWTLogic.CheckAdminToken(token))
                _gameData.AddGame(new Game(adminGame.Name, adminGame.Image));
            throw new ApiException(401, "Token is invalid.");

        }
        public void DeleteGame(string gameName, string token)
        {
            Game game = _gameData.GetGameByName(gameName);
            if (game == null)
                throw new ApiException(404, "Game not found.");
            if (JWTLogic.CheckAdminToken(token))
                throw new ApiException(401, "Token is invalid.");
            
            _gameData.DeleteGame(game);
        }
        public List<Game> GetAllGames()
        {
            List<Game> games = _gameData.GetAllGames();
            if (games.Count == 0)
                throw new ApiException(404, "Games not found");
            return games;
        }
        public List<string> GetAllGameNames()
        {
            List<string> gameNames = _gameData.GetAllGameNames();
            if (gameNames.Count == 0)
                throw new ApiException(404, "Games not found");
            return gameNames;
        }
    }
}