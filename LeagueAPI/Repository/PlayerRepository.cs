using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly IMongoCollection<BsonDocument> _collection;
        private readonly IMongoDatabase _database;

        public PlayerRepository(IOptions<MongoSettings> settings)
        {
            var connectionUri = settings.Value.connectionUri;
            var connectionPort = settings.Value.connectionPort;   
            var connectionString = "mongodb://"+ connectionUri + ":" + connectionPort; 
            IMongoClient client = new MongoClient(connectionString);
            _database = client.GetDatabase(settings.Value.mongoDataBase);
            _collection = _database.GetCollection<BsonDocument>("players");
        }

        public void Add(IPlayer newPlayer)
        {
            var playerDocument = new BsonDocument();
            playerDocument.Add("name", newPlayer.Name)
                .Add("wins", 0).Add("losses", 0); 
            _collection.InsertOne(playerDocument);  
        }
        
        public IPlayer FindById(BsonObjectId id)
        {
            var filter = new BsonDocument("_id", id);
            var player = _collection.Find(filter).Single();
            var deserialisedPlayer = BsonSerializer.Deserialize<PlayerDto>(player);
            return deserialisedPlayer;
        }

        public IPlayer FindByUsername(string username) {
            var filter = new BsonDocument("name", username);
            var player = _collection.Find(filter).Single();
            var deserialisedPlayer = BsonSerializer.Deserialize<PlayerDto>(player);
            return deserialisedPlayer;
        }

        public string Remove(string player)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", player);
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
            var deserialisedLoser = BsonSerializer.Deserialize<PlayerDto>(losingPlayer);

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", game.Loser);
            var currentLosses = deserialisedLoser.Losses + 1;
            var updateLosses = Builders<BsonDocument>.Update.Set("losses", currentLosses);

            _collection.UpdateOne(filter, updateLosses);
        }

        public void UpdateWinner(IGame game) {
            var winFilter = new BsonDocument("_id", game.Winner);
            var winningPlayer = _collection.Find(winFilter).Single();
            var deserialisedWinner = BsonSerializer.Deserialize<PlayerDto>(winningPlayer);

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", game.Winner);
            var currentWins = deserialisedWinner.Wins + 1;

            var updateWins = Builders<BsonDocument>.Update.Set("wins", currentWins);

            _collection.UpdateOne(filter, updateWins);
        }

        public List<PlayerDto> ReturnTopTen()
        {
            var playersList = _database.GetCollection<PlayerDto>("players");
            var topTen = playersList.Find(x => true).SortByDescending(x => x.Wins).Limit(10).ToList();

            return topTen;
        }

        public List<PlayerDto> FindAll()
        {
            IMongoCollection<PlayerDto> players = _database.GetCollection<PlayerDto>("players");
            List<PlayerDto> playerList = players.Find(x => true).SortByDescending(x => x.Wins).ToList();

            return playerList;
        }
    }
}
