using System;
using TechTalk.SpecFlow;
using TestsAcceptance.API.Helpers;

namespace TestsAcceptance.API.AcceptanceTests.Steps
{
    [Binding]
    public sealed class UpdatingPlayerSteps
    {
        HttpRequestWrapper _httpRequestWrapper;

        [Given(@"I make a call to the API requesting to add a new player")]
        public void GivenIMakeACallToTheAPIRequestingToAddANewPlayer()
        {
            _httpRequestWrapper = new HttpRequestWrapper();
            //Need a playerContract         

        }

        private object PlayerDto()
        {
            throw new NotImplementedException();
        }

        [When(@"I make the request")]
        public void WhenIMakeTheRequest()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the player is added to the league")]
        public void ThenThePlayerIsAddedToTheLeague()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I make a call to the API with new game data")]
        public void GivenIMakeACallToTheAPIWithNewGameData()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I add details of a game")]
        public void WhenIAddDetailsOfAGame()
        {
            ScenarioContext.Current.Pending();
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
