using System;
using LeagueAPI.Application.Dtos.Interfaces;

namespace LeagueAPI.Application.Services
{
    public interface IPlayerService
    {
        IPlayer Add(string newUser);
        string Remove(string userToDelete);
        IPlayer SearchById(Guid id);
        IPlayer SearchByUsername(string username);
    }
}
