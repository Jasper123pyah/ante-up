using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ante_up.Common.Models;
using ante_up.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ante_up.Controllers
{
    namespace Together.Controllers
    {
        [EnableCors("AllowCORS")]
        [ApiController]
        [Route("[controller]")]
        public class GameController : ControllerBase
        {
            private readonly AnteUpContext antecontext;

            public GameController(AnteUpContext context)
            {
                antecontext = context;
            }
            
            [HttpGet]
            public List<Game> GetGames()
            {
                GameData gameData = new(antecontext);
                List<Game> games = gameData.GetAllGames();
                return games;
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