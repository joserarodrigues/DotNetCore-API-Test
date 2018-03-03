using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API_Test.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        private PlayersRepository _repository = PlayersRepository.Instance;

        // GET api/values
        [HttpGet]
        public IEnumerable<PlayerDTO> Get()
        {
            return _repository.Players;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PlayerDTO Get(int id)
        {
            return _repository.GetPlayer(id);
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
