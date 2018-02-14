using TechTalk.SpecFlow;
using TestsAcceptance.API.Helpers;

namespace TestsAcceptance.API
{
    [Binding]
    public sealed class HooksAPI
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            var winningPlayer = "consectetur adipiscing";
            ScenarioContext.Current["winningPlayer"] = winningPlayer;
            var losingPlayer = "sodales arcu";
            ScenarioContext.Current["losingPlayer"] = losingPlayer;

            var winningPlayerId = "5a7325ec8b60a55bec120f2a";
            ScenarioContext.Current["winningPlayerId"] = winningPlayerId;
            var losingPlayerId = "5a7325ec8b60a55bec120f2c";
            ScenarioContext.Current["losingPlayerId"] = losingPlayerId;


            MongoHelper mongoHelper = new MongoHelper();
            ScenarioContext.Current.Add("mongoHelper", mongoHelper);

            ScenarioContext.Current["currentWinnerWins"] = mongoHelper.GetPlayerNumberOfWins(winningPlayerId);
            ScenarioContext.Current["currentLoserLosses"] = mongoHelper.GetPlayerNumberOfLosses(losingPlayerId);
        }

        [AfterScenario]
        public void AfterScenario()
        {
           
        }
    }
}
