using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using FluentAssertions;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Configuration;
using LeagueAPI.Repository;
using Microsoft.Extensions.Options;
using Xunit;
using LeagueAPI.Application.Dtos.Interfaces;
using MongoDB.Bson;
using TestsAPI.Helpers;

namespace TestsAPI.Repository.UnitTests
{
     public class RepositoryUnitTests : IClassFixture<DataSetupFixture>, IClassFixture<SettingsFixture>
    {
        private readonly IOptions<MongoSettings> config;
        private DataSetupFixture dataSetupFixture;
        private SettingsFixture settingsFixture;

        public RepositoryUnitTests(DataSetupFixture dbSetupFixture, SettingsFixture configFixture)
        {
            this.dataSetupFixture = dbSetupFixture;
            this.settingsFixture = configFixture;

            dataSetupFixture.SetDB(settingsFixture.settings);
            dataSetupFixture.CreateDummyData();       
        }

        [Fact]
        public void AddPlayer() {
            //Arrange
            var playerRepo = new PlayerRepository(settingsFixture.settings);
            var playerToAdd = new PlayerDto()
            {
                Name = "Falsum Hominem Et ceteca Et cetera",
                Losses = 0,
                 Wins = 0
            };

            //Act
            playerRepo.Add(playerToAdd);
            var playerIfAdded =  playerRepo.FindByUsername(playerToAdd.Name);

            //Assert            
            playerIfAdded.Name.Should().Be(playerToAdd.Name);
        }

        [Fact]
        public void FindById()
        {
            //Arrange 
            var playerRepo = new PlayerRepository(settingsFixture.settings);
            var objectId = new ObjectId("5a6f1b9b096a8a01c86f4c91");
            var bsonObjectId = new BsonObjectId(objectId);

            //Act
            var result = playerRepo.FindById(bsonObjectId);

            //Assert
            result.Name.Should().Be("Lorem Ipsum");
        }

        [Fact]
        public void RemovePlayer()
        {
            //Arrange
            var playerRepo = new PlayerRepository(settingsFixture.settings);
            var playerToRemove = "cursus convallis";
            
            //Act
            var removedText = playerRepo.Remove("cursus convallis");

            //Assert
            removedText.Should().Be("Success: Player " + playerToRemove + " has been removed");
        }
    }
}
