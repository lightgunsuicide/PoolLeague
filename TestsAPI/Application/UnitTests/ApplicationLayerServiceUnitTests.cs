using FluentAssertions;
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
}