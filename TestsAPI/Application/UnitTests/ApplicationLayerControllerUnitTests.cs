using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using FluentAssertions;
using LeagueAPI.Application.Controllers;
using LeagueAPI.Application.Services;
using Microsoft.Rest;
using Moq;
using Xunit;

namespace TestsAPI.Application.UnitTests
{
    public class ApplicationLayerControllerUnitTests
    {
        [Fact]
        public void AddPlayer() {
            //Arrange
            var playerController = new PlayerController(new Mock<IPlayerService>().Object);
            var username = "Lorem Ipsum";

            //Act
            var response = playerController.AddPlayer(username);
            var responseContent = response.Content;
            var responseContentResult = responseContent.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            responseContentResult.Should().Be("New user Lorem Ipsum created");
        }

        [Fact]
        public void AddGame()
        {
            //Arrange
            var gameController = new GamesController(new Mock<IGameService>().Object);
            var winner = "Lorem Ipsum";
            var loser = "Dolor Sit Amet";           

            //Act
            var response = gameController.AddGameDetails(winner, loser);
            var responseContent = response.Content;
            var responseContentResult = responseContent.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            responseContentResult.Should().Be("Game registered, winner Lorem Ipsum, loser Dolor Sit Amet");
        }
    }  
}
