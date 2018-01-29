using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LeagueAPI.Application.Dtos.Interfaces
{
    public interface IPlayer
    {
        [BsonElement("_id")]
        BsonObjectId Id { get; set; }
        [BsonElement("name")]
        string Name { get; set; }
        [BsonElement("wins")]
        int Wins { get; set;  }
        [BsonElement("losses")]
        int Losses { get; set; } 
    }
}
