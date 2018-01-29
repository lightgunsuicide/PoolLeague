using System;
using LeagueAPI.Application.Dtos.Interfaces;
using MongoDB.Bson;

namespace LeagueAPI.Application.Dtos
{
    public class GameDto : IGame
    {
        public BsonObjectId GameID { get; set; }
        public BsonObjectId Winner { get; set; }
        public BsonObjectId Loser { get; set; }       
    }
}
