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
            //  var repository = new PlayerRepository(settings);


            //Act


            //Assert

        }
    }
}
