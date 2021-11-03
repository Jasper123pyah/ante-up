using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.DataModels;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class GameData
    {
        private readonly AnteUpContext _anteContext;
        public GameData(AnteUpContext context)
        {
            _anteContext = context;
        }
        public List<Game> GetAllGames()
        {
            AddInitialGames();
            return _anteContext.Game.ToList();
        }
        public List<string> GetAllGameNames()
        {
            return _anteContext.Game.ToList().Select(game => game.Name).ToList();
        }

        private void AddInitialGames()
        {
            if (GetGame("Fortnite") != null) return;
            
            _anteContext.Game.Add(new Game("Fortnite", "fortnite.jpg"));
            _anteContext.Game.Add(new Game("Chess", "chess.jpg"));
            _anteContext.Game.Add(new Game("CoD Modern Warfare", "codmw.jpg"));
            _anteContext.Game.Add(new Game("CS:GO", "csgo.jpg"));
            _anteContext.Game.Add(new Game("Fifa 22","fifa22.jpg"));
            _anteContext.Game.Add(new Game("Madden NFL 22", "madden.jpg"));
            _anteContext.Game.Add(new Game("NBA 2K22","nba2k.jpg"));
            _anteContext.Game.Add(new Game("Apex Legends", "apex.jpg"));
            _anteContext.Game.Add(new Game("League of Legends", "leagueoflegends.jpg"));
            _anteContext.SaveChanges();
        }
        private Game? GetGame(string gameName)
        {
            return _anteContext.Game.FirstOrDefault(e => e.Name == gameName);
        }
        public bool AddGame(Game game)
        {
            _anteContext.Game.Add(game);
            _anteContext.SaveChanges();

            return GetGame(game.Name) != null;
        }
    }
}