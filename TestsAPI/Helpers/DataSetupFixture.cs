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

            _dummyPlayers = new List<BsonDocument>(){  new BsonDocument {
                    { "PlayerId" , new Guid("0f8fad5b-d9cb-469f-a165-70867728950e")},
                    { "name", "Lorem Ipsum"},
                    { "wins", "100"},
                    { "losses", "12"}},

                new BsonDocument {
                    { "PlayerId" , new Guid("0f855555-d9cb-469f-a165-70867728950e")},
                    { "name", "Dolor Sit"},
                    { "wins", "99"},
                    { "losses", "1"},
                },
                new BsonDocument {
                    { "PlayerId" , new Guid("0f855555-3334-469f-a165-70865555550e")},
                    { "name", "consectetur adipiscing"},
                    { "wins", "68"},
                    { "losses", "1000"},
                },
                new BsonDocument {
                    { "PlayerId" , new Guid("0f855555-3334-469f-a165-71865555550e")},
                    { "name", "elit. Duis"},
                    { "wins", "56"},
                    { "losses", "10"},
                },

                new BsonDocument {
                    { "PlayerId" , new Guid("0f855555-3334-469f-a165-72865555550e")},
                    { "name", "sodales arcu"},
                    { "wins", "50"},
                    { "losses", "0"},
                },
                new BsonDocument {
                    { "PlayerId" , new Guid("0f855555-3334-469f-a165-73865555550e")},
                    { "name", "sed justo"},
                    { "wins", "48"},
                    { "losses", "20"},
                },
                new BsonDocument {
                    { "PlayerId" , new Guid("0f855555-3334-469f-a165-74865555550e")},
                    { "name", "porta, ut"},
                    { "wins", "45"},
                    { "losses", "90"},
                },
                new BsonDocument {
                    { "PlayerId" , new Guid("0f855555-3334-469f-a165-75865555550e")},
                    { "name", "bibendum augue"},
                    { "wins", "44"},
                    { "losses", "9"},
                },
                new BsonDocument {
                    { "PlayerId" , new Guid("0f855555-3334-469f-a165-74865555551e")},
                    { "name", "vestibulum. Nam"},
                    { "wins", "41"},
                    { "losses", "4"},
                },
                new BsonDocument {
                    { "PlayerId" , new Guid("0f855555-3334-469f-a165-74865555552e")},
                    { "name", "cursus convallis"},
                    { "wins", "40"},
                    { "losses", "40"},
                },
                new BsonDocument {
                    { "PlayerId" , new Guid("0f855555-3334-469f-a165-74865555553e")},
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
                _collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("PlayerId", player.GetValue("PlayerId")));
            }
        }
    }

}
