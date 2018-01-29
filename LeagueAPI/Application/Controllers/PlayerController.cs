using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using LeagueAPI.Application.Dtos;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

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

        [HttpPost("/addplayer")]
        public HttpResponseMessage AddPlayer([FromBody]string username)
        {
            _playerService.Add(username);

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(string.Format("New user {0} created", username))
            };
            return response;
        }

        [HttpGet("{id}")]
        public ActionResult FindPlayerById(BsonObjectId id)
        {
            return Ok(_playerService.SearchById(id));
        }

        [HttpGet("{id}")]
        public ActionResult FindPlayerByUsername(string username)
        {
            return Ok(_playerService.SearchByUsername(username));
        }

        [HttpDelete("{id}")]
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
