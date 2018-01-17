using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Configuration;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LeagueAPI.Repository
{
    public class PlayerRepository : IRepository<PlayerDto>
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

        public void Add(PlayerDto newPlayer)
        {
            var playerDocument = new BsonDocument();
            playerDocument.Add("Id", newPlayer.PlayerId)
                .Add("name", newPlayer.Username)
                .Add("wins", 0).Add("losses", 0); 

            _collection.InsertOne(playerDocument);  
        }

        public PlayerDto FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(PlayerDto id)
        {
            throw new NotImplementedException();
        }

        public void Update(PlayerDto name)
        {
            throw new NotImplementedException();
        }
    }
}
