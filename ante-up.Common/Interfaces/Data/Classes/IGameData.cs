using System.Collections.Generic;
using ante_up.Common.DataModels;

namespace ante_up.Common.Interfaces.Data.Classes
{
    public interface IGameData
    {
        List<Game> GetAllGames();
        List<string> GetAllGameNames();
        Game GetGameByName(string gameName);
        Game GetGameById(string id);
        void EditGame(Game game, List<LobbySize> oldLobbySizes);
        void AddGame(Game game);
        void DeleteGame(Game game);
    }
}