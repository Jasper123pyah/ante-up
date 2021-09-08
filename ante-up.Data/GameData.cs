using System;
using System.Collections.Generic;
using ante_up.Common.Models;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class GameData
    {
        public List<Game> GetAllGames(AnteUpContext context)
        {
            List<Game> gameList = new();
            foreach (Game game in context.Game)
            {
                gameList.Add(game);
            }
            return gameList;
        }
        public string AddGame(Game game)
        {
            return "Id";
        }
    }
}