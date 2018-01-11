using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueAPI.Dtos.Interfaces;

namespace LeagueAPI.Dtos
{
    public class PlayerDto : IPlayer
    {
        public Guid PlayerId { get; set; }
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
