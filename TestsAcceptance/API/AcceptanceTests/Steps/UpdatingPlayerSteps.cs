using RestSharp;
using TechTalk.SpecFlow;
using TestsAcceptance.API.Helpers;
using FluentAssertions;
using System.Net;
using System.Collections.Generic;

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
            _hostUrl = @"http://localhost:52201/addgame/winner=" + ScenarioContext.Current["winningPlayer"].ToString() + "/loser=" + ScenarioContext.Current["losingPlayer"].ToString();
            _httpRequestWrapper = new HttpRequestWrapper();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            var response = _httpRequestWrapper.
                SetMethod(Method.POST).
                AddHeaders(headers).      
                Execute(_hostUrl);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Then(@"the winning player increments their win total by one")]
        public void ThenTheWinningPlayerIncrementsTheirWinTotalByOne()
        {
            var winningPlayer = ScenarioContext.Current["winningPlayerId"].ToString();
            var newWinnerWinsTotal = ScenarioContext.Current.Get<MongoHelper>("mongoHelper").GetPlayerNumberOfWins(winningPlayer);
            var winnerWinsBeforeMatch =  (int) ScenarioContext.Current["currentWinnerWins"];
            newWinnerWinsTotal.Should().Be(winnerWinsBeforeMatch + 1);
        }

        [Then(@"the losing player increments their losss total by one")]
        public void ThenTheLosingPlayerIncrementsTheirLosssTotalByOne()
        {
            var losingPlayer = ScenarioContext.Current["losingPlayerId"].ToString();
            var newLoserLossesTotal = ScenarioContext.Current.Get<MongoHelper>("mongoHelper").GetPlayerNumberOfLosses(losingPlayer);
            var loserLossesBeforeMatch = (int)ScenarioContext.Current["currentLoserLosses"];
            newLoserLossesTotal.Should().Be(loserLossesBeforeMatch + 1);
        }
    }
}
