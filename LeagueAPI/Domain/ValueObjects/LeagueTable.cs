using System.Collections.Generic;
using LeagueAPI.Application.Dtos.Interfaces;

namespace LeagueAPI.Domain.ValueObjects
{
    public class LeagueTable
    {
        public List<IPlayer> TopTenPlayers { get; set; }
        public List<IPlayer> AllPlayers { get; set; }
    }
}
