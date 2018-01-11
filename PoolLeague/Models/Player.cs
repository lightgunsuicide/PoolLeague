using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolLeague.Models
{
    public class Player
    {
        public Guid playerId { get; set; }
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
