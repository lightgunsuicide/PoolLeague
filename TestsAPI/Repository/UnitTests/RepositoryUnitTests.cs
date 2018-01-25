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
                PlayerId =  new Guid("CA761232-ED42-11CE-BACD-00111057B223").ToString(), 
                Username = "Falsum Hominem",
                Losses = 0,
                 Wins = 0
            };

            //Act
            playerRepo.Add(playerToAdd);


            //Assert            
            playerRepo.FindById(playerToAdd.PlayerId).Should().Be(playerToAdd);

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
