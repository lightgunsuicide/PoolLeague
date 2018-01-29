using System;
using LeagueAPI.Application.Dtos.Interfaces;
using MongoDB.Bson;

namespace LeagueAPI.Application.Services
{
    public interface IPlayerService
    {
        IPlayer Add(string newUser);
        string Remove(string userToDelete);
        IPlayer SearchById(BsonObjectId id);
        IPlayer SearchByUsername(string username);
    }
}
