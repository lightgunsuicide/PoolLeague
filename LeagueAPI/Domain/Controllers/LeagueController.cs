using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueAPI.Domain.Services;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult GetTopTen()
        {
            return Ok(_leagueService.GetTopTenPlayers());
        }

        [HttpGet("/all")]
        public ActionResult GetAll()
        {
            return Ok(_leagueService.GetAllPlayers());
        }
    }
}
