using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueAPI.Dtos.Interfaces
{
    public interface IGame
    {
         Guid GameID { get; set; }
         Guid Winner { get; set; }
         Guid Losser { get; set; }
    }
}
