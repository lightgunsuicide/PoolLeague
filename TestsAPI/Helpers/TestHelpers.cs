using System;
using System.Collections.Generic;
using System.Text;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Dtos.Interfaces;

namespace TestsAPI.Helpers
{
    public class TestHelpers
    {
        private List<IPlayer> _players;
        public List<IPlayer> PopulateListOfPlayers()
        {
            var player = new PlayerDto();
            _players = new List<IPlayer>();
            var rand = new Random(100);
            var uniqueId = new Guid();
            var uniqueString = uniqueId.ToString();
            

            for (int i = 0; i < 10; i++)
            {
                player.PlayerId = uniqueString;
                player.GamesPlayed = rand.Next(1, 10);
                player.Username = rand.Next(1, 100).ToString();
                player.Losses = rand.Next(1, 100);
                player.Wins = rand.Next(1, 100);

                _players.Add(player);
            }
            return _players;
        }

    }
}
