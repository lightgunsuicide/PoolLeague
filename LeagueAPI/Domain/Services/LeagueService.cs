﻿using System.Collections.Generic;
using LeagueAPI.Application.Dtos;
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

        public List<Player> GetTopTenPlayers()
        {
            return _repository.ReturnTopTen();
        }

        public List<Player> GetAllPlayers()
        {
            return _repository.FindAll();
        }
    }
}
