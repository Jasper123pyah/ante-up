﻿using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Common.Interfaces.Data.Context;

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

        public void DeleteGame(Game game)
        {
            Game deletedGame = GetAllGames().FirstOrDefault(x => x.Id == game.Id)!;
            _anteContext.Remove(deletedGame);
            _anteContext.SaveChanges();
        }
    }
}