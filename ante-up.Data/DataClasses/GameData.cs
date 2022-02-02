using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Common.Interfaces.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data.DataClasses
{
    public class GameData : IGameData
    {
        private readonly IAnteUpContext _anteContext;
        public GameData(IAnteUpContext context)
        {
            _anteContext = context;
        }
        public List<Game> GetAllGames()
        {
            return _anteContext.Game.Include(x => x.LobbySizes).ToList();
        }
        public List<string> GetAllGameNames()
        {
            return GetAllGames().Select(game => game.Name).ToList();
        }
        
        public Game? GetGameByName(string gameName)
        {
            return _anteContext.Game.Include(x => x.LobbySizes).FirstOrDefault(e => e.Name == gameName);
        }

        public Game? GetGameById(string id)
        {
            return _anteContext.Game.Include(x => x.LobbySizes).FirstOrDefault(x => x.Id.ToString() == id);
        }

        public void AddGame(Game game)
        {
            _anteContext.Game.Add(game);
            _anteContext.SaveChanges();
        }

        public void EditGame(Game game, List<LobbySize> oldLobbySizes)
        {
            _anteContext.LobbySize.RemoveRange(oldLobbySizes);
            _anteContext.Game.Update(game);
            _anteContext.SaveChanges();
        }
        public void DeleteGame(Game game)
        {
            _anteContext.LobbySize.RemoveRange(game.LobbySizes);
            IWagerData wagerData = new WagerData(_anteContext);
            foreach (var wager in _anteContext.Wager.Where(x => x.Game == game.Name))
            {
                wagerData.DeleteWager(wager);
            }
            _anteContext.Game.Remove(game);
            _anteContext.SaveChanges();
        }
    }
}