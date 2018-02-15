using LeagueAPI.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeagueAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/League")]
    public class LeagueController : Controller
    {
        private ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet("/top10")]
        public ActionResult GetTopTen() {
           var topTenPlayers = _leagueService.GetTopTenPlayers();

            foreach (var player in topTenPlayers) {
                JsonConvert.SerializeObject(player);
            }
            return Ok();
        }

        [HttpGet("/all")]
        public ActionResult GetAll()
        {
            return Ok(_leagueService.GetAllPlayers());
        }
    }
}
