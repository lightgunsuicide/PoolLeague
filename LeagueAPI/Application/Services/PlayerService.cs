using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Repository;

namespace LeagueAPI.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository<IPlayer> _repository;

        public PlayerService(IRepository<IPlayer> repository)
        {
            _repository = repository;
        }

        public IPlayer Add(string newUser)
        {
            var playersId = Guid.NewGuid();
            var playerToAdd = new PlayerDto(){PlayerId = playersId, Username  = newUser, Wins = 0, Losses = 0, GamesPlayed = 0};

            _repository.Add(playerToAdd);

            return playerToAdd;
        }

        public bool Remove(string userToDelete)
        {
            throw new NotImplementedException();
        }

        public bool Update(string userToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
