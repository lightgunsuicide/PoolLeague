using LeagueAPI.Application.Dtos.Interfaces;

namespace LeagueAPI.Application.Services
{
    public interface IGameService
    {
        IGame Add(string winner, string loser);
        bool Remove(string userToDelete);
        bool Update(string userToUpdate);
    }
}
