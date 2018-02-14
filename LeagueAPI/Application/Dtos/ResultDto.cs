using LeagueAPI.Application.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueAPI.Application.Dtos
{
    public class ResultDto : IResult
    {
        public string Winner { get; set;  }
        public string Loser { get; set ; }
    }
}
