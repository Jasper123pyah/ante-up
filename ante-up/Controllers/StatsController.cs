using ante_up.Common.Interfaces.Data;
using ante_up.Data;
using ante_up.Logic;
using ante_up.Logic.JWT;
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
            _statsLogic = new AccountStatsLogic(new AccountData(context));
        }
        
        [HttpGet("profile/{name}")]
        public IActionResult GetAccountStats(string name)
        {
            return StatusCode(200, _statsLogic.GetAccountStats(Request.Headers["Authorization"], name));

        }
    }
}