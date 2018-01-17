using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueAPI.Application.Dtos.Interfaces;

namespace LeagueAPI.Application.Services
{
    public interface IPlayerService
    {
        IPlayer Add(string newUser);
        bool Remove(string userToDelete);
        bool Update(string userToUpdate);
    }
}
