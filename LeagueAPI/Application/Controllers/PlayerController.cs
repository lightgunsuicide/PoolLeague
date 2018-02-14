using System.Net;
using System.Net.Http;
using LeagueAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace LeagueAPI.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/Player")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost("/addplayer/{username}")]
        public HttpResponseMessage AddPlayer(string username)
        {
             _playerService.Add(username);

                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                };
                return response;
        }

        [HttpGet("id/{id}")]
        public ActionResult FindPlayerById(string id)
        {
            var convertedId = new BsonObjectId(new ObjectId(id));

            var playerToReturn = _playerService.SearchById(convertedId);
            var jsonPlayer = playerToReturn.ToJson();
            return Ok(jsonPlayer);
        }

        [HttpGet("name/{username}")]
        public ActionResult FindPlayerByUsername(string username)
        {
            var playerToReturn = _playerService.SearchByUsername(username);
            var jsonPlayer =  playerToReturn.ToJson();
            return Ok(jsonPlayer);
        }

        [HttpDelete("deleteplayer/{username}")]
        public ActionResult DeletePlayer(string username)
        {
            var responseText = _playerService.Remove(username);

            if (responseText.Contains("Success"))
            {
                return Ok(Content(responseText));
            }
            return NotFound(responseText);
        }
    }
}
