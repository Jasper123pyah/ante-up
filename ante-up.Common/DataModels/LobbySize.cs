using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class LobbySize
    {
        [Key]
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int TotalPlayers { get; set; }
        
        public LobbySize(){}

        public LobbySize(string lobbySize)
        {
            Text = lobbySize;
            TotalPlayers = GetTotalPlayers(lobbySize);
        }
        private int GetTotalPlayers(string lobbySize)
        {
            return lobbySize switch
            {
                "1v1" => 2,
                "2v2" => 4,
                "3v3" => 6,
                "4v4" => 8,
                "5v5" => 10,
                "6v6" => 12,
                _ => 0
            };
        }
    }
}