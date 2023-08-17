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
        public List<Game> GetGames()
        {
            IGetAllGames readObject = new ReadGameData();
            return readObject.GetAllGames();
        }
        // public List<Rating> GetRatings()
        // {
        //     IGetAllRatings readObject = new ReadRatingData();
        //     return readObject.GetAllRatings();
        // }

        // GET: api/Games/5
        [HttpGet("{id}", Name = "GetGame")]
        public Game GetGame(int id)
        {
            IGetGame readObject = new ReadGameData();
            return readObject.GetGame(id);
        }

    // [HttpGet("{id}", Name = "GetRating")]
    //     public Rating GetRating(int rating)
    //     {
    //         IGetRating readObject = new ReadRatingData();
    //         return readObject.GetRating(rating);
    //     }

        // POST: api/Games
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void PostGame([FromBody] Game value)
        {
            IInsertGame insertObject = new SaveGame();
            insertObject.InsertGame(value);
        }
        // [EnableCors("OpenPolicy")]
        // [HttpPost]
        // public void PostRating([FromBody] Rating value)
        // {
        //     IInsertRating insertObject = new SaveRating();
        //     insertObject.InsertRating(value);
        // }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public void PutGame(int id, [FromBody] string value)
        {
        }
        // [HttpPut("{rating}")]
        // public void PutRating(int rating, [FromBody] string value)
        // {
        // }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public void DeleteGame(int id)
        {
        }
        // [HttpDelete("{rating}")]
        // public void DeleteRating(int rating)
        // {
        // }
    }
}
