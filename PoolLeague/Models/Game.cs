using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolLeague.Models
{
    public class Game
    {
        public Guid GameID { get; set; }
        public Guid Winner { get; set; }
        public Guid Losser { get; set; }       
    }
}
