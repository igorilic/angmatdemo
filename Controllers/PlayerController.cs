using System;
using Microsoft.AspNet.Mvc;
using WebApiTest.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTest.Controllers
{

    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        static readonly IPlayerRepository _repository = new PlayerRepository();
        
        // GET: api/values
        [HttpGet]
        public Player[] Get()
        {
            return _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Player Get(int id)
        {
            return _repository.GetPlayerById(id);
        }

        // POST api/values
        [HttpPost]
        public Player Post([FromBody]Player player)
        {
            player = _repository.AddNewPlayer(player);
            return player;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Player Put(int id, [FromBody]Player player)
        {
            player.Id = id;
            if (!_repository.UpdatePlayer(player))
            {
                throw new Exception("player not updated");
            }
            return player;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           Player player = _repository.GetPlayerById(id);
           if (player == null)
           {
               throw new ArgumentNullException("player");
           }
           _repository.RemovePlayer(id);
        }
    }
}
