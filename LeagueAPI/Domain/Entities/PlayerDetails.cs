using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueAPI.Domain.Entities
{
    public class PlayerDetails
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public int Losses { get; set; }
        public int Wins { get; set; }
    }
}

