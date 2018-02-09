using RestSharp;
using TechTalk.SpecFlow;
using TestsAcceptance.API.Helpers;
using FluentAssertions;
using System.Net;

namespace TestsAcceptance.API.AcceptanceTests.Steps
{
    [Binding]
    public sealed class UpdatingPlayerSteps
    {
        HttpRequestWrapper _httpRequestWrapper;
        private  string _hostUrl;
        private readonly string _newPlayerName = "falus hominem deus";

        [Given(@"I make a call to the API requesting to add a new player")]
        public void GivenIMakeACallToTheAPIRequestingToAddANewPlayer()
        {
            _hostUrl = @"http://localhost:52201/addplayer/" + _newPlayerName;
            _httpRequestWrapper = new HttpRequestWrapper();
            _httpRequestWrapper.SetMethod(Method.POST).Execute(_hostUrl);
        }

        [Then(@"the player is added to the league")]
        public void ThenThePlayerIsAddedToTheLeague()
        {           
            _hostUrl = @"http://localhost:52201/api/player/name/" + _newPlayerName;
            _httpRequestWrapper = new HttpRequestWrapper();
            var response = _httpRequestWrapper.SetMethod(Method.GET).Execute(_hostUrl);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().Contain(_newPlayerName);

            _httpRequestWrapper.SetMethod(Method.DELETE).Execute("http://localhost:52201/api/player/deleteplayer/"+_newPlayerName);
        }

        [Given(@"I make a call to the API with new game data")]
        public void GivenIMakeACallToTheAPIWithNewGameData()
        {
            var winningPlayer = "";
            var losingPlayer = "";
            _hostUrl = @"http://localhost:52201/addgame/winner="+ winningPlayer + "/loser=" + losingPlayer;
            _httpRequestWrapper = new HttpRequestWrapper();
            var response = _httpRequestWrapper.SetMethod(Method.POST).Execute(_hostUrl);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Then(@"the winning player increments their win total by one")]
        public void ThenTheWinningPlayerIncrementsTheirWinTotalByOne()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the losing player increments their losss total by one")]
        public void ThenTheLosingPlayerIncrementsTheirLosssTotalByOne()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
