using System;
using LeagueAPI.Application.Dtos.Interfaces;
using MongoDB.Bson;

namespace LeagueAPI.Application.Dtos
{
    public class GameDto : IGame
    {
        public BsonObjectId GameID { get; set; }
        public string Winner { get; set; }
        public string Loser { get; set; }       
    }
}
