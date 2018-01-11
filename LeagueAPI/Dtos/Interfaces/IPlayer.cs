using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueAPI.Dtos.Interfaces
{
    public interface IPlayer
    {
        Guid PlayerId { get; set; }
        int Wins { get; set;  }
        int Losses { get; set; }
    }
}
