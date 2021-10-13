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
        private readonly AnteUpContext anteContext;
        public GameData(AnteUpContext context)
        {
            anteContext = context;
        }
        public List<Game> GetAllGames()
        {
            AddInitialGames();
            return anteContext.Game.ToList();
        }
        public List<string> GetAllGameNames()
        {
            return anteContext.Game.ToList().Select(game => game.Name).ToList();
        }

        private void AddInitialGames()
        {
            if (GetGame("Fortnite") != null) return;
            
            anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Fortnite", Image = "fortnite.jpg"});
            anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Chess", Image = "chess.jpg"});
            anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "CoD Modern Warfare", Image = "codmw.jpg"});
            anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "CS:GO", Image = "csgo.jpg"});
            anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Fifa 22", Image = "fifa22.jpg"});
            anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Madden NFL 22", Image = "madden.jpg"});
            anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "NBA 2K22", Image = "nba2k.jpg"});
            anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Apex Legends", Image = "apex.jpg"});
            anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "League of Legends", Image = "leagueoflegends.jpg"});
            anteContext.SaveChanges();
        }
        public Game GetGame(string gameName)
        {
            return anteContext.Game.FirstOrDefault(e => e.Name == gameName);
        }
        public bool AddGame(Game game)
        {
            anteContext.Game.Add(game);
            anteContext.SaveChanges();

            return GetGame(game.Name) != null;
        }
    }
}