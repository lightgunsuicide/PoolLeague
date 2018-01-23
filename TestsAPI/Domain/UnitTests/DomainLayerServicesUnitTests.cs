using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using FluentAssertions;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Domain.Services;
using LeagueAPI.Repository;
using Xunit;

namespace TestsAPI.Domain.UnitTests
{
    
    public class DomainLayerServicesUnitTests
    {

        private  List<IPlayer> _players;

        private void PopulateListOfPlayers()
        {
            var player = new PlayerDto();
            _players = new List<IPlayer>();
            var rand = new Random(100);

            for (int i =0; i < 10; i++)
            {
                player.PlayerId = new Guid();
                player.GamesPlayed = rand.Next(1, 10);
                player.Username = rand.Next(1, 100).ToString();
                player.Losses = rand.Next(1, 100);
                player.Wins = rand.Next(1, 100);

                _players.Add(player);
            }
        }

        [Fact]
        public void RetreiveTopTen()
        {
            //Arrange
            PopulateListOfPlayers();
            
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
            PopulateListOfPlayers();

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
