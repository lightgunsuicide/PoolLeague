using System;
using LeagueAPI.Application.Dtos.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LeagueAPI.Application.Dtos
{
    public class Player : IPlayer
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("wins")]
        public int Wins { get; set; }
        [BsonElement("losses")]
        public int Losses { get; set; }
    }
}
