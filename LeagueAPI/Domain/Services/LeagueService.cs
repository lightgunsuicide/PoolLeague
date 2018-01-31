using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Repository;

namespace LeagueAPI.Domain.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly IRepository<IPlayer> _repository;

        public LeagueService(IRepository<IPlayer> repository)
        {
            _repository = repository;
        }

        public List<IPlayer> GetTopTenPlayers()
        {
            var topTen = _repository.ReturnTopTen();

            return (List<IPlayer>) topTen;
        }

        public List<IPlayer> GetAllPlayers()
        {
            var topTen = _repository.ReturnTopTen();
            return (List<IPlayer>)topTen;
            ;
        }
    }
}
