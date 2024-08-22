using Day1;

namespace PlayerApi
{
    public class PlayerService
    {
        private static List<Player> players = new List<Player>();
        private int nextId = 0;

        public List<Player> GetAll() 
        {
            return players; 
        }

        public Player Get(int id)
        { 
            return players.FirstOrDefault(x => x.Id == id);        
        }

        public void Add(Player player)
        {
            player.Id = nextId++;
            players.Add(player);
        }

        public void Update(Player updatePlayer)
        {
            var player = Get(updatePlayer.Id);
            if (player != null)
            {
                player.Name = updatePlayer.Name;
                player.Age = updatePlayer.Age;
                player.Country = updatePlayer.Country;
            }
        }

        public void Delete(int id)
        {
            var player = Get(id);
            if (player != null)
            {
                players.Remove(player);
            }
        }
    }
}
