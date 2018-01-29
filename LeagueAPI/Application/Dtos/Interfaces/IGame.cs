using System;
using MongoDB.Bson;

namespace LeagueAPI.Application.Dtos.Interfaces
{
    public interface IGame
    {
         BsonObjectId GameID { get; set; }
        BsonObjectId Winner { get; set; }
        BsonObjectId Loser { get; set; }
    }
}
