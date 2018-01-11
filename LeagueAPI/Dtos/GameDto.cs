using System;

using LeagueAPI.Dtos.Interfaces;

namespace LeagueAPI.Dtos
{
    public class GameDto : IGame
    {
        public Guid GameID { get; set; }
        public Guid Winner { get; set; }
        public Guid Losser { get; set; }       
    }
}
