using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using FluentAssertions;
using LeagueAPI.Application.Controllers;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;
using MongoDB.Bson;
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
        public void FindPlayerById()
        {
            //Arrange
            var plainObjectId = new ObjectId();
            var bsonObjectId = new BsonObjectId(plainObjectId);
            var convertedId = bsonObjectId.ToString();
            var player = new PlayerDto(){ Id = bsonObjectId, Name = "Lorem Ipsum", Losses = 4, Wins = 8};

            var mockService = new Mock<IPlayerService>();
            mockService.Setup(x => x.SearchById(bsonObjectId)).Returns(player);

            var playerController = new PlayerController(mockService.Object);
             
            //Act
            var returnedPlayer = playerController.FindPlayerById(convertedId);
            var okObjectResult = returnedPlayer as OkObjectResult;

            //Assert
            okObjectResult.Value.Should().Be(player);
        }

        [Fact]
        public void FindPlayerByUsername()
        {
            //Arrange
            var plainObjectId = new ObjectId();
            var bsonObjectId = new BsonObjectId(plainObjectId);

            var player = new PlayerDto() { Id = bsonObjectId, Name = "Lorem Ipsum", Losses = 4, Wins = 8 };
            var nameSearched = "Lorem Ipsum";

            var mockService = new Mock<IPlayerService>();
            mockService.Setup(x => x.SearchByUsername(nameSearched)).Returns(player);

            var playerController = new PlayerController(mockService.Object);

            //Act
            var returnedPlayer = playerController.FindPlayerByUsername(nameSearched);
            var okObjectResult = returnedPlayer as OkObjectResult;

            //Assert
            okObjectResult.Value.Should().Be(player);
        }

        [Fact]
        public void RemovePlayerSuccessfully()
        {
            //Arrange
            var player = "Lorem Ipsum";

            var mockService = new Mock<IPlayerService>();
            mockService.Setup(x => x.Remove(player)).Returns("Success: Player " + player + " has been removed");

            var playerController = new PlayerController(mockService.Object);

            //Act
            var result = playerController.DeletePlayer(player);
            var okObjectResult = result as OkObjectResult;
            var content = okObjectResult.Value as ContentResult;

            //Assert
            content.Content.Should().Be("Success: Player " + player + " has been removed");
        }

        [Fact]
        public void RemovePlayerUnsuccessfully()
        {
            //Arrange
            var player = "Falsum Hominem";

            var mockService = new Mock<IPlayerService>();
            mockService.Setup(x => x.Remove(player)).Returns("Fail: Player " + player + " could be be removed.");

            var playerController = new PlayerController(mockService.Object);

            //Act
            var result = playerController.DeletePlayer(player);
            var notFoundObjectResult = result as NotFoundObjectResult;

            //Assert
            notFoundObjectResult.Value.Should().Be("Fail: Player " + player + " could be be removed.");
        }
    
        [Fact]
        public void AddGame()
        {
            //Arrange
            var gameController = new GamesController(new Mock<IGameService>().Object);
            var winner = "Lorem Ipsum";
            var loser = "Dolor Sit Amet";
            var result = new ResultDto() { Winner = winner, Loser = loser };

            //Act
            var response = gameController.AddGameDetails(result);
            var responseContent = response.Content;
            var responseContentResult = responseContent.ReadAsStringAsync().Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            responseContentResult.Should().Be("Game registered, winner Lorem Ipsum, loser Dolor Sit Amet");
        }
    }  
}
