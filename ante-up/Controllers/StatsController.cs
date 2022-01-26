using ante_up.Common.ApiModels.AccountStats;
using ante_up.Common.Interfaces.Data.Context;
using ante_up.Data.DataClasses;
using ante_up.Logic.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ante_up.Controllers
{
    [EnableCors("AllowCORS")]
    [ApiController]
    [Route("[controller]")]
    public class StatsController : Controller
    {
        private readonly AccountStatsLogic _statsLogic;

        public StatsController(IAnteUpContext context)
        {
            _statsLogic = new AccountStatsLogic(new AccountData(context), new WagerData(context), new AccountStatsData(context));
        }
        
        [HttpGet("/profile/{name}")]
        public IActionResult GetAccountStats(string name)
        {
            return StatusCode(200, _statsLogic.GetAccountStats(Request.Headers["Authorization"], name));
        }

        [HttpPost("/tag")]
        public IActionResult AddGamerTag(ApiGamerTag apiGamerTag)
        {
            _statsLogic.AddGamerTag(Request.Headers["Authorization"], apiGamerTag.Game, apiGamerTag.Tag);
            return StatusCode(200);
        }
        [HttpGet("/tag/{lobbyId}")]
        public IActionResult GetGamerTagFromLobby(string lobbyId)
        {
            return StatusCode(200, _statsLogic.GetGamerTagFromLobby(Request.Headers["Authorization"], lobbyId));
        }
    }
}