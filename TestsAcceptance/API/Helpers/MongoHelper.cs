using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsAcceptance.API.Models;

namespace TestsAcceptance.API.Helpers
{
    public class MongoHelper
    {
        MongoClient _client;
        IMongoDatabase _database;
        IMongoCollection<BsonDocument> _playerCollection;

        public MongoHelper()
        {
            MongoUrl uri = new MongoUrl("mongodb://localhost:27017");
            _client = new MongoClient(uri);
            _database = _client.GetDatabase("poolleague");
            _playerCollection = _database.GetCollection<BsonDocument>("players");
        }
        public int GetPlayerNumberOfWins(string playerId) {
            var convertedId = new BsonObjectId(new ObjectId(playerId));
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", convertedId);
            var returnedPlayer = _playerCollection.Find(filter).Single();
            var deserialisedPlayer = BsonSerializer.Deserialize<PlayerContract>(returnedPlayer);
            return deserialisedPlayer.Wins; 
        }
        public int GetPlayerNumberOfLosses(string playerId)
        {
            var convertedId = new BsonObjectId(new ObjectId(playerId));
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", convertedId);
            var returnedPlayer = _playerCollection.Find(filter).Single();
            var deserialisedPlayer = BsonSerializer.Deserialize<PlayerContract>(returnedPlayer);
            return deserialisedPlayer.Losses;
        }
    }
}
