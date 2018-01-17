using System;
using FluentAssertions;
using FluentAssertions.Primitives;
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
        public void PlayerLoss()
        {

        }

        [Fact]
        public void PlayerWin()
        {
        }
    }
}