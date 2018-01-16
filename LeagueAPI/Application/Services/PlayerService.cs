using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Repository;

namespace LeagueAPI.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository<PlayerDto> _repository;

        public PlayerService(IRepository<PlayerDto> repository)
        {
            _repository = repository;
        }

        public Guid Add(string newUser)
        {
            var playersId = Guid.NewGuid();
            var playerToAdd = new PlayerDto(){PlayerId = playersId, Username  = newUser, Wins = 0, Losses = 0, GamesPlayed = 0};

            _repository.Add(playerToAdd);

            return playersId;
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
