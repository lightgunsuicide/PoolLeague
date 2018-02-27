using System;
using System.Collections.Generic;
using System.Text;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Dtos.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestsAPI.Helpers
{
    public class TestHelpers
    {
        [BsonId]
        public ObjectId MySuperId { get; set; }

        private List<Player> _players;
        public List<Player> PopulateListOfPlayers()
        {
            var player = new Player();
            _players = new List<Player>();
            var rand = new Random(100);
      


            for (int i = 0; i < 10; i++)
            {
                this.MySuperId = ObjectId.GenerateNewId();
                player.Id = MySuperId;
                player.Name = rand.Next(1, 100).ToString();
                player.Losses = rand.Next(1, 100);
                player.Wins = rand.Next(1, 100);

                _players.Add(player);
            }
            return _players;
        }

    }
}
