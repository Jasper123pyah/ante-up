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
            
            _anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Fortnite", Image = "fortnite.jpg"});
            _anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Chess", Image = "chess.jpg"});
            _anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "CoD Modern Warfare", Image = "codmw.jpg"});
            _anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "CS:GO", Image = "csgo.jpg"});
            _anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Fifa 22", Image = "fifa22.jpg"});
            _anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Madden NFL 22", Image = "madden.jpg"});
            _anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "NBA 2K22", Image = "nba2k.jpg"});
            _anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Apex Legends", Image = "apex.jpg"});
            _anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "League of Legends", Image = "leagueoflegends.jpg"});
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