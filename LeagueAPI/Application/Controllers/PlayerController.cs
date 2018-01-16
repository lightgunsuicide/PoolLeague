using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Created;
            response.Content = new StringContent(string.Format("New user {0} /n created with id: {1}", username, ""));

            return response;
        }

        // GET: api/Player/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Player
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Player/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
