using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.Models;
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
            return anteContext.Game.ToList();
        }

        public void AddInitialGames()
        {
            if (GetGame("Fortnite") != null) return;
            
            anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Fortnite", Image = "fortnite.webp"});
            anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Apex Legends", Image = "apex.jpg"});
            anteContext.Game.Add(new Game() {Id=Guid.NewGuid().ToString(), Name = "Minecraft", Image = "minecraft.png"});
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