using System;
using System.Linq;
using LeagueAPI.Application.Dtos;
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
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<BsonDocument> _collection;

        public PlayerRepository(IOptions<MongoSettings> settings)
        {
            var connectionUri = settings.Value.connectionUri;
            var connectionPort = settings.Value.connectionPort;
            
            var connectionString = connectionUri + ":" + connectionPort; 
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(settings.Value.mongoDataBase);
            _collection = _database.GetCollection<BsonDocument>("players");
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
            throw new NotImplementedException();
        }

        public IPlayer FindByUsername(string username) {

            var filter = new BsonDocument("username", username);
            var player = _collection.Find(filter).Single();

            var deserialisedPlayer = BsonSerializer.Deserialize<PlayerDto>(player);

            return deserialisedPlayer;
        }

        public void Remove(IPlayer id)
        {
            throw new NotImplementedException();
        }

        public void Update(IGame game)
        {
            UpdateLoser(game);
            UpdateWinner(game);
        }

        public void UpdateLoser(IGame game) {

            var loseFilter = new BsonDocument("Id", game.Loser);
            var losingPlayer = _collection.Find(loseFilter).Single();
            var deserialisedLoser = BsonSerializer.Deserialize<PlayerDto>(losingPlayer);

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", game.Loser);
            var updateLosses = Builders<BsonDocument>.Update.Set("Losses", deserialisedLoser.Losses++);

            _collection.UpdateOne(filter, updateLosses);
        }

        public void UpdateWinner(IGame game) {
            var winFilter = new BsonDocument("Id", game.Winner);
            var winningPlayer = _collection.Find(winFilter).Single();
            var deserialisedWinner = BsonSerializer.Deserialize<PlayerDto>(winningPlayer);

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", game.Loser);
            var updateWins = Builders<BsonDocument>.Update.Set("Wins", deserialisedWinner.Wins++);

            _collection.UpdateOne(filter, updateWins);

        }
    }
}
