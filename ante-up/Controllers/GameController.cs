using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
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
            private readonly AnteUpContext _antecontext;

            public GameController(AnteUpContext context)
            {
                _antecontext = context;
            }
            
            [HttpGet]
            public List<Game> GetGames()
            {
                GameData gameData = new(_antecontext);
                return gameData.GetAllGames();
            }

            [HttpGet("/game/names")]
            public List<string> GetGameNames()
            {
                return new GameData(_antecontext).GetAllGameNames();
            }
        }
    }
}