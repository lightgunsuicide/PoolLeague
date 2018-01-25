using System;

namespace LeagueAPI.Application.Dtos.Interfaces
{
    public interface IGame
    {
         Guid GameID { get; set; }
         string Winner { get; set; }
         string Loser { get; set; }
    }
}
