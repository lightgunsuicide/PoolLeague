using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Dtos.Interfaces;

namespace LeagueAPI.Domain.Services
{
    public interface ILeagueService
    {
        List<Player> GetTopTenPlayers();
        List<Player> GetAllPlayers();
    }
}
