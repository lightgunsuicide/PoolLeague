using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using FluentAssertions;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Controllers;
using LeagueAPI.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Semantics;
using TestsAPI.Helpers;
using Xunit;

namespace TestsAPI.Domain.UnitTests
{
    public class DomainLayerControllerUnitTests
    {
        private List<IPlayer> _players;

        [Fact]
        public void RetrieveTopTen()
        {
            //Arrange
            var TestHelpers = new TestHelpers();
            _players = TestHelpers.PopulateListOfPlayers();
            var displayResults = _players.OrderByDescending(x => x.Wins).Take(10).ToList();
            var mockLeagueServices = new Mock<ILeagueService>();
            mockLeagueServices.Setup(t => t.GetTopTenPlayers()).Returns(displayResults);

            var leagueController = new LeagueController(mockLeagueServices.Object);

            //Act
            var returnedTopTen = leagueController.GetTopTen();
            var okObjectResult = returnedTopTen as OkObjectResult;

            //Assert
            okObjectResult.Value.Should().Be(displayResults);
        }
    }
}
