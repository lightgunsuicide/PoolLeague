using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TestsAcceptance.API.AcceptanceTests.Steps
{
    [Binding]
    public sealed class UpdatingPlayerSteps
    {
        [Given(@"I make a call to the API requesting to add a new player")]
        public void GivenIMakeACallToTheAPIRequestingToAddANewPlayer()
        {
            ScenarioContext.Current.Pending();
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
