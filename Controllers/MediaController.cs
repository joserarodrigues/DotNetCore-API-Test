using System.Linq;
using API_Test.Models.Media;
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

        [HttpGet("{playerId}/MediaItems/{id}", Name="GetMediaItem")]
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

        [HttpPost("{playerId}/MediaItems")]
        public IActionResult CreateMediaItem(int playerId, [FromBody]NewMediaDTO newMediaItem)
        {
            if (newMediaItem == null)
            {
                return BadRequest();
            }

            if (newMediaItem.Description == "error")
            {
                ModelState.AddModelError("description", "error is not a valid description");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = _playerRepository.GetPlayer(playerId);
            if (player == null)
            {
                return NotFound();
            }

            int maxID = _playerRepository.Players
                                         .SelectMany(p => p.MediaCollection)
                                         .Max(m => m.ID);
            
            var mediaItemToAdd = new MediaDTO
            {
                ID = ++maxID,
                Description = newMediaItem.Description
            };

            player.MediaCollection.Add(mediaItemToAdd);

            return CreatedAtRoute(
                "GetMediaItem",
                new { playerId = playerId, id = mediaItemToAdd.ID},
                mediaItemToAdd);
        }

        [HttpPut("{playerId}/MediaItems/{Id}")]
        public IActionResult UpdateMediaItem(int playerId, int id, [FromBody]UpdateMediaDTO updateMediaItem)
        {
            if (updateMediaItem == null)
            {
                return BadRequest();
            }

            if (updateMediaItem.Description == "error")
            {
                ModelState.AddModelError("description", "error is not a valid description");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = _playerRepository.GetPlayer(playerId);
            if (player == null)
            {
                return NotFound();
            }

            var mediaItem = player.MediaCollection.FirstOrDefault(m => m.ID == id);
            if (mediaItem == null)
            {
                return NotFound();
            }

            mediaItem.Description = updateMediaItem.Description;

            return NoContent();
        }

        //Patch

        [HttpDelete("{playerId}/MediaItems/{Id}")]
        public IActionResult DeleteMediaItem(int playerId, int id)
        {
            var player = _playerRepository.GetPlayer(playerId);
            if (player == null)
            {
                return NotFound();
            }

            var mediaItem = player.MediaCollection.FirstOrDefault(m => m.ID == id);
            if (mediaItem == null)
            {
                return NotFound();
            }

            player.MediaCollection.Remove(mediaItem);

            return NoContent();
        }
    }
}