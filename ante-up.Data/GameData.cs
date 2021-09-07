using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ante_up.Common;
using Microsoft.EntityFrameworkCore;

namespace ante_up.Data
{
    public class GameData
    {
        public List<Game> GetAllGames()
        {
            string querytext = "SELECT * FROM game";
            List<Game> games = new List<Game>();
            
            using (MySqlConnection conn = new(Global.connectionString))
            {
                using (MySqlCommand query = new(querytext, conn))
                {
                    conn.Open();

                    MySqlDataReader reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        Game game = new();
                        game.Id = reader.GetString(0);
                        game.Name = reader.GetString(1);
                        game.Image = reader.GetString(2);

                        games.Add(game);
                    }
                }
            }
            return games;
        }
        public string AddGame(Game game)
        {
             string querytext = "INSERT INTO game (Id, Name, Image) VALUES(@id, @name, @image);";

            string Id = Guid.NewGuid().ToString();
            using (MySqlConnection conn = new MySqlConnection(Global.connectionString))
            {
                conn.Open();
                using (MySqlCommand query = new MySqlCommand(querytext, conn))
                {
                    //conn.Open
                    query.Parameters.AddWithValue("@id", Id);
                    query.Parameters.AddWithValue("@name", game.Name);
                    query.Parameters.AddWithValue("@image", game.Image);

                    query.ExecuteNonQuery();
                }
            }
            return Id;
        }
    }
}