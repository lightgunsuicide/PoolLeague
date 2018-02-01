using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueAPI.Configuration;
using Microsoft.Extensions.Options;
using LeagueAPI.Application.Dtos.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LeagueAPI.Repository
{
    public class GameRepository
    {
        private readonly IMongoCollection<BsonDocument> _collection;
        private readonly IMongoDatabase _database;

        public GameRepository(IOptions<MongoSettings> settings)
        {
            var connectionUri = settings.Value.connectionUri;
            var connectionPort = settings.Value.connectionPort;
            var connectionString = "mongodb://" + connectionUri + ":" + connectionPort;
            IMongoClient client = new MongoClient(connectionString);
            _database = client.GetDatabase(settings.Value.mongoDataBase);
            _collection = _database.GetCollection<BsonDocument>("players");
        }


        public List<IPlayer> ReturnTopTen()
        {
            var playersList = _database.GetCollection<IPlayer>("players");
            var topTen = playersList.Find(x => true).SortByDescending(x => x.Wins).Limit(10);

            return (List<IPlayer>) topTen.ToList();
        }



        public List<IPlayer> FindAll()
        {
            var playersList = _database.GetCollection<IPlayer>("players");
            var all = playersList.Find(x => true);

            return (List<IPlayer>)all.ToList();
        }
    }
}
