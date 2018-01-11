using LeagueAPI.Domain;
using LeagueAPI.Dtos.Interfaces;
using Moq;
using Xunit;
using FluentAssertions;

namespace Tests.UnitTests
{
    public class DomainUnitTests
    {
        [Fact]
        public void CreatePlayer()
        {
            //Arrange
            var playerUpdates = new PlayerUpdates();
            var mockPlayerDetails = new Mock<IPlayer>();
            //Here we need a faked repository 

            //Act
            var result = playerUpdates.AddPlayer(mockPlayerDetails.Object);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void PlayerLoss()
        {
        }

        [Fact]
        public void PlayerWin()
        {
        }
    }
}
