using System;
using System.Collections.Generic;
using FluentAssertions;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Application.Services;
using LeagueAPI.Repository;
using Moq;
using Xunit;

namespace TestsAPI.Application.IntegrationTests
{
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