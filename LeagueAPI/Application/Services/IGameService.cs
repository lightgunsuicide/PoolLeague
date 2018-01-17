using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueAPI.Application.Services
{
    public interface IGameService
    {
        Guid Add(List<string> players, string winner);
        bool Remove(string userToDelete);
        bool Update(string userToUpdate);
    }
}
