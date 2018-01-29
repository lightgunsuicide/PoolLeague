using System;
using System.Collections.Generic;
using System.Text;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace TestsAPI.Helpers
{
    public class DataSetupFixture : IDisposable
    {
        private  IMongoCollection<BsonDocument> _collection;
        private  IMongoDatabase _database;
        private List<BsonDocument> _dummyPlayers;

        public IMongoClient Client { get; set; }


        public void SetDB(IOptions<MongoSettings> settings)
        {
            var connectionUri = settings.Value.connectionUri;
            var connectionPort = settings.Value.connectionPort;
            var connectionString = "mongodb://" + connectionUri + ":" + connectionPort;
            IMongoClient client = new MongoClient(connectionString);
            _database = client.GetDatabase(settings.Value.mongoDataBase);
            _collection = _database.GetCollection<BsonDocument>("players");

            this.Client = client;
            var idForFindId = new ObjectId("5a6f1b9b096a8a01c86f4c91");
            var idForFindIdBson = new BsonObjectId(idForFindId);

            _dummyPlayers = new List<BsonDocument>(){  new BsonDocument {
                    { "_id" , idForFindIdBson},
                    { "name", "Lorem Ipsum"},
                    { "wins", "100"},
                    { "losses", "12"}},

                new BsonDocument {
                    { "name", "Dolor Sit"},
                    { "wins", "99"},
                    { "losses", "1"},
                },
                new BsonDocument {
                    { "name", "consectetur adipiscing"},
                    { "wins", "68"},
                    { "losses", "1000"},
                },
                new BsonDocument {
                    { "name", "elit. Duis"},
                    { "wins", "56"},
                    { "losses", "10"},
                },

                new BsonDocument {
                    { "name", "sodales arcu"},
                    { "wins", "50"},
                    { "losses", "0"},
                },
                new BsonDocument {
                    { "name", "sed justo"},
                    { "wins", "48"},
                    { "losses", "20"},
                },
                new BsonDocument {
                    { "name", "porta, ut"},
                    { "wins", "45"},
                    { "losses", "90"},
                },
                new BsonDocument {
                    { "name", "bibendum augue"},
                    { "wins", "44"},
                    { "losses", "9"},
                },
                new BsonDocument {
                    { "name", "vestibulum. Nam"},
                    { "wins", "41"},
                    { "losses", "4"},
                },
                new BsonDocument {
                    { "name", "cursus convallis"},
                    { "wins", "40"},
                    { "losses", "40"},
                },
                new BsonDocument {
                    { "name", "lectus, id"},
                    { "wins", "32"},
                    { "losses", "1"},
                }
            };
        }

        public void CreateDummyData()
        {              
            _collection.InsertMany(_dummyPlayers);
        }

        public void Dispose()
        {
            
            foreach (var player in _dummyPlayers)
            {
                _collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", player.GetValue("_id")));
            }
        }
    }

}
