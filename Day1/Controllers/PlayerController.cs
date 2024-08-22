using Day1;
using Microsoft.AspNetCore.Mvc;

namespace PlayerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private static List<Player> players = new List<Player>();
        private int nextId = 0;

        [HttpGet]
        public ActionResult<List<Player>> GetAll()
        {
            return Ok(players);
        }

        [HttpGet("{id}")]

        public ActionResult<Player> Get(int id)
        {
            var player = players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);

        }

        [HttpPost]

        public ActionResult Add(Player player)
        {
            player.Id = nextId++;
            players.Add(player);
            return CreatedAtAction(nameof(Get), new { id = player.Id }, player);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Player editPlayer)
        {
            if (id != editPlayer.Id)
            {
                return BadRequest();
            }
            var player = players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            player.Name = editPlayer.Name;
            player.Age = editPlayer.Age;
            player.Country = editPlayer.Country;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var player = players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            players.Remove(player);
            return NoContent();
        }
    

}
}
