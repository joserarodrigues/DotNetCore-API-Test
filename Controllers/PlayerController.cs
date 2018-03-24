using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_Test.Controllers
{
    [Route("api/players")]
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IMailService _localMailService;

        public PlayerController(ILogger<PlayerController> logger,
                                IMailService localMailService)
        {
            _logger = logger;
            _localMailService = localMailService;
        }
        private PlayerRepository _repository = PlayerRepository.Instance;

        // GET api/players
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Players);
        }

        // GET api/players/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var player = _repository.GetPlayer(id);
            if (player == null)
            {
                _logger.LogWarning($"Player with id {id} was not found");
                return NotFound();
            }

            return Ok(player);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _localMailService.Send("test", "test2");
        }
    }
}
