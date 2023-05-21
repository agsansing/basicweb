using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.models;
using API.models.interfaces;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // GET: api/Games
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Game> Get()
        {
            IGetAllGames readObject = new ReadGameData();
            return readObject.GetAllGames();
        }

        // GET: api/Games/5
        [HttpGet("{id}", Name = "Get")]
        public Game Get(int id)
        {
            IGetGame readObject = new ReadGameData();
            return readObject.GetGame(id);
        }

        // POST: api/Games
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Game value)
        {
            IInsertGame insertObject = new SaveGame();
            insertObject.InsertGame(value);
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
