using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeagueAPI.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/games")]
    public class GamesController : Controller
    {
        private IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("/addgame")]
        public HttpResponseMessage AddGameDetails([FromBody]string winner, [FromBody]string loser)
        {
           _gameService.Add(winner, loser);

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(string.Format("Game registered, winner {0}, loser {1}", winner, loser))
            };

            return response;
        }
    }
}