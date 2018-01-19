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
            var id = Guid.NewGuid();
            var winnerDetails = GetWinner(winner);
            var loserDetails = GetLoser(loser);
            var winnerId = winnerDetails.PlayerId;
            var loserId = loserDetails.PlayerId;

            var gameDetails = new GameDto() {GameID = id, Winner = winnerId, Loser = loserId };
            
            _repository.Update(gameDetails);

            return gameDetails;
        }

        private Guid GetLoserId(string loser)
        {
          return  _repository.FindByUsername(loser).PlayerId;
        }

        private Guid GetWinnerId(string winner)
        {
            return _repository.FindByUsername(winner).PlayerId;
        }

        private IPlayer GetWinner(string winner) {
            return _repository.FindByUsername(winner);
        }

        private IPlayer GetLoser(string loser)
        {
            return _repository.FindByUsername(loser);
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
