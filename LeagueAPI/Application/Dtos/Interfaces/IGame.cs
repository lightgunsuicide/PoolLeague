using System;
using MongoDB.Bson;

namespace LeagueAPI.Application.Dtos.Interfaces
{
    public interface IGame
    {
         BsonObjectId GameID { get; set; }
         string Winner { get; set; }
         string Loser { get; set; }
    }
}
