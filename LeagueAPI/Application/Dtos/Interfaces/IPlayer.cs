using MongoDB.Bson;

namespace LeagueAPI.Application.Dtos.Interfaces
{
    public interface IPlayer
    {
        BsonObjectId Id { get; set; }
        string Name { get; set; }
        int Wins { get; set;  }
        int Losses { get; set; } 
    }
}
