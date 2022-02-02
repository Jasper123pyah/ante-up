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
            {
                Game game = new Game(adminGame.Name, adminGame.Image, adminGame.WaitingTime, adminGame.BannerImage);
                foreach (string lobbySize in adminGame.LobbySizes)
                {
                    game.LobbySizes.Add(new LobbySize(lobbySize));
                }

                _gameData.AddGame(game);
            }
            else
             throw new ApiException(403, "Not an admin");
        }

        public void EditGame(ApiAdminGame adminGame, string token)
        {
            if (JWTLogic.CheckAdminToken(token))
            {
                Game game = _gameData.GetGameById(adminGame.Id);
                List<LobbySize> oldLobbySizes = game.LobbySizes;
                game.Name = adminGame.Name;
                game.WaitingTime = adminGame.WaitingTime;
                game.LobbySizes = new List<LobbySize>();
                foreach (string lobbySize in adminGame.LobbySizes)
                {
                    game.LobbySizes.Add(new LobbySize(lobbySize));
                }
                if (adminGame.Image != null)
                    game.Image = adminGame.Image;
                if (adminGame.BannerImage != null)
                    game.BannerImage = adminGame.BannerImage;
                _gameData.EditGame(game, oldLobbySizes);
            }
            else
                throw new ApiException(403, "Not an admin");
        }
        public void DeleteGame(string id, string token)
        {
            Game game = _gameData.GetGameById(id);
            if (game == null)
                throw new ApiException(404, "Game not found.");
            if (!JWTLogic.CheckAdminToken(token))
                throw new ApiException(403, "Not an admin");
            _gameData.DeleteGame(game);
        }
        public List<ApiGame> GetAllGames()
        {
            List<Game> games = _gameData.GetAllGames();
            if (games.Count == 0)
                throw new ApiException(404, "Games not found");
            return games.Select(game => new ApiGame(
                game.Id.ToString(),
                game.Name, 
                game.Image, 
                _wagerData.GetWagerByGame(game.Name).Count, 
                game.BannerImage, 
                game.LobbySizes.Select(lobbysize => lobbysize.Text).ToList(),
                game.WaitingTime)
            ).OrderByDescending(x => x.Wagers).ToList();
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