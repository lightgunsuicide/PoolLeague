using System;
using FluentAssertions;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Application.Services;
using LeagueAPI.Repository;
using Moq;
using Xunit;

namespace TestsAPI.Application.UnitTests
{
    public class ApplicationLayerServiceUnitTests
    {
        [Fact]
        public void CreatePlayer()
        {
            //Arrange
            var playerService = new PlayerService(new Mock<IRepository<IPlayer>>().Object);
            string mockPlayer = "lorem ipsum";

            //Act
            var result = playerService.Add(mockPlayer);

            //Assert
            result.Username.Should().Be(mockPlayer);
            result.Losses.Should().Be(0);
            result.Wins.Should().Be(0);
            result.PlayerId.Should().NotBeEmpty();       
        }
        public class ApplicationLayerServiceIntegrationTests
        {
            [Fact]
            public void GameOutcome()
            {
                //Arrange
                var playerOne = new PlayerDto()
                {
                    PlayerId = new Guid(),
                    Username = "Falsum Hominem",
                    Losses = 1,
                    Wins = 2,
                    GamesPlayed = 2
                };

                var mockRepo = new Mock<IRepository<IPlayer>>();

                mockRepo.Setup(x => x.FindByUsername("Falsum Hominem")).Returns(playerOne);

                var gameService = new GameService(mockRepo.Object);
                var winner = "Falsum Hominem";
                var loser = "Falsum Hominem";

                //Act
                var game = gameService.Add(winner, loser);

                //Assert
                game.Winner.Should().Be(playerOne.PlayerId);
                game.Loser.Should().Be(playerOne.PlayerId);
            }
        }
    }
}