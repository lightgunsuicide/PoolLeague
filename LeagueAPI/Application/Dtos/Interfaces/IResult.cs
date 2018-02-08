using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueAPI.Application.Dtos.Interfaces
{
    public interface IResult
    {
        string Winner { get; set; }
        string Loser { get; set; }
    }
}
