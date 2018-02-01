using FluentAssertions;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Configuration;
using LeagueAPI.Repository;
using Microsoft.Extensions.Options;
using Xunit;
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

        [Fact]
        public void UpdatingGameLoser()
        {         
            //Arrange
            var game = new GameDto();
            game.GameID = new BsonObjectId(new ObjectId());
            game.Loser = new BsonObjectId(new ObjectId("5a6f1b9b096a8a01c86f4c91"));
            game.Winner = new BsonObjectId(new ObjectId());

            var playerRepo = new PlayerRepository(settingsFixture.settings);

            //Act
            playerRepo.UpdateLoser(game);

            //Assert
            playerRepo.FindById(new ObjectId("5a6f1b9b096a8a01c86f4c91")).Losses.Should().Be(13);
        }

        [Fact]
        public void UpdatingGameWinner()
        {
            //Arrange
            var game = new GameDto();
            game.GameID = new BsonObjectId(new ObjectId());
            game.Winner = new BsonObjectId(new ObjectId("5a6f1b9b096a8a01c86f4c91"));
            game.Loser = new BsonObjectId(new ObjectId());

            var playerRepo = new PlayerRepository(settingsFixture.settings);

            //Act
            playerRepo.UpdateWinner(game);

            //Assert
            playerRepo.FindById(new ObjectId("5a6f1b9b096a8a01c86f4c91")).Wins.Should().Be(101);
        }

        [Fact]
        public void ReturnAll()
        {
            //Arrange
            var playerRepo = new PlayerRepository(settingsFixture.settings);


            //Act
            var listOfTopTenPlayers = playerRepo.FindAll();

            //Assert
            listOfTopTenPlayers.Count.Should().BeGreaterOrEqualTo(11);

        }

        [Fact]
        public void ReturnTopTen()
        {
            //Arrange
            var playerRepo = new PlayerRepository(settingsFixture.settings);

            //Act
            var listOfTopTenPlayers = playerRepo.ReturnTopTen();

            //Assert
            listOfTopTenPlayers.Count.Should().Be(10);
        }
    }
}
