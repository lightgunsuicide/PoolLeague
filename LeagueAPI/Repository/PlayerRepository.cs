using System;
using System.Linq;
using LeagueAPI.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using LeagueAPI.Application.Dtos.Interfaces;

namespace LeagueAPI.Repository
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly IMongoCollection<BsonDocument> _collection;

        public PlayerRepository(IOptions<MongoSettings> settings)
        {
            var connectionUri = settings.Value.connectionUri;
            var connectionPort = settings.Value.connectionPort;   
            var connectionString = connectionUri + ":" + connectionPort; 
            IMongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase(settings.Value.mongoDataBase);
            _collection = database.GetCollection<BsonDocument>("players");
        }

        public void Add(IPlayer newPlayer)
        {
            var playerDocument = new BsonDocument();
            playerDocument.Add("Id", newPlayer.PlayerId)
                .Add("name", newPlayer.Username)
                .Add("wins", 0).Add("losses", 0); 
            _collection.InsertOne(playerDocument);  
        }
        
        public IPlayer FindById(Guid id)
        {
            var filter = new BsonDocument("_id", id);
            var player = _collection.Find(filter).Single();
            var deserialisedPlayer = BsonSerializer.Deserialize<IPlayer>(player);
            return deserialisedPlayer;
        }

        public IPlayer FindByUsername(string username) {
            var filter = new BsonDocument("username", username);
            var player = _collection.Find(filter).Single();
            var deserialisedPlayer = BsonSerializer.Deserialize<IPlayer>(player);
            return deserialisedPlayer;
        }

        public string Remove(string player)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("username", player);
            try
            {
                _collection.DeleteOne(filter);   
            }
            catch (Exception e)
            {
                return "Fail: Player " + player + " could be be removed. Error: /n" + e;
            }
            return "Success: Player " + player + " has been removed";
        }

        public void Update(IGame game)
        {
            UpdateLoser(game);
            UpdateWinner(game);
        }

        public void UpdateLoser(IGame game) {
            var loseFilter = new BsonDocument("_id", game.Loser);
            var losingPlayer = _collection.Find(loseFilter).Single();
            var deserialisedLoser = BsonSerializer.Deserialize<IPlayer>(losingPlayer);

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", game.Loser);
            var updateLosses = Builders<BsonDocument>.Update.Set("Losses", deserialisedLoser.Losses++);

            _collection.UpdateOne(filter, updateLosses);
        }

        public void UpdateWinner(IGame game) {
            var winFilter = new BsonDocument("_id", game.Winner);
            var winningPlayer = _collection.Find(winFilter).Single();
            var deserialisedWinner = BsonSerializer.Deserialize<IPlayer>(winningPlayer);

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", game.Loser);
            var updateWins = Builders<BsonDocument>.Update.Set("Wins", deserialisedWinner.Wins++);

            _collection.UpdateOne(filter, updateWins);
        }
    }
}
