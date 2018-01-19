
using FluentAssertions;
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
            var gameService = new GameService(new Mock<IRepository<IPlayer>>().Object);
            var winner = "Lorem Ipsum";
            var loser = " Dolor Sit Amet";

            //Act
            var game = gameService.Add(winner, loser);

            //Assert
            game.Winner.Should().Be(winner);
            game.Loser.Should().Be(loser);
        }
    }