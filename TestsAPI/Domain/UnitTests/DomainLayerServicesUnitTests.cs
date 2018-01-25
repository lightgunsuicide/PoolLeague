using System.Collections.Generic;
using System.Linq;
using Moq;
using FluentAssertions;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Domain.Services;
using LeagueAPI.Repository;
using TestsAPI.Helpers;
using Xunit;

namespace TestsAPI.Domain.UnitTests
{

    public class DomainLayerServicesUnitTests
    {
        private  List<IPlayer> _players;
      
        [Fact]
        public void RetreiveTopTen()
        {
            //Arrange
            var TestHelpers = new TestHelpers();
            _players = TestHelpers.PopulateListOfPlayers();
            
            var mockRepo = new Mock<IRepository<IPlayer>>();
            var displayResults = _players.OrderByDescending(x => x.Wins).Take(10).ToList();
            mockRepo.Setup(x => x.ReturnTopTen()).Returns(displayResults);
            var domainServices = new LeagueService(mockRepo.Object);

            //Act
            var topTen = domainServices.GetTopTenPlayers();

            //Assert
            topTen.ShouldAllBeEquivalentTo(displayResults);
            topTen.Should().BeInDescendingOrder();
        }

        [Fact]
        public void FindAllPlayers()
        {
            //Arrange
            var TestHelpers = new TestHelpers();

            _players = TestHelpers.PopulateListOfPlayers();

            var mockRepo = new Mock<IRepository<IPlayer>>();
            var displayResults = _players.ToList();
            mockRepo.Setup(x => x.FindAll()).Returns(displayResults);
            var domainServices = new LeagueService(mockRepo.Object);

            //Act
            var allPlayers = domainServices.GetAllPlayers();

            //Assert
            allPlayers.Should().BeEquivalentTo(_players.ToList());
        }
    }
}
