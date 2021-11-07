using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Data;
using ante_up.Logic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ante_up.Controllers
{
    namespace Together.Controllers
    {
        [EnableCors("AllowCORS")]
        [ApiController]
        [Route("[controller]")]
        public class GameController : ControllerBase
        {
            private readonly GameLogic _gameLogic;

            public GameController(IAnteUpContext context)
            {
                _gameLogic = new GameLogic(new GameData(context));
            }

            [HttpGet]
            public IActionResult GetGames()
            {
                return StatusCode(200, _gameLogic.GetAllGames());
            }

            [HttpGet("/game/names")]
            public IActionResult GetGameNames()
            {
                return StatusCode(200,_gameLogic.GetAllGameNames());
            }
        }
    }
}