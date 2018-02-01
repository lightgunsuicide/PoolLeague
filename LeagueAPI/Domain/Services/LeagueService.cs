using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Repository;
using MongoDB.Driver;

namespace LeagueAPI.Domain.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly IRepository<IPlayer> _repository;

        public LeagueService(IRepository<IPlayer> repository)
        {
            _repository = repository;
        }

        public List<PlayerDto> GetTopTenPlayers()
        {
            return _repository.ReturnTopTen();
        }

        public List<PlayerDto> GetAllPlayers()
        {
            return _repository.FindAll();
        }
    }
}
