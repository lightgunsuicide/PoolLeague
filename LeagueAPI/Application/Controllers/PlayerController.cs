using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public HttpResponseMessage FindPlayerById(Guid id)
        {
            var stream = new MemoryStream();
            var serialised = new DataContractJsonSerializer(typeof(IPlayer));
            serialised.WriteObject(stream, _playerService.SearchById(id));
            var sr = new StreamReader(stream);
            var playerJson = sr.ReadToEnd();
            var response = new HttpResponseMessage();
            response.Content = new StringContent(playerJson);
            return response;
        }

        [HttpGet("{id}")]
        public HttpResponseMessage FindPlayerByUsername(string username)
        {
            var stream = new MemoryStream();
            var serialised  = new DataContractJsonSerializer(typeof(IPlayer));
            serialised.WriteObject(stream,_playerService.SearchByUsername(username));
            var sr = new StreamReader(stream);
            var playerJson = sr.ReadToEnd();
            var response = new HttpResponseMessage();            
            response.Content = new StringContent(playerJson);
            return response;
        }

        [HttpDelete("{id}")]
        public HttpResponseMessage DeletePlayer(string username)
        {
            var responseText = _playerService.Remove(username);

            var response = new HttpResponseMessage();
            response.Content = new StringContent(responseText);

            if (responseText.Contains("Success"))
            {
                return response;
            }
            response.StatusCode = HttpStatusCode.InternalServerError;
            return response;
        }
    }
}
