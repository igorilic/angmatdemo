using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public class PlayerRepository: IPlayerRepository
    {
        private List<Player> players = new List<Player>();
        private int _nextId = 4;
        public PlayerRepository()
        {
            players.Add(new Player(){Id = 1, Name = "Roman", Position = "LB"});
            players.Add(new Player(){Id = 2, Name = "Svaba", Position = "LB"});
            players.Add(new Player(){Id = 3, Name = "Max", Position = "LB"});
        }

        public Player AddNewPlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }
            player.Id = _nextId++;
            players.Add(player);
            return player;
        }

        public Player[] GetAll()
        {
            return players.ToArray();
        }

        public Player GetPlayerById(int id)
        {
            return GetAll().Where(r => r.Id == id).FirstOrDefault();
        }

        public void RemovePlayer(int id)
        {
            players.RemoveAll(p => p.Id == id);
        }

        public bool UpdatePlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }
            int index = players.FindIndex(p =>p.Id == player.Id);
            if (index == -1)
            {
                return false;
            }
            players.RemoveAt(index);
            players.Add(player);
            return true;
        }
    }
}
