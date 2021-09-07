using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ante_up.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ante_up.Controllers
{
    namespace Together.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class GameController : ControllerBase
        {
            [HttpGet]
            public List<string> GetGames()
            {
                List<string> list = new()
                {
                    "1",
                    "2",
                    "3",
                    "4",
                    "5"
                };
                return list;
            }

            [HttpPost("/add")]
            public Game NewGame(Game newGame)
            {
                Console.WriteLine(newGame);
                Game game = new Game()
                {
                    Name = newGame.Name
                };
                // data.addnewgame
                Console.WriteLine("Game Added");
                return null;
            }
        }
    }
}