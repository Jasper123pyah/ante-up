using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data;
using ante_up.Common.Interfaces.Data.Classes;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
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
            return _anteContext.Game.ToList();
        }
        public List<string> GetAllGameNames()
        {
            return GetAllGames().Select(game => game.Name).ToList();
        }
        
        public Game? GetGameByName(string gameName)
        {
            return _anteContext.Game.FirstOrDefault(e => e.Name == gameName);
        }
        public void AddGame(Game game)
        {
            _anteContext.Game.Add(game);
            _anteContext.SaveChanges();
        }
    }
}