using Day1;
using Microsoft.AspNetCore.Mvc;

namespace PlayerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
       
        private readonly PlayerService _playerService;

        public PlayerController()
        {
            _playerService = new PlayerService();
        }

        [HttpGet]
        public ActionResult<List<Player>> GetAll()
        {
            return Ok(_playerService.GetAll());
        }

        [HttpGet("{id}")]

        public ActionResult<Player> Get(int id)
        {
            var player = _playerService.Get(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);

        }

        [HttpPost]

        public ActionResult Add(Player player)
        {
           _playerService.Add(player);
            return CreatedAtAction(nameof(Get), new { id = player.Id }, player);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Player editPlayer)
        {
            if (id != editPlayer.Id)
            {
                return BadRequest();
            }
            var player = _playerService.Get(id);
            if (player == null)
            {
                return NotFound();
            }
            _playerService.Update(player);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var player = _playerService.Get(id);
            if (player == null)
            {
                return NotFound();
            }

            _playerService.Delete(id);
            return NoContent();
        }
    

}
}
