using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API_Test.Controllers
{
    [Route("api/players")]
    public class PlayerController : Controller
    {
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
        }
    }
}
