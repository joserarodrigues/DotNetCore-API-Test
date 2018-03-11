using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace API_Test.Controllers
{
    [Route("api/players")]
    public class MediaController : Controller
    {
        private PlayerRepository _playerRepository = PlayerRepository.Instance;
        private MediaRepository _repository = MediaRepository.Instance;

        [HttpGet("{playerId}/MediaItems")]
        public IActionResult Get(int playerId)
        {
            var player = _playerRepository.GetPlayer(playerId);
            
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player.MediaCollection);
        }

        [HttpGet("{playerId}/MediaItems/{id}")]
        public IActionResult Get(int playerId, int id)
        {
            var player = _playerRepository.GetPlayer(playerId);
            if (player == null)
            {
                return NotFound();
            }

            var media = player.MediaCollection.Where(m => m.ID == id);
            if (media == null)
            {
                return NotFound();
            }

            return Ok(media);
        }
    }
}