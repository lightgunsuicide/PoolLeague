using System.Net;
using System.Net.Http;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeagueAPI.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/Games")]
    public class GamesController : Controller
    {
        private IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("/addgame/winner={winner}/loser={loser}")]
        public HttpResponseMessage AddGameDetails(ResultDto result) { 
           _gameService.Add(result.Winner, result.Loser);

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(string.Format("Game registered, winner {0}, loser {1}", result.Winner, result.Loser))
            };
            return response;
        }
    }
}