using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueAPI.Application.Services
{
    public interface IPlayerService
    {
        Guid Add(string newUser);
        bool Remove(string userToDelete);
        bool Update(string userToUpdate);
    }
}
