using System;
using LeagueAPI.Application.Dtos.Interfaces;
using MongoDB.Bson;

namespace LeagueAPI.Application.Dtos
{
    public class PlayerDto : IPlayer
    {
        public BsonObjectId Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
