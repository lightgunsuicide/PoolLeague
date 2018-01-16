using System;
using LeagueAPI.Application.Dtos.Interfaces;

namespace LeagueAPI.Application.Dtos
{
    public class PlayerDto : IPlayer
    {
        public Guid PlayerId { get; set; }
        public string Username { get; set; }
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
