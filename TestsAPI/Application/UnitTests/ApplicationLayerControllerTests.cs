using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using FluentAssertions;
using LeagueAPI.Application.Controllers;
using LeagueAPI.Application.Services;
using Moq;
using Xunit;

namespace TestsAPI.Application.UnitTests
{
    public class ApplicationLayerControllerTests
    {
        [Fact]
        public void AddPlayer() {
            //Arrange
            var playerController = new PlayerController(new Mock<IPlayerService>().Object);
            var username = "Lorem Ipsum";

            //Act
            var response = playerController.AddPlayer(username);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Content.Should().Be(string.Format("New user {0} /n created", username));
        }
    }  
}
