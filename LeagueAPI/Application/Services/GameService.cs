using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Repository;
using System;

namespace LeagueAPI.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository<IPlayer> _repository;

        public GameService(IRepository<IPlayer> repository) {
            _repository = repository;
        }

        public IGame Add(string winner, string loser)
        {
            var winnerDetails = _repository.FindByUsername(winner); 
            var loserDetails = _repository.FindByUsername(loser);
            var winnerId = winnerDetails.Id;
            var loserId = loserDetails.Id;

            var gameDetails = new GameDto() { Winner = winnerId, Loser = loserId };
            
            _repository.Update(gameDetails);

            return gameDetails;
        } 
    }
}
