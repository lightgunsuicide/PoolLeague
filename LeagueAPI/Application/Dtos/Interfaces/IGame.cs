using System;

namespace LeagueAPI.Application.Dtos.Interfaces
{
    public interface IGame
    {
         Guid GameID { get; set; }
         Guid Winner { get; set; }
         Guid Losser { get; set; }
    }
}
