using System;
using LeagueAPI.Application.Dtos.Interfaces;

namespace LeagueAPI.Application.Dtos
{
    public class GameDto : IGame
    {
        public Guid GameID { get; set; }
        public Guid Winner { get; set; }
        public Guid Loser { get; set; }       
    }
}
