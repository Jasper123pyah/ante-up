using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.ApiModels.Admin;
using ante_up.Common.ApiModels.Responses;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Logic.JWT;

namespace ante_up.Logic.Services
{
    public class GameLogic
    {
        private readonly IGameData _gameData;
        private readonly IWagerData _wagerData;

        public GameLogic(IGameData gameData, IWagerData wagerData)
        {
            _gameData = gameData;
            _wagerData = wagerData;
        }
        
        public void CreateGame(ApiAdminGame adminGame, string token)
        {
            if (JWTLogic.CheckAdminToken(token))
                _gameData.AddGame(new Game(adminGame.Name, adminGame.Image));
            throw new ApiException(403, "Not an admin");

        }
        public void DeleteGame(string gameName, string token)
        {
            Game game = _gameData.GetGameByName(gameName);
            if (game == null)
                throw new ApiException(404, "Game not found.");
            if (JWTLogic.CheckAdminToken(token))
                throw new ApiException(403, "Not an admin");
            
            _gameData.DeleteGame(game);
        }
        public List<ApiGame> GetAllGames()
        {
            List<Game> games = _gameData.GetAllGames();
            if (games.Count == 0)
                throw new ApiException(404, "Games not found");

            return games.Select(game => new ApiGame(game.Name, game.Image, _wagerData.GetWagerByGame(game.Name).Count)).OrderByDescending(x => x.Wagers).ToList();
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