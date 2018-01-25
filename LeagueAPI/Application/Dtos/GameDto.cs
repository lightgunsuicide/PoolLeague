using System;
using LeagueAPI.Application.Dtos.Interfaces;

namespace LeagueAPI.Application.Dtos
{
    public class GameDto : IGame
    {
        public Guid GameID { get; set; }
        public string Winner { get; set; }
        public string Loser { get; set; }       
    }
}
