using RestSharp;
using TechTalk.SpecFlow;
using TestsAcceptance.API.Helpers;
namespace TestsAcceptance.API.AcceptanceTests.Steps
{
    [Binding]
    public class LeagueSteps
    {
        private HttpRequestWrapper _httpRequestWrapper;
        private string _hostUrl;

        [Given(@"I make a call to the API requesting the top (.*) players in the league")]
        public void GivenIMakeACallToTheAPIRequestingTheTopPlayersInTheLeague(int numberInList)
        {
            _hostUrl = @"http://localhost:52201/top10/";
            _httpRequestWrapper = new HttpRequestWrapper();
            var response = _httpRequestWrapper.SetMethod(Method.POST).Execute(_hostUrl);
        }
        
        [Then(@"the top (.*) players ranked by wins are returned")]
        public void ThenTheTopPlayersRankedByWinsAreReturned(int numberInList)
        {
            ScenarioContext.Current.Pending();
        }
    }
}