using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using FluentAssertions;
using LeagueAPI.Configuration;
using LeagueAPI.Repository;
using Microsoft.Extensions.Options;
using Xunit;
using LeagueAPI.Application.Dtos.Interfaces;

namespace TestsAPI.Repository.UnitTests
{
     public class RepositoryUnitTests
    {
        private readonly IOptions<MongoSettings> config;

        [Fact]
        public void AddPlayer() {
            //Arrange
            var playerRepo = new PlayerRepository(config);

            //Act
            playerRepo.Add();

            //Assert
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
